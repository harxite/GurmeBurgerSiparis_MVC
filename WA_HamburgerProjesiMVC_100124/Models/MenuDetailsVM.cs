using Domain.Entities;

namespace WA_HamburgerProjesiMVC_100124.Models
{
    public class MenuDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
