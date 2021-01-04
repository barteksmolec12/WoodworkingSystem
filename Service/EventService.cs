using Data;
using Repository;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class EventService : ServiceBase, IEventService
	{
		public EventService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}

		public async Task<bool> AddEvent(Event _event)
		{
			await _unitOfWork.EventRepository.Create(_event);
			return true;
		}

		public async Task<bool> DeleteEvent(Event _event)
		{
			await _unitOfWork.EventRepository.Delete(_event);
			return true;
		}

		public IEnumerable<Event> GetAllEvents()
		{
			return _unitOfWork.EventRepository.GetAll();
		}

		public async Task<Event> GetEventById(int id)
		{
			return await _unitOfWork.EventRepository.GetAsync(id);
		}

		public async Task<bool> UpdateEvent(Event _event)
		{
			await _unitOfWork.EventRepository.Update(_event);
			return true;
		}
	}
}
