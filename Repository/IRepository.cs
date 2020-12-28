using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T : BaseEntity
    {   
        Task <T> GetAsync(int id);
        Task <List<T>> GetAllAsync();
        Task<bool> Update(T entity);
        Task<bool> UpdateById(int id);
        Task<bool> Delete(T entity);
        Task<bool> Delete(int id);
        Task <bool> Create(T entity);
        public IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithInclude(string include);

    }
}
