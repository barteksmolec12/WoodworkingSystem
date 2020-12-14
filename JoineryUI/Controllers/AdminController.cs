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
		private readonly IUnitOfWork _uow;
		public AdminController(IUnitOfWork unitOfWork)
		{
			_uow = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}
		public async Task <IActionResult> ShopManagement()
		{
			Product p = new Product();
			p.CategoryId = 1;
			p.Description = "test";
			p.Image = "image";
			p.ProductName = "Drzwi";
			await _uow.ProductRepository.Create(p);
		
			return View();
		}

	}
}
