using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Quantity = 1;
        }
        public double Price { get; set; }
        public string? ImagePath { get; set; }
        public Menu? Menu { get; set; }
        public int? MenuId { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Order? Order { get; set; }
        public int? OrderId { get; set; }
    }
}
