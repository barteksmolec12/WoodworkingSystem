using Data;
using Repository;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Service
{
	public class EntryService:ServiceBase,IEntryService
	{
		public EntryService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}

		public async Task<bool> AddEntry(Entry entry)
		{
			await _unitOfWork.EntryRepository.Create(entry);
			return true;
		}

		public Entry EntryExist(long token)
		{
			var res = _unitOfWork.EntryRepository.GetAllWithInclude("ApplicationUser").Where(x => x.ExitDate == null && x.ApplicationUser.Token == token).FirstOrDefault();
			return res;
		}

		public ApplicationUser FindUserAboutToken(long token)
		{

			var user = _unitOfWork.UserRepository.GetAll().Where(u => u.Token == token).FirstOrDefault();//UserHelpers.GetUserAboutToken(token);
			return user;
		
		}

		public IEnumerable<Entry> GetAllEntries()
		{
			return _unitOfWork.EntryRepository.GetAllWithInclude("ApplicationUser").Reverse();
		}

		public async Task<bool> UpdateEntry(Entry entry)
		{
			await _unitOfWork.EntryRepository.Update(entry);
			return true;
			
		}
	}
}
