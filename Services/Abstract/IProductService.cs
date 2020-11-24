using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
	public interface IProductService
	{
		IEnumerable<Product> GetProducts();
		void AddProduct(Product product);
		void DeleteProduct(Product product);
		void UpdateProduct(Product product);
	}
}
