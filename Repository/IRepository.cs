using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public interface IRepository<T> where T:class
	{
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Create(T entity);
    }
}
