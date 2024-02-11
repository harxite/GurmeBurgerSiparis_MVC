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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasData(
                new Category { Id = 1, Name = "Burger" },
                new Category { Id = 2, Name = "Beverages" },
                new Category { Id = 3, Name = "Condiments" },
                new Category { Id = 4, Name = "Snacks" },
                new Category { Id = 5, Name = "Desserts" }

                );
            
        }
    }
}
