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
		public IActionResult ShopManagement()
		{
			var test = _uow.ProductRepository.GetAll();
		
			return View();
		}

	}
}
