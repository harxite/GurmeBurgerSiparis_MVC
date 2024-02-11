using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id);

          

            builder.HasData(
                    new Menu { Id = 1, Name = "Gurme Meat Burger", Price = 100.00, ImagePath = "GuncelResimler/BigKingKucuk.png" },
                    new Menu { Id = 2, Name = "Gurme Chicken Burger", Price = 85.00, ImagePath = "GuncelResimler/ChickenBuger.png" },
                     new Menu { Id = 3, Name = "Gurme Mini Chicken Burger", Price = 100.00, ImagePath = "GuncelResimler/ChickenBurger2.png" },
                    new Menu { Id = 4, Name = "Gurme Classic Burger", Price = 85.00, ImagePath = "GuncelResimler/MarulBurger.png" },
                     new Menu { Id = 5, Name = "Gurme Cheddar Burger", Price = 100.00, ImagePath = "GuncelResimler/MiniCheeseBurger.png" },
                    new Menu { Id = 6, Name = "Gurme Kofte Burger", Price = 85.00, ImagePath = "GuncelResimler/MiniKofteBurger.png" },
                    new Menu { Id = 7, Name = "Çilek Rüyası Lezzetleri", Price = 20.00, ImagePath = "GuncelResimler/Sundae1.png" },
                   
                     new Menu { Id = 8, Name = "Elma Rüyası Lezzetleri", Price = 20.00, ImagePath = "GuncelResimler/elma.png" },
                     new Menu { Id=9, Name="Patates Kızartması", Price=30.00,ImagePath="GuncelResimler/patates1.png"},
                     new Menu { Id = 10, Name = "Soğan Halkası", Price = 30.00, ImagePath = "GuncelResimler/onion.png" },
                     new Menu { Id = 11, Name = "Sufle", Price = 30.00, ImagePath = "GuncelResimler/sufle.png" },
                     new Menu { Id = 12, Name = "Nugget", Price = 30.00, ImagePath = "GuncelResimler/Nugget1.png" },
                     new Menu { Id = 13, Name = "Çilekli Milkshake", Price = 30.00, ImagePath = "GuncelResimler/MilkShake.png" },
                     new Menu { Id=14,Name="Kola",Price=30.00, ImagePath = "GuncelResimler/Kola1.png" }



                );
        }
    }
}
