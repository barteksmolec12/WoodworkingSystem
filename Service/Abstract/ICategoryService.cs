using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
	public interface ICategoryService
	{
		public IEnumerable<Category> GetCategories();
		Task<bool> AddCategory(Category category);
		Task<Category>GetCategory(int id);
	}
}
