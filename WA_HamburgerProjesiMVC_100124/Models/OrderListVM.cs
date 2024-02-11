using Domain.Entities;
using Domain.Enums;

namespace WA_HamburgerProjesiMVC_100124.Models
{
    public class OrderListVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
