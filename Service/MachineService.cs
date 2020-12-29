using Data;
using Repository;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class MachineService : ServiceBase, IMachineService
	{
		public MachineService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
		public Task<bool> AddMachine(Machine machine)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteMachineById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Machine> GetAllWithInclude(string include)
		{
			return _unitOfWork.MachineRepository.GetAllWithInclude(include);
		}

		public async Task<Machine> GetMachineById(int id)
		{
			return await _unitOfWork.MachineRepository.GetAsync(id);
		}

		public async Task<bool> UpdateMachine(Machine machine)
		{
			await _unitOfWork.MachineRepository.Update(machine);
			return true;
		}

		public async Task<bool> UpdateMachineById(int id)
		{
			await _unitOfWork.MachineRepository.UpdateById(id);
			return true;
		}
	}
}
