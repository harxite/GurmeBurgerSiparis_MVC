using Domain.Entities;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel;

namespace WA_HamburgerProjesiMVC_100124.Models
{
	public class MenuCreateVM
	{
        public MenuCreateVM()
        {
			Burgers = new List<Product>();
			Beverages = new List<Product>();
			Condiments = new List<Product>();
			Snacks = new List<Product>();
			Desserts = new List<Product>();

			BurgerIds = new List<int>();
            BeverageIds = new List<int>();
            CondimentIds = new List<int>();
            SnackIds = new List<int>();
            DessertIds = new List<int>();

			CurrentProducts = new List<Product>();
        }

		public int? Id { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }

		[DisplayName("Image File")]
		public IFormFile? ImageFile { get; set; }
		
		public string? ImagePath { get; set; }
		public IEnumerable<Product> Burgers { get; set; }
		public IEnumerable<Product> Condiments { get; set; }
		public IEnumerable<Product> Beverages { get; set; }
		public IEnumerable<Product> Desserts { get; set; }
		public IEnumerable<Product> Snacks { get; set; }
        public IEnumerable<int>? BurgerIds { get; set; }
        public IEnumerable<int>? CondimentIds { get; set; }
        public IEnumerable<int>? BeverageIds { get; set; }
        public IEnumerable<int>? DessertIds { get; set; }
        public IEnumerable<int>? SnackIds { get; set; }
        public IEnumerable<Product>? CurrentProducts { get; set; }
		public IEnumerable<int>? DeleteIds { get; set; }
	}
}
