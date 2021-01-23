using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
	public interface IEntryService  

	{
		public ApplicationUser FindUserAboutToken(long token);
		public Entry EntryExist(long token);
		Task<bool> AddEntry(Entry entry);
		Task<bool> UpdateEntry(Entry entry);
		public IEnumerable<Entry> GetAllEntries();
		
	}
}
