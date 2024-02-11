using DAL.Context;
using DAL.Repositories.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
	public class GenericRepository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly AppDbContext dbContext;

		public GenericRepository(AppDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		public bool Add(T entity)
		{
			try
			{
				dbContext.Set<T>().Add(entity);
				return dbContext.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(T entity)
		{
			try
			{
				dbContext.Set<T>().Remove(entity);
				return dbContext.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}

		public T FirstOrDefault(Expression<Func<T, bool>> expression)
		{
			return dbContext.Set<T>().FirstOrDefault(expression);
		}

		public IEnumerable<T> GetAll()
		{
			return dbContext.Set<T>();
		}

        public T GetById(int id)
		{
			return dbContext.Set<T>().Find(id);
		}

		public IEnumerable<T> GetWhereList(Expression<Func<T, bool>> expression)
		{
			return dbContext.Set<T>().Where(expression);
		}

		public bool Update(T entity)
		{
			try
			{
				dbContext.Set<T>().Update(entity);
				return dbContext.SaveChanges() > 0;
			}
			catch 
			{
				return false;
			}
		}
	}
}
