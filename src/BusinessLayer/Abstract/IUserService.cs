using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;


namespace BusinessLayer.Abstract
{
	public interface IUserService
	{
		List<User> GetAll();
		User GetUserById(int id);
		string Add(User user);
		string Update(User user);
		string Delete(User user);
		public List<User> GetUsersFromExcel(Stream stream);

		public void SaveExcelDataToDatBase(List<User> userList);
	}
}
