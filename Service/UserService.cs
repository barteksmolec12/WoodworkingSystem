using Data;
using Repository;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class UserService : ServiceBase,IUserService
	{
		public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
		//public ApplicationUser GetUserAboutToken(int token)
		//{
		//	var res = _unitOfWork.UserRepository.GetAll().Where(u => u.Token == token).FirstOrDefault();
		//}
	}
}
