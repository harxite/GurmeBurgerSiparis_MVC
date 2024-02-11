using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WA_HamburgerProjesiMVC_100124.Models
{
	public class UserSignUpVM
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string RepeatPassword { get; set; }

		
	}
}
