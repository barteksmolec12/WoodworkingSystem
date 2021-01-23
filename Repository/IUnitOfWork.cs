using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public interface IUnitOfWork
	{
		IRepository<Product> ProductRepository { get; }
		IRepository<Category> CategoryRepository { get; }
		IRepository<Machine> MachineRepository { get; }
		IRepository<Event> EventRepository { get; }
		IRepository<Entry> EntryRepository { get; }
		IRepository<ApplicationUser> UserRepository { get; }


		void Save();
	}
}
