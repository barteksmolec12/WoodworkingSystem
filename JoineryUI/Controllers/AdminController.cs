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
		private readonly IUnitOfWork _uow;

		[BindProperty]
		public ShopManagmentViewModel ShopViewModel { get; set; }
		public AdminController(IUnitOfWork unitOfWork)
		{
			_uow = unitOfWork;
			ShopViewModel = new ShopManagmentViewModel()
			{
				Product = new Product(),
				AllProducts = _uow.ProductRepository.GetAllWithInclude("Category"),
				Categories = _uow.CategoryRepository.GetAll()



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
			
			await _uow.ProductRepository.Create(ShopViewModel.Product);
			return RedirectToAction(nameof(ShopManagement));
		}


	}
}
