
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Menu : BaseEntity
    {
        public Menu()
        {
            Products = new List<Product>();
            Quantity = 1;

        }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public Domain.Enums.Size Size {  get; set; }
        public int Quantity { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public Order? Order { get; set; }
        public int? OrderId { get; set; }

    }
}
