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
		private IRepository<Machine> _machineRepository;
		private IRepository<Event> _eventRepository;
		private IRepository<Entry> _entryRepository;
		private IRepository<ApplicationUser> _userRepository;



		public IRepository<Product> ProductRepository =>
			_productRepository ?? (_productRepository = new Repository<Product>(_context));
		public IRepository<Category> CategoryRepository =>
			_categoryRepository ?? (_categoryRepository = new Repository<Category>(_context));

		public IRepository<Machine> MachineRepository =>
			_machineRepository ?? (_machineRepository = new Repository<Machine>(_context));
		public IRepository<Event> EventRepository =>
			_eventRepository ?? (_eventRepository = new Repository<Event>(_context));
		public IRepository<Entry> EntryRepository =>
			_entryRepository ?? (_entryRepository = new Repository<Entry>(_context));
		public IRepository<ApplicationUser> UserRepository =>
			_userRepository ?? (_userRepository = new Repository<ApplicationUser>(_context));

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
