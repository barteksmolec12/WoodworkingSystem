using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using Service.Abstract;

namespace JoineryUI.Controllers
{
	public class AdminController : Controller
	{
		private readonly IProductService productService;
		public AdminController(IProductService productService)
		{
			this.productService= productService;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ShopManagement()
		{
			//Product p = new Product();
			//p.Id = 2;
			//p.CategoryId = 1;
			//p.Description = "test";
			//p.Image = "test123";
			//p.ProductName = "test";
			//p.Price = 123;
			IEnumerable<Product> test;
			test= productService.GetProducts();

			return View();
		}

	}
}
