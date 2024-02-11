using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Menus = new List<Menu>();
            Quantity = 1;
            OrderStatus = Enums.OrderStatus.Received;
        }
       
        public int Quantity { get; set; } 
        public decimal TotalPrice { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
