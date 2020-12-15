using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using JoineryUI.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using Service.Abstract;

namespace JoineryUI.Controllers
{
	public class AdminController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		[BindProperty]
		public ShopManagmentViewModel ShopViewModel { get; set; }
		public AdminController(IProductService productService,ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;

			ShopViewModel = new ShopManagmentViewModel()
			{
				Product = new Product(),
				AllProducts = productService.GetAllWithInclude("Category"),
				Categories = _categoryService.GetCategories()
			};
			
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ShopManagement()
		{
			

			return View(ShopViewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddNewProduct()
		{
			await _productService.AddProduct(ShopViewModel.Product);
			return RedirectToAction(nameof(ShopManagement));
		}
		[HttpPost]
		
		public async Task<IActionResult> DeleteProduct(int id)
		{

			await _productService.DeleteById(id);
			return RedirectToAction(nameof(ShopManagement));
		}




	}
}
