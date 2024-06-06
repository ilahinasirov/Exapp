using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebUi.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		public UserController(ProjectContext context, IUserService userService)
		{
			_userService = userService;
		}


		[HttpGet("GetUsersFromExcel")]
		public IActionResult AddUsersFromExcel()
		{
			return View();
		}


		[HttpPost("GetUsersFromExcel")]
        public IActionResult GetUsersFromExcel(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                ViewBag.Message = "Please select a valid Excel file.";
                return View();
            }

            using (var stream = new MemoryStream())
            {
                excelFile.CopyTo(stream);

                var userList = _userService.GetUsersFromExcel(stream);
                _userService.SaveExcelDataToDatBase(userList);

                ViewBag.Message = "Users added from Excel successfully.";
            }

            return View();
        }


        [HttpGet]

        public IActionResult GetAll()
        {
            List<User> userList = _userService.GetAll();
            return View();
        }

       

       





    }
}
