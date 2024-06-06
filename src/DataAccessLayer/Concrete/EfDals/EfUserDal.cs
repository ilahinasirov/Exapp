using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace DataAccessLayer.Concrete.EfDals
{
	public class EfUserDal :EfRepositoryBase<User,ProjectContext>,IUserDal
	{
		

		public User GetUserById(int userId)
		{
			using (var context = new ProjectContext())
			{
				return context.Set<User>().SingleOrDefault(x => x.Id == userId);
			}
		}

		public List<User> GetUsersFromExcel( Stream stream)
		{
			ExcelPackage.LicenseContext = LicenseContext.Commercial;
			var list = new List<User>();


			using (var package = new ExcelPackage(stream))
			{
				var worksheet = package.Workbook.Worksheets[0];
				int rowCount = worksheet.Dimension.Rows;

				for (int row = 2; row <= rowCount; row++)
				{
					var user = new User()
					{
						Id = int.Parse(worksheet.Cells[row, 1].Text),
						Name = worksheet.Cells[row, 2].Text,
						Surname = worksheet.Cells[row, 3].Text,
						Username = worksheet.Cells[row, 4].Text,
						Email = worksheet.Cells[row, 5].Text,
					};
					list.Add(user);

				}
			}



			return list;
		}

		public void SaveExcelDataToDatBase(List<User> userList)
		{
			using (var context = new ProjectContext())
			{
				context.Database.EnsureCreated();
				context.Users.AddRange(userList);
				context.SaveChanges();
			}

		}


	}
}
