using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
	public interface IMachineService
	{
		//Task<List<Machine>> GetAllMachines();
		Task<Machine> GetMachineById(int id);
		Task<bool> AddMachine(Machine machine);
		Task<bool> UpdateMachine(Machine machine);
		Task<bool> DeleteMachineById(int id);
		Task<bool> UpdateMachineById(int id);
		//public IEnumerable<Product> GetProducts();
		public IEnumerable<Machine> GetAllWithInclude(string include);
	}
}
