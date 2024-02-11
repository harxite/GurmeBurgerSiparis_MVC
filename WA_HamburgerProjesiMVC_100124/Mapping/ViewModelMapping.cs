using AutoMapper;
using Domain.Entities;
using WA_HamburgerProjesiMVC_100124.Models;

namespace WA_HamburgerProjesiMVC_100124.Mapping
{
    public class ViewModelMapping: Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product, CreateProductVM>().ReverseMap();
            CreateMap<AppUser, UserListVM>().ReverseMap();
        }
    }
}
