using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace WA_HamburgerProjesiMVC_100124.Models
{
	public class RoleEditVM
	{
		public IdentityRole Role { get; set; }
		public IEnumerable<AppUser> Members { get; set; }
		public IEnumerable<AppUser> NonMembers { get; set; }
	}
}
