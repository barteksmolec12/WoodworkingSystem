using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
	public interface ICategoryService
	{
		public IEnumerable<Category> GetCategories();
	}
}
