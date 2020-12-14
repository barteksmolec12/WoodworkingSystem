using Data;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class Repository<T> : IRepository<T> where T : BaseEntity
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
			var x = _set.SingleOrDefault(x => x.Id == id);

			_set.Remove(x);
			await _context.SaveChangesAsync();
			return true;

		}

		public async Task <T> Get(int id)
		{
			return await _set.SingleOrDefaultAsync(x => x.Id == id);

		}

	      public async Task<List<T>> GetAll()
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