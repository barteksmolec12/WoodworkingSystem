using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
	public interface IProductService
	{
		IEnumerable<Product> GetProducts();
		void AddProduct(Product product);
		void DeleteProduct(Product product);
		void UpdateProduct(Product product);
	}
}
