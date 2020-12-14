using Data;
using Repository;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{

	public class ProductService : ServiceBase, IProductService
	{

		public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}

		public void AddProduct(Product product)
		{
			_unitOfWork.ProductRepository.Create(product);
		}

		public void DeleteProduct(Product product)
		{
			_unitOfWork.ProductRepository.Delete(product);
		}

		public IEnumerable<Product> GetProducts()
		{
			return _unitOfWork.ProductRepository.GetAll();
		}

		public void UpdateProduct(Product product)
		{
			_unitOfWork.ProductRepository.Update(product);
		}
	}
}

