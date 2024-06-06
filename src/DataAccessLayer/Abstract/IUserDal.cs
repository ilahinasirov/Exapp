using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Entities.Concrete;

namespace DataAccessLayer.Abstract
{
	public interface IUserDal :IEntityRepository<User>
	{
		
		public User GetUserById(int userId);

		public List<User> GetUsersFromExcel(Stream stream);

		public void SaveExcelDataToDatBase(List<User>  userList);
	}
}
