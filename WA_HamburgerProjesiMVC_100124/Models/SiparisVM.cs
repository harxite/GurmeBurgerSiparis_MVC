using Domain.Entities;

namespace WA_HamburgerProjesiMVC_100124.Models
{
    public class SiparisVM
    {
        public SiparisVM()
        {
            menus=new List<Menu>();
            products=new List<Product>();
        }

        public string UserId { get; set; }
        public List<Menu> menus {  get; set; }
        public List<Product> products { get; set; }
        public List<MenuSiparisVM> Sepet { get; set; }
    }
}
