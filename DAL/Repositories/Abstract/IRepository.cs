using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Abstract
{
	public interface IRepository<T> where T : BaseEntity
	{
		bool Add(T  entity);
		bool Delete(T entity);
		bool Update(T entity);
		T GetById(int id);
		IEnumerable<T> GetAll();
		T FirstOrDefault(Expression<Func<T, bool>> expression);

		IEnumerable<T> GetWhereList(Expression<Func<T, bool>> expression);


	}
}
