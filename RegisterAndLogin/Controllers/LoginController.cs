using Microsoft.AspNetCore.Mvc;
using RegisterAndLogin.Models;
using RegisterAndLogin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLogin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            SercurityService securityService = new SercurityService();

            if (securityService.IsValid(userModel))
            {
                return View("LoginSucces", userModel);
            }
            else
            {
                return View("LoginFailed", userModel);
            }
        }

        public IActionResult CreateNewAccount(UserModel userModel)
        {
            UsersDAO usersDAO = new UsersDAO();
            if (usersDAO.AddUser(userModel))
            {
                return View("UserIsAdded", userModel);
            }
            else
            {
                return View("UserNotAdded", userModel);
            }
        }
    }
}
