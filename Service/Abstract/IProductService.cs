using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
	public interface IProductService
	{
		Task <List<Product>> GetProducts();
		Task<bool> AddProduct(Product product);
		Task<bool> DeleteProduct(Product product);
		Task<bool> UpdateProduct(Product product);
	}
}
