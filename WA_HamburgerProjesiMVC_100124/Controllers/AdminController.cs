using AutoMapper;
using BLL.Services;
using DAL.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using WA_HamburgerProjesiMVC_100124.Models;

namespace WA_HamburgerProjesiMVC_100124.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly AdminService adminService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;

        public AdminController(AdminService adminService, IWebHostEnvironment webHostEnvironment,IMapper mapper)
        {
            this.adminService = adminService;
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Dashboard()
        {
            ViewBag.DailyRevenues = adminService.GetDailyRevenues().ToList();
            ViewBag.DailyOrderCounts = adminService.GetDailyOrderCounts().ToList();

            DashboardVM dashboardVM = new DashboardVM();
            dashboardVM.UserCount = ((List<AppUser>)await adminService.GetAllStandartUsers()).Count;
            dashboardVM.TotalProductsPayment = adminService.GetTotalPaymentFromProducts();
            dashboardVM.TotalPayment = adminService.GetTotalPayment();
            dashboardVM.MenuCount = adminService.GetTotalActiveMenuCount();
            dashboardVM.ProductCount = adminService.GetTotalActiveProductCount();
            return View(dashboardVM);
        }
        public IActionResult Menus(string? search)
        {
            if(search == null)
            {
                List<Menu> menuList = new List<Menu>();
                menuList = adminService.GetAllMenus().ToList();

                return View(menuList);
            }
            else
            {
                List<Menu> menuListSearch = adminService.GetAllMenusFromSearch(search).ToList();
                return View(menuListSearch);
            }
          
        }
        public IActionResult CreateMenu()
        {
            MenuCreateVM menuCreateVM = new MenuCreateVM();

            menuCreateVM.Burgers = adminService.GetAllBurgers().ToList();
            menuCreateVM.Desserts = adminService.GetAllDesserts().ToList();
            menuCreateVM.Snacks = adminService.GetAllSnacks().ToList();
            menuCreateVM.Beverages = adminService.GetAllBeverages().ToList();
            menuCreateVM.Condiments = adminService.GetAllCondiments().ToList();

            return View(menuCreateVM);
        }

        [HttpPost]
        public IActionResult CreateMenu(MenuCreateVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    if (!model.ImageFile.ContentType.StartsWith("image"))
                    {
                        ModelState.AddModelError("ImageFile", "The selected file is not an image file.");
                        return View(model);
                    }

                    string relativePath = "img/";
                    string absolutePath = Path.Combine(webHostEnvironment.WebRootPath, relativePath);
                    Directory.CreateDirectory(absolutePath);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;

                    string filePath = Path.Combine(absolutePath, uniqueFileName);

                    using(var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.ImagePath = Path.Combine(relativePath, uniqueFileName);
                }

                Menu menu = new Menu()
                {
                    Name = model.Name,
                    Description = model.Description,
                    ImagePath = model.ImagePath
                };

                List<List<int>> modelProducts = new List<List<int>>();

                modelProducts.Add(model.BurgerIds.ToList());
                modelProducts.Add(model.BeverageIds.ToList());
                modelProducts.Add(model.CondimentIds.ToList());
                modelProducts.Add(model.SnackIds.ToList());
                modelProducts.Add(model.DessertIds.ToList());

                List<Product> menuProducts = new List<Product>();

                foreach (var list in  modelProducts)
                {
                    foreach (int item in list)
                    {
                        Product product = adminService.GetProductById(item);

                        if (product != null)
                        {
                            menuProducts.Add(product);
                        }
                    }
                }

                menu.Products = menuProducts;

                double totalPrice = 0;

                foreach (var item in menu.Products)
                {
                    totalPrice += item.Price;
                }

                menu.Price = totalPrice;

                bool isAdded = adminService.AddMenu(menu);
                string result = string.Empty;
                if (isAdded)
                {
                    result = " New menu added successfully!";
                    TempData["message"] = result;
                    return RedirectToAction("Menus");
                }
                else
                {
                    result = " Something went wrong while add a new menu.";
                    TempData["message"] = result;
                    return View();
                }
               
            }

            return View(model);
        }
        public IActionResult UpdateMenu(int id)
        {
            Menu menu = adminService.GetMenuByIdIncludeProducts(id);

            MenuCreateVM model = new MenuCreateVM()
            {
                Id = menu.Id,
                Name = menu.Name,
                Description = menu.Description,
                ImagePath = menu.ImagePath,
                CurrentProducts = menu.Products
            };

            model.Burgers = adminService.GetAllBurgers().ToList();
            model.Desserts = adminService.GetAllDesserts().ToList();
            model.Snacks = adminService.GetAllSnacks().ToList();
            model.Beverages = adminService.GetAllBeverages().ToList();
            model.Condiments = adminService.GetAllCondiments().ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateMenu(MenuCreateVM model)
        {
            if (ModelState.IsValid)
            {

                Menu menu = adminService.GetMenuByIdIncludeProducts((int)model.Id);

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    if (!model.ImageFile.ContentType.StartsWith("image"))
                    {
                        ModelState.AddModelError("ImageFile", "The selected file is not an image file.");
                        return View(model);
                    }

                    string relativePath = "img/";
                    string absolutePath = Path.Combine(webHostEnvironment.WebRootPath, relativePath);
                    Directory.CreateDirectory(absolutePath);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;

                    string filePath = Path.Combine(absolutePath, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.ImagePath = Path.Combine(relativePath, uniqueFileName);
                }

                else
                {
                    model.ImagePath = menu.ImagePath;
                }

                menu.Name = model.Name;
                menu.Description = model.Description;
                menu.ImagePath = model.ImagePath;
                

                List<Product> menuCurrentProducts = menu.Products.ToList();

                foreach (int id in model.DeleteIds ?? new List<int>() { })
                {
                    Product product = menu.Products.FirstOrDefault(p => p.Id == id);
                    if (product != null)
                    {
                        menuCurrentProducts.Remove(product);
                    }
                }

                menu.Products = menuCurrentProducts;

                List<List<int>> modelProducts = new List<List<int>>();

                modelProducts.Add(model.BurgerIds.ToList());
                modelProducts.Add(model.BeverageIds.ToList());
                modelProducts.Add(model.CondimentIds.ToList());
                modelProducts.Add(model.SnackIds.ToList());
                modelProducts.Add(model.DessertIds.ToList());
                

                List<Product> menuProducts = menuCurrentProducts;

                foreach (var list in modelProducts)
                {
                    foreach (int item in list)
                    {
                        Product product = adminService.GetProductById(item);

                        if (product != null)
                        {
                            menuProducts.Add(product);
                        }
                    }
                }

                menu.Products = menuProducts;

                double totalPrice = 0;

                foreach (var item in menu.Products)
                {
                    totalPrice += item.Price;
                }

                menu.Price = totalPrice;

                bool isUpdated = adminService.UpdateMenu(menu);
                string result = string.Empty;
                if (isUpdated)
                {
                    result = " Menu updated successfully!";
                    TempData["message"] = result;
                    return RedirectToAction("Menus");
                }
                else
                {
                    result = " Something went wrong while update the menu.";
                    TempData["message"] = result;
                    return View();
                }
            }

            model.Burgers = adminService.GetAllBurgers().ToList();
            model.Desserts = adminService.GetAllDesserts().ToList();
            model.Snacks = adminService.GetAllSnacks().ToList();
            model.Beverages = adminService.GetAllBeverages().ToList();
            model.Condiments = adminService.GetAllCondiments().ToList();

            return View(model);
        }

        public IActionResult MenuDetails(int id)
        {
            Menu menu = adminService.GetMenuByIdIncludeProducts(id);

            MenuDetailsVM vm = new MenuDetailsVM()
            {
                Id = menu.Id,
                Name = menu.Name,
                Description = menu.Description,
                ImagePath = menu.ImagePath,
                Products = menu.Products
            };

            return View(vm);
        }

        public IActionResult DeleteMenu(int id)
        {
            Menu menu = adminService.GetMenuByIdIncludeProducts(id);

            if (menu.Products.Count() > 0 || menu.Products != null)
            {
                List<Product> emptyProdList = new List<Product>();


                menu.Products = emptyProdList;
                menu.Order = null;
                
                adminService.UpdateMenu(menu);
              
            }


            bool isDeleted = adminService.DeleteMenu(menu);
            string result = string.Empty;
            if (isDeleted) result = " Menu deleted successfully!";
            else result = " Something went wrong while delete the menu.";
            TempData["message"] = result;
            return RedirectToAction("Menus");
        }
        public IActionResult MenuChangeStatus(int id)
        {

            Menu menu = adminService.GetMenuById(id);

            if (menu.Status == Domain.Enums.Status.Active)
                menu.Status = Domain.Enums.Status.Passive;
            else
                menu.Status = Domain.Enums.Status.Active;

            adminService.UpdateMenu(menu);
            return RedirectToAction("Menus");
        }
        public IActionResult Products(string? search)
        {
            if(search == null)
            {
                List<Product> productList = new List<Product>();
                productList = adminService.GetAllProductsCategories().ToList();
                return View(productList);
            }
            else
            {
                IEnumerable<Product> productListSearch = adminService.GetAllProductsCategoriesFromSearch(search);
                return View(productListSearch);
            }

           
        }
        public IActionResult CreateProduct()
        {
            List<Category> categories = adminService.GetAllCategories().ToList();
            CreateProductVM createProductVM = new CreateProductVM();
            createProductVM.Categories = new SelectList(categories, "Id", "Name");

            return View(createProductVM);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                if (productVM.ImageFile != null && productVM.ImageFile.Length > 0)
                {
                    if (!productVM.ImageFile.ContentType.StartsWith("image"))
                    {
                        ModelState.AddModelError("ImageFile", "The selected file is not an image file.");
                        return View(productVM);
                    }

                    string relativePath = "img/";
                    string absolutePath = Path.Combine(webHostEnvironment.WebRootPath, relativePath);
                    Directory.CreateDirectory(absolutePath);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + productVM.ImageFile.FileName;

                    string filePath = Path.Combine(absolutePath, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        productVM.ImageFile.CopyTo(stream);
                    }

                    productVM.ImagePath = Path.Combine(relativePath, uniqueFileName);
                }

                Product product = new Product();
                product.Name = productVM.Name;
                product.Price = productVM.Price;
                product.CategoryId = productVM.CategoryId;
                product.ImagePath = productVM.ImagePath;
                bool isAdded = adminService.AddProduct(product);
                string result = string.Empty;
                if (isAdded)
                {
                    result = " New product added successfully!";
                    TempData["message"] = result;
                    return RedirectToAction("Products");
                }
                else
                {
                    result = " Something went wrong while add a new product.";
                    TempData["message"] = result;
                    return View();
                }

            }
            List<Category> categories = adminService.GetAllCategories().ToList();
            productVM.Categories = new SelectList(categories, "Id", "Name");
            return View(productVM);

        }
        public IActionResult UpdateProduct(int id)
        {
            List<Category> categories = adminService.GetAllCategories().ToList();

            Product product = adminService.GetProductById(id);
            UpdateProductVM productVM = new UpdateProductVM();  
            productVM.Name = product.Name;
            productVM.Price = product.Price;
            productVM.ImagePath = product.ImagePath;
            productVM.CategoryId = product.CategoryId;  
            productVM.Categories = new SelectList(categories, "Id", "Name");

            return View(productVM);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                if (productVM.ImageFile != null && productVM.ImageFile.Length > 0)
                {
                    if (!productVM.ImageFile.ContentType.StartsWith("image"))
                    {
                        ModelState.AddModelError("ImageFile", "The selected file is not an image file.");
                        return View(productVM);
                    }

                    string relativePath = "img/";
                    string absolutePath = Path.Combine(webHostEnvironment.WebRootPath, relativePath);
                    Directory.CreateDirectory(absolutePath);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + productVM.ImageFile.FileName;

                    string filePath = Path.Combine(absolutePath, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        productVM.ImageFile.CopyTo(stream);
                    }

                    productVM.ImagePath = Path.Combine(relativePath, uniqueFileName);
                }
                Product product = adminService.GetProductById(productVM.Id);
                product.Name = productVM.Name;
                product.Price = productVM.Price;
                product.CategoryId = productVM.CategoryId;
                product.ImagePath = productVM.ImagePath;
                bool isUpdated = adminService.UpdateProduct(product);
                string result = string.Empty;
                if (isUpdated)
                {
                    result = " Product updated successfully!";
                    TempData["message"] = result;
                    return RedirectToAction("Products");
                }
                else
                {
                    result = " Something went wrong while update the product.";
                    TempData["message"] = result;
                    return View();
                }

            }
            return View();


        }
        public IActionResult DeleteProduct(int id)
        {
            Product product = adminService.GetProductById(id);
            bool isDeleted = adminService.DeleteProduct(product);
            string result = string.Empty;
            if (isDeleted) result = " Product deleted successfully!";
            else result = " Something went wrong while delete the product.";
            TempData["message"] = result;

            return RedirectToAction("Products");
        }
        public IActionResult ProductChangeStatus(int id)
        {

            Product product = adminService.GetProductById(id);

            if (product.Status == Domain.Enums.Status.Active)
                product.Status = Domain.Enums.Status.Passive;
            else
                product.Status = Domain.Enums.Status.Active;

            adminService.UpdateProduct(product);
            return RedirectToAction("Products");
        }
        public IActionResult Categories()
        {
            List<Category> categoryList = new List<Category>();
            categoryList = adminService.GetAllCategories().ToList();

            return View(categoryList);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = categoryVM.Name;
                bool isAdded = adminService.AddCategory(category);
                string result = string.Empty;
                if (isAdded)
                {
                    result = " New category added successfully!";
                    TempData["message"] = result;
                    return RedirectToAction("Categories");
                }
                else
                {
                    result = " Something went wrong while add a new category.";
                    TempData["message"] = result;
                    return View();
                }
            }

            return View();

        }
        public IActionResult UpdateCategory(int id)
        {
            Category category = adminService.GetCategoryById(id);
            UpdateCategoryVM updateCategoryVM = new UpdateCategoryVM();
            updateCategoryVM.Name = category.Name;
            return View(updateCategoryVM);
        }
        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                Category category = adminService.GetCategoryById(categoryVM.Id);
                category.Name = categoryVM.Name;
                bool isUpdated = adminService.UpdateCategory(category);
                string result = string.Empty;
                if (isUpdated)
                {
                    result = " Category updated successfully!";
                    TempData["message"] = result;
                    return RedirectToAction("Categories");
                }
                else
                {
                    result = " Something went wrong while update the school.";
                    TempData["message"] = result;
                    return View();
                }

            }
            return View();
        }
        public IActionResult DeleteCategory(int id)
        {
            Category category = adminService.GetCategoryById(id);
            bool isDeleted = adminService.DeleteCategory(category);
            string result = string.Empty;
            if (isDeleted) result = " Category deleted successfully!";
            else result = " Something went wrong while delete the category.";
            TempData["message"] = result;
            return RedirectToAction("Categories");
        }
        public async Task<IActionResult> Users()
        {
            IList<AppUser> userList = await adminService.GetAllStandartUsers();

            return View(mapper.Map<List<UserListVM>>(userList));
        }
        public async Task<IActionResult> UserDetails(string email)
        {
            AppUser user = await adminService.GetUserByEmail(email);

            IEnumerable<Order> orders = adminService.GetByUserIdIncludeMenusOrderByCreatedDate(user.Id);
            UserDetailsVM userDetailsVM = new UserDetailsVM();
            userDetailsVM.FirstName = user.FirstName;
            userDetailsVM.LastName = user.LastName;
            userDetailsVM.Orders = orders;
            return View(userDetailsVM);
        }

        public async Task<IActionResult> UserChangeStatus(string email)
        {
            AppUser user = await adminService.GetUserByEmail(email);
            if (user.Status == Domain.Enums.Status.Active)
                user.Status = Domain.Enums.Status.Passive;
            else
                user.Status = Domain.Enums.Status.Active;
            IdentityResult result = await adminService.UpdateUser(user);

            return RedirectToAction("Users");
        }
        public IActionResult Orders()
        {
            List<Order> orderList = adminService.GetAllOrdersWithUsers().ToList();

            List<OrderListVM> vmList = new List<OrderListVM>();

            foreach (Order order in orderList)
            {
                OrderListVM orderListVM = new OrderListVM();
                orderListVM.Id = order.Id;
                orderListVM.CreatedDate = order.CreatedDate;
                orderListVM.OrderStatus = order.OrderStatus;
                orderListVM.TotalPrice = order.TotalPrice;
                orderListVM.Quantity = order.Quantity;
                
                vmList.Add(orderListVM);
            }

            return View(vmList);
        }

        public IActionResult OrderDetails(int id)
        {
            Order order = adminService.GetOrderByIdIncludeUsersAndMenus(id);

            OrderDetailsVM detailsVM = new OrderDetailsVM()
            {
                AppUser = order.AppUser,
                AppUserId = order.AppUserId,

            };

            List<Menu> menus = new List<Menu>();

            foreach (Menu menu in order.Menus)
            {
                menus.Add(menu);
            }
            detailsVM.Menus = menus;
            return View(detailsVM);
        }

        public IActionResult ChangeOrderStatus(int id)
        {
            Order order = adminService.GetOrderById(id);
            switch (order.OrderStatus)
            {
                case Domain.Enums.OrderStatus.Received:
                    order.OrderStatus = Domain.Enums.OrderStatus.InProgress;
                    break;
                case Domain.Enums.OrderStatus.InProgress:
                    order.OrderStatus = Domain.Enums.OrderStatus.ReadyForPickup;
                    break;
                case Domain.Enums.OrderStatus.ReadyForPickup:
                    order.OrderStatus = Domain.Enums.OrderStatus.OnTheWay;
                    break;
                case Domain.Enums.OrderStatus.OnTheWay:
                    order.OrderStatus = Domain.Enums.OrderStatus.Delivered;
                    break;
                default:
                    break;
            }

            adminService.UpdateOrder(order);
            return RedirectToAction("Orders");

        }

        public IActionResult CancelOrder(int id)
        {
            Order order = adminService.GetOrderById(id);
            order.OrderStatus = Domain.Enums.OrderStatus.Canceled;
            adminService.UpdateOrder(order);
            return RedirectToAction("Orders");
        }
        public async Task<IActionResult> Messages()
        {
            List<Message> messages = adminService.GetAllMessages().ToList();
            List<ContactVm> contactVmList = new List<ContactVm>();
            foreach (Message item in messages)
            {
                ContactVm contactVm = new ContactVm();
                contactVm.Message = item;
                contactVm.User = await adminService.GetUserById(item.UserId);
                contactVmList.Add(contactVm);
            }
            return View(contactVmList);
        }

        public IActionResult MessageDetails(int id)
        {
            Message message = adminService.GetMessageById(id);
            return View(message);
        }
    }
}
