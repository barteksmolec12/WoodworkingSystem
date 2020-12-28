using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public async Task<IActionResult> ChangeStatusMachine(int id)
		{
			var machine = await _machineService.UpdateMachineById(id);
			await _signalrHub.Clients.All.SendAsync("LoadProducts");

			return RedirectToAction(nameof(Index));
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
