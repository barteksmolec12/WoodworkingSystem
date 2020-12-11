using System;
using System.Data.SqlClient;
using Repository;

namespace Service
{
	public class ServiceBase
	{

		public IUnitOfWork _unitOfWork;
		public ServiceBase(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
