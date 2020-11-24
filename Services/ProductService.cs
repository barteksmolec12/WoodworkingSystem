using Data;
using Repository;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
	public class ProductService:IProductService
	{
		private IRepository<Product> productRepository;
		public ProductService(IRepository<Product> productRepository)
		{
			this.productRepository = productRepository;
		}

		public void AddProduct(Product product)
		{
			productRepository.Create(product);
		}

		public void DeleteProduct(Product product)
		{
			productRepository.Delete(product);
		}

		public IEnumerable<Product> GetProducts()
		{
			return productRepository.GetAll();
		}

		public void UpdateProduct(Product product)
		{
			productRepository.Update(product);
		}
	}
}
