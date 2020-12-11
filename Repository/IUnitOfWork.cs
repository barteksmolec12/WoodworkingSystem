using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public interface IUnitOfWork
	{
		IRepository<Product> ProductRepository { get; }
		void Save();
	}
}
