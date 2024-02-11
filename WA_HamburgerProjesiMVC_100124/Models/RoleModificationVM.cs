namespace WA_HamburgerProjesiMVC_100124.Models
{
	public class RoleModificationVM
	{
		public string RoleName { get; set; }
		public string RoleId { get; set; }
		public string[]? AddIds { get; set; }
		public string[]? DeleteIds { get; set; }
	}
}
