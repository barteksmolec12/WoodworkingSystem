using Data;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		public void Create(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");

			}
			_set.Add(entity);
			_context.SaveChanges();

		}

		public void Delete(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");

			}

			_set.Remove(entity);
			_context.SaveChanges();

		}

		public void Delete(int id)
		{
			if (id == 0)
			{
				throw new ArgumentNullException("id");

			}
			var x = _set.SingleOrDefault(x => x.Id == id);

			_set.Remove(x);
			_context.SaveChanges();

		}

		public T Get(int id)
		{
			return _set.SingleOrDefault(x => x.Id == id);

		}

		public IEnumerable<T> GetAll()
		{
			return _set.AsEnumerable();
		}

		public void Update(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			_set.Update(entity);
			_context.SaveChanges();
		}
	}
}