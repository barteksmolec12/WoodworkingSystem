using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
	public interface IEventService
	{
		public IEnumerable<Event> GetAllEvents();
		Task<Event> GetEventById(int id);
		Task<bool> UpdateEvent(Event _event);
		Task<bool> AddEvent(Event _event);
		Task<bool> DeleteEvent(Event _event);
	}
}
