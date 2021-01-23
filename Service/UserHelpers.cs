using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
	public class UserHelpers
	{
		static ApplicationDbContext _dataBase;
		public static ApplicationUser GetUserAboutToken(int token)
		{
			var user = _dataBase.ApplicationUser.Where(u => u.Token == token).FirstOrDefault();
			return user;
		}
	}
}
