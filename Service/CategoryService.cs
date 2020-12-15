using Data;
using Repository;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
	public class CategoryService : ServiceBase, ICategoryService
	{
		public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
		public IEnumerable<Category> GetCategories()
		{
			return _unitOfWork.CategoryRepository.GetAll();
		}
	}
}
