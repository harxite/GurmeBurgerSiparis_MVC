using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WA_HamburgerProjesiMVC_100124.Models
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public SelectList? Categories { get; set; }
        public int CategoryId { get; set; }

        [DisplayName("Image File")]
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }

    }
}
