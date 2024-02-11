using Domain.Entities;

namespace WA_HamburgerProjesiMVC_100124.Models
{
    public class UserDetailsVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Order> Orders { get; set; }  
    }
}
