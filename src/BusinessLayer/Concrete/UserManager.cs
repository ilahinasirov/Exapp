using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using Core.Constants;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
	public class UserManager :IUserService
	{
		private readonly IUserDal _userDal;
		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}
		public string Add(User user)
		{
			_userDal.Add(user);
			return Messages.UserAdded;
		}
		public string Update(User user)
		{
			_userDal.Update(user);
			return Messages.UserUpdated;
		}

		public string Delete(User user)
		{
			_userDal.Delete(user);
			return Messages.UserDeleted;

		}

		

		public List<User> GetAll()
		{
			return _userDal.GetAll().ToList();
		}

		public User GetUserById(int id)
		{
			return _userDal.Get(x => x.Id == id);
		}

		public List<User> GetUsersFromExcel(Stream stream)
		{
			return _userDal.GetUsersFromExcel(stream);
		}

		public void SaveExcelDataToDatBase(List<User> userList)
		{
			 _userDal.SaveExcelDataToDatBase(userList);
		}
	}
}
