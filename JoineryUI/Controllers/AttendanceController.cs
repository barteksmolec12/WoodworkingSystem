using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoineryUI.Controllers
{
	public class AttendanceController : Controller
	{
		private readonly IEntryService _entryService;
		private readonly IHubContext<SignalrServer> _signalrHub;


		public AttendanceController(IEntryService entryService, IHubContext<SignalrServer> signalrHub)
		{
			_entryService = entryService;
			_signalrHub = signalrHub;

		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult GetEntries()
		{
			var res = _entryService.GetAllEntries();
			
			return Ok(res);
		}
		[Route("Attendance/SingleAttendanceEntry/{*token}")]
		public async Task <IActionResult> SingleAttendanceEntry(long token)
		{
			
			var entry = _entryService.EntryExist(token);
			//find user about TOKEN

			if (entry!=null)
			{
				//update entry
				
				    entry.ExitDate = DateTime.Now;
					entry.TimeOut= DateTime.Now.ToString("HH:mm:ss");
				    await _entryService.UpdateEntry(entry);
				    await _signalrHub.Clients.All.SendAsync("LoadEntries");
				    return RedirectToAction(nameof(Index));

			}
			else
			{
				//find User
				var user = _entryService.FindUserAboutToken(token);
				Entry e = new Entry


				{
					ApplicationUser = user,
					DayOfEntry = DateTime.Now.ToString("dd.MM.yyyy"),
					DateOfEntry = DateTime.Now,
					TimeIn = DateTime.Now.ToString("HH:mm:ss"),
					TimeOut = "",
				    ExitDate =null,
					EmployeeId = user.Id
					
				};
				//add new entry
				await _entryService.AddEntry(e);
				await _signalrHub.Clients.All.SendAsync("LoadEntries");
				return RedirectToAction(nameof(Index));

			}
			
		}
	}
}
