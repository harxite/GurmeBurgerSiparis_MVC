using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Abstract
{
    public interface IMenuRepository:IRepository<Menu>
    {
        Menu GetByIdIncludeProducts(int id);
        Menu GetByIdIncludeOrder(int id);
        Menu GetByIdIncludeProductsAndOrder(int id);
        Menu GetByIdIncludeProductsAndOrderThenCustomer(int id);
        IEnumerable<Menu>GetAllIncludeProducts();
        IEnumerable<Menu> GetAllIncludeProductsAndOrder();
        IEnumerable<Menu> GetAllIncludeOrder();
        IEnumerable<Menu> GetAllIncludeProductsAndOrderThenCustomer();
        int GetTotalActiveMenuCount();

    }
}
