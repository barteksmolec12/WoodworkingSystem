using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T : BaseEntity
    {   
        Task <T> Get(int id);
        Task <List<T>> GetAll();
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Delete(int id);
        Task <bool> Create(T entity);
    }
}
