using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace BLL.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> user;
        public UserService(UserManager<AppUser> user )
        {
            this.user = user;
        }
        
    }
}