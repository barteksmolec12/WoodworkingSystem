﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JoineryUI.Controllers
{
	public class PositionsStateController : Controller
	{
		private readonly IMachineService _machineService;
		private readonly IHubContext<SignalrServer> _signalrHub;
		public PositionsStateController(IMachineService machineService, IHubContext<SignalrServer> signalrHub)
		{
			_machineService = machineService;
			_signalrHub = signalrHub;

		}
		[HttpGet]
		public IActionResult GetMachines()
		{
			var res = _machineService.GetAllWithInclude("ApplicationUser");

			return Ok(res);
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> ChangeStatusMachine(int id)
		{
			//znajdz maszyne po ID
			var m = await _machineService.GetMachineById(id);

			// zmien jej status
			if(m.State=="Wolne")
			{
				m.State = "Zajęte";

				var claimsIdentity = (ClaimsIdentity)this.User.Identity;
				var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

				m.WoodmakerId = claim.Value;

			}
			else
			{
				m.State = "Wolne";
				m.WoodmakerId = null;
			}
					

			//przekaz do UpdateMachine
			var machine = await _machineService.UpdateMachine(m);
			await _signalrHub.Clients.All.SendAsync("LoadProducts");

			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		[Authorize]
		
		public IActionResult GetLoggedUser()
		{
			var claimsIdentity = (ClaimsIdentity)this.User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
		
			return Ok(claim.Value);
		}
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteConfirmed(int ProdId)
		//{
		//	var product = await _context.Products.FindAsync(ProdId);
		//	_context.Products.Remove(product);
		//	await _context.SaveChangesAsync();
		//	await _signalrHub.Clients.All.SendAsync("LoadProducts");
		//	return RedirectToAction(nameof(Index));
		//}
	}
}
