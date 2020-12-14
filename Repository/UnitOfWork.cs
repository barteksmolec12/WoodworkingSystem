using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private ApplicationDbContext _context;
		private IRepository<Product> _productRepository;
		private IRepository<Category> _categoryRepository;

		public IRepository<Product> ProductRepository =>
			_productRepository ?? (_productRepository = new Repository<Product>(_context));
		public IRepository<Category> CategoryRepository =>
			_categoryRepository ?? (_categoryRepository = new Repository<Category>(_context));

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}

		public UnitOfWork()
		{
		}

		public void Dispose()
		{
			_context.Dispose();
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
