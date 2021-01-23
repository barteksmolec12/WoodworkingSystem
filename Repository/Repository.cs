using Data;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		private DbSet<T> _set;
		public Repository(ApplicationDbContext context)
		{
			_context = context;
			_set = _context.Set<T>();


		}
		
		public async Task <bool> Create(T entity)
		{
			if (entity == null)
			{
				return false;
				

			}
			await _set.AddAsync(entity);
			await _context.SaveChangesAsync();
			return true;

		}

		public async Task<bool> Delete(T entity)
		{
			if (entity == null)
			{
				return false;

			}

			_set.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Delete(int id)
		{
			if (id == 0)
			{
				return false;

			}

			var x = _set.Find(id);

			_set.Remove(x);
			await _context.SaveChangesAsync();
			return true;

		}

		public async Task <T> GetAsync(int id)
		{
			return await _set.FindAsync(id);

		}

	      public async Task<List<T>> GetAllAsync()
		{

			return await _set.ToListAsync();
		}

	

		public async Task<bool> Update(T entity)
		{
			if (entity == null)
			{
				return false;
			}
			_set.Update(entity);
			await _context.SaveChangesAsync();
			return true;
		}

		public IEnumerable<T> GetAll()
		{
			return _set.AsEnumerable();
		}
		

		public IEnumerable<T> GetAllWithInclude(string include)
		{
			var query = _set.AsQueryable();
			query = query.Include(include);
			return query;
		}

		public async Task<bool> UpdateById(int id)
		{
			if (id == 0)
			{
				return false;

			}
			var x = _set.Find(id);

			_set.Update(x);
			await _context.SaveChangesAsync();
			return true;
		}

	







		//Task<T> IRepository<T>.Get(int id)
		//{
		//	throw new NotImplementedException();
		//}

		//Task<bool> IRepository<T>.Update(T entity)
		//{
		//	throw new NotImplementedException();
		//}
	}
}