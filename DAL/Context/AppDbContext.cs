using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using DAL.Configurations;

namespace DAL.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
		public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
		{


			

			const string adminId = "df5a9b38-18e8-48b7-97bf-ad4a9b4afe0e";

			const string roleId = "f6040633-db1b-4a48-be54-9f214e77ac9d";

			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = roleId,
				Name = "admin",
				NormalizedName = "ADMIN"
			},
			new IdentityRole
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Standard User",
				NormalizedName = "STANDARD USER"
			}
			);

			var hasher = new PasswordHasher<AppUser>();
			builder.Entity<AppUser>().HasData(new AppUser
			{
				Id = adminId,
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "admin@contoso.com",
				NormalizedEmail = "ADMIN@CONTOSO.COM",
				PasswordHash = hasher.HashPassword(null, "Anyela123+"),
				SecurityStamp = string.Empty,
				FirstName = "Admin",
				LastName = "Admin"
			});

			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				UserId = adminId,
				RoleId = roleId,
			});
			new CategoryConfiguration().Configure(builder.Entity<Category>());
			new ProductConfiguration().Configure(builder.Entity<Product>());
			new MenuConfiguration().Configure(builder.Entity<Menu>());

			base.OnModelCreating(builder);

            

		}


    }
}