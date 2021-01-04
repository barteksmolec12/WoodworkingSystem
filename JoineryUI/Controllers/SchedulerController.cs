using Data;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoineryUI.Controllers
{
	public class SchedulerController : Controller
	{
		private readonly IEventService _eventService;

		public SchedulerController(IEventService eventService)
		{
			_eventService = eventService;
		}
		public IActionResult Index()
		{
			return View();
		}

	    [HttpGet]
		public IActionResult GetEvents()
		{
			var events = _eventService.GetAllEvents();
			return Ok(events);
		}



        [HttpPost]
        public async Task <IActionResult> SaveEvent(Event e)
        {
            Event v = null;
            v = await _eventService.GetEventById(e.Id);

            if (e.Id > 0)
                
            {
                    if (v != null)
                    {
                        v.Id = e.Id;
                        v.Subject = e.Subject;
                        v.StartAssembley = e.StartAssembley;
                        v.EndAssembley = e.EndAssembley;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                        
                        await _eventService.UpdateEvent(v);
                    }

            }
            
            else
            
            {
                await _eventService.AddEvent(v);
            }
                
              
            
            return Ok();
        }
        [HttpPost]
        public async Task <IActionResult> DeleteEvent(int eventID)
        {

            var v = await _eventService.GetEventById(eventID);
                
            if (v != null)
                
            {
                
               await _eventService.DeleteEvent(v);

            }

            return Ok();

        }
    }
}


