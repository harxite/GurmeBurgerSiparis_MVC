using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace WA_HamburgerProjesiMVC_100124.Models
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public SelectList? Categories { get; set; }
        public int CategoryId { get; set; }

        [DisplayName("Image File")]
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }

    }
}
