using System.ComponentModel.DataAnnotations;

namespace WA_HamburgerProjesiMVC_100124.Models
{
	public class LoginVM
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
		public string ReturnUrl { get; set; }
	}
}
