using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using Domain.Entities;

namespace BLL.Services
{
    public class OrderService
    {
        private readonly IOrderRepository order;
        public OrderService(IOrderRepository order)
        {
            this.order = order;
            
        }

        public List<Order> GetOrderListByUserId(string id)
        {
            return (List<Order>)order.GetByUserIdIncludeMenusOrderByCreatedDate(id);
        }
        public void SaveOrders(Order orders)
        {
            order.Add(orders);
        }
    }
}