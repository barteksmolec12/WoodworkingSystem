using Data;
using Repository;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

	public class ProductService : ServiceBase, IProductService
	{

		public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}

		public async Task<bool>AddProduct(Product product)
		{
			await _unitOfWork.ProductRepository.Create(product);
			return true;
		}

		public async Task<bool>DeleteProduct(Product product)
		{
			await _unitOfWork.ProductRepository.Delete(product);
			return true;
		}

		public async Task <List<Product>> GetProducts()
		{
			return await _unitOfWork.ProductRepository.GetAll();
		}

		public async Task<bool> UpdateProduct(Product product)
		{
			await _unitOfWork.ProductRepository.Update(product);
			return true;
		}
	}
}

