using Domain.Entities;

namespace WA_HamburgerProjesiMVC_100124.Models
{
    public class OrderDetailsVM
    {
        public ICollection<Menu> Menus { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
