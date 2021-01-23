using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using JoineryUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace JoineryUI.Controllers
{
	public class CustomerController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public CustomerController(IProductService productService,ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
			

		}
		public IActionResult Index()
		{
			var _products = _productService.GetProducts();
			var _categories = _categoryService.GetCategories();
			ShopAreaViewModel model = new ShopAreaViewModel()
			{
				products = _products,
				categories = _categories
			};
			

			return View(model);
		}
		[Authorize]
		public IActionResult Details()
		{
			return View();
		}
		public IActionResult ShoppingCart()
		{
			return View();
		}
		[HttpPost]
		public async Task <IActionResult> AddCategory(string categoryName)
		{
			Category c = new Category();
			c.Name = categoryName;
			await _categoryService.AddCategory(c);
			return Ok();
		}
		[HttpGet]
		public async Task<IActionResult> GetCategory(int id)
		{
			var res = await _categoryService.GetCategory(id);
			return Ok(res);
		}


	}
}
