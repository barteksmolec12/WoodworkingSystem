using Data;
using Repository;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class CategoryService : ServiceBase, ICategoryService
	{
		public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}

		public async Task<bool> AddCategory(Category category)
		{
			await _unitOfWork.CategoryRepository.Create(category);
			return true;
		}

		public IEnumerable<Category> GetCategories()
		{
			return _unitOfWork.CategoryRepository.GetAll();
		}

		public async Task<Category> GetCategory(int id)
		{
			return await _unitOfWork.CategoryRepository.GetAsync(id);
			
		}
	}
}
