using DAL.Repositories.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMenuRepository menuRepository;
        private readonly IProductRepository productRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly IMessageRepository messageRepository;

        public AdminService(IOrderRepository orderRepository, ICategoryRepository categoryRepository, IMenuRepository menuRepository, IProductRepository productRepository, UserManager<AppUser> userManager, IMessageRepository messageRepository)
        {
            this.orderRepository = orderRepository;
            this.categoryRepository = categoryRepository;
            this.menuRepository = menuRepository;
            this.productRepository = productRepository;
            this.userManager = userManager;
            this.messageRepository = messageRepository;
        }

        public List<AppUser> GetAllUsers()
        {
            return userManager.Users.ToList();
        }

        public async Task<IList<AppUser>> GetAllStandartUsers()
        {
            return await userManager.GetUsersInRoleAsync("Standard User");
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }
        public async Task<AppUser> GetUserById(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> UpdateUser(AppUser user)
        {
            return await userManager.UpdateAsync(user);
        }

        public decimal GetTotalPaymentFromProducts()
        {
            return orderRepository.GetTotalPaymentFromProducts();
        }

        public decimal GetTotalPayment()
        {
            return orderRepository.GetTotalPayment();
        }

        public int GetTotalOrderCount()
        {
            return orderRepository.GetTotalOrderCount();
        }

        public int GetTotalActiveMenuCount()
        {
            return menuRepository.GetTotalActiveMenuCount();
        }

        public int GetTotalActiveProductCount()
        {
            return productRepository.GetTotalActiveProductCount();
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            return menuRepository.GetAll();
        }
        public IEnumerable<Menu> GetAllMenusFromSearch(string search)
        {
            return menuRepository.GetWhereList(x => x.Name.Contains(search));
        }

        public Menu GetMenuById(int id)
        {
            return menuRepository.GetById(id);
        }

        public Menu GetMenuByIdIncludeProducts(int id)
        {
            return menuRepository.GetByIdIncludeProducts(id);
        }
        public bool AddMenu(Menu menu)
        {
            return menuRepository.Add(menu);
        }
        public bool UpdateMenu(Menu menu)
        {
            return menuRepository.Update(menu);
        }
        public bool DeleteMenu(Menu menu)
        {
            return menuRepository.Delete(menu);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll();
        }
        public IEnumerable<Product> GetAllProductsCategories()
        {
            return productRepository.GetAllIncludeCategory();
        }
        public IEnumerable<Product> GetAllProductsCategoriesFromSearch(string search)
        {
            return productRepository.GetAllIncludeCategoryFromSearch(search);
        }

        public IEnumerable<Product> GetAllBurgers()
        {
            return productRepository.GetWhereList(a => a.Category.Name == "Burger");
        }

        public IEnumerable<Product> GetAllBeverages()
        {
            return productRepository.GetWhereList(a => a.Category.Name == "Beverages");
        }

        public IEnumerable<Product> GetAllCondiments()
        {
            return productRepository.GetWhereList(a => a.Category.Name == "Condiments");
        }

        public IEnumerable<Product> GetAllSnacks()
        {
            return productRepository.GetWhereList(a => a.Category.Name == "Snacks");
        }

        public IEnumerable<Product> GetAllDesserts()
        {
            return productRepository.GetWhereList(a => a.Category.Name == "Desserts");
        }
        public Product GetProductById(int id)
        {
            return productRepository.GetById(id);
        }
        public bool AddProduct(Product product)
        {
            return productRepository.Add(product);
        }
        public bool UpdateProduct(Product product)
        {
            return productRepository.Update(product);
        }
        public bool DeleteProduct(Product product)
        {
            return productRepository.Delete(product);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepository.GetAll();
        }
        public Category GetCategoryById(int id)
        {
            return categoryRepository.GetById(id);
        }
        public bool AddCategory(Category category)
        {
            return categoryRepository.Add(category);
        }
        public bool UpdateCategory(Category category)
        {
            return categoryRepository.Update(category);
        }
        public bool DeleteCategory(Category category)
        {
            return categoryRepository.Delete(category);
        }

        public IEnumerable<Order> GetAllOrdersWithUsers()
        {
            return orderRepository.GetAllIncludeMenusIncludeUsers();
        }
        public IEnumerable<Order> GetAllOrdersByUserId(string id)
        {
            return orderRepository.GetAllByUserId(id);
        }

        public Menu GetMenuByIdIncludeAll(int id)
        {
            return menuRepository.GetByIdIncludeProductsAndOrder(id);
        }

        public Order GetOrderById(int id)
        {
            return orderRepository.GetById(id);
        }

        public Order GetOrderByIdIncludeUsersAndMenus(int id)
        {
            return orderRepository.GetByIdIncludeUsersAndMenusAndProducts(id);
        }

        public Order GetByIdIncludeMenusWithProducts(int id)
        {
            return orderRepository.GetByIdIncludeMenusWithProducts(id);
        }
        public bool UpdateOrder(Order order)
        {
            return orderRepository.Update(order);
        }

        public IEnumerable<Order> GetByUserIdIncludeMenusOrderByCreatedDate(string id)
        {
            return orderRepository.GetByUserIdIncludeMenusOrderByCreatedDate(id);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return messageRepository.GetAll();  
        }

        public Message GetMessageById(int id)
        {
            return messageRepository.GetById(id);
        }

        public IEnumerable<decimal> GetDailyRevenues()
        {
            return orderRepository.GetDailyRevenues();
        }

        public IEnumerable<int> GetDailyOrderCounts()
        {
            return orderRepository.GetDailyOrderCounts();
        }
    }
}
