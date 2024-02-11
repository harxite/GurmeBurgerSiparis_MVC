using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MenuService
    {
        private readonly IMenuRepository menuRepository;
        private readonly IProductRepository productRepository;

        public MenuService(IMenuRepository menuRepository,IProductRepository productRepository)
        {
            this.menuRepository = menuRepository;
            this.productRepository = productRepository;
        }
        //orderid si null olanlar
        public List<Menu>GetMenusIncludeProducts()
        {
            return menuRepository.GetAllIncludeProducts().ToList();
        }
        public void UpdateChanges(Menu menu)
        {
            menuRepository.Update(menu);
        }
        public void SaveMenu(Menu menu)
        {
            menuRepository.Add(menu);
        }
        public double TotalPriceOfMenu(Menu menu)
        {
            double totalPrice = 0;
            List<Product> productsOfTheMenu = productRepository.GetByMenuId(menu.Id).ToList();
            foreach (Product product in productsOfTheMenu)
            {
                totalPrice += product.Price * product.Quantity;
            }
            menu.Price = totalPrice;
            return totalPrice * menu.Quantity;
        }
        public Menu GetMenuById(int id)
        {
           return menuRepository.GetById(id);
        }

        public Menu GetMenuByIdIncludeProducts(int id)
        {
            return menuRepository.GetByIdIncludeProducts(id);
        }
    }
}
