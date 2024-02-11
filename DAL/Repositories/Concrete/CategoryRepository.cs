using DAL.Context;
using DAL.Repositories.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Category GetByIdWithProducts(int categoryId)
        {
            return _context.Categories
                           .Include(c => c.Products)
                           .FirstOrDefault(c => c.Id == categoryId);
        }

        public IEnumerable<Category> GetAllWithProducts()
        {
            return _context.Categories
                           .Include(c => c.Products);

        }
    }
}
