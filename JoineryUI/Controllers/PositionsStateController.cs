﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoineryUI.Controllers
{
	public class PositionsStateController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
