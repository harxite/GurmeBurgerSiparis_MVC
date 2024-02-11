using Domain.Enums;

namespace WA_HamburgerProjesiMVC_100124.Models
{
    public class UserListVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
    }
}
