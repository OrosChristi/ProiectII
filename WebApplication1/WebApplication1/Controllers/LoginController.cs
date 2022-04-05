using DataProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginUser(UserVM userVM)
        {   
            var user = Business.UserRepo.GetUserByUsername(userVM.Username);
            bool loggedIn = true;
            if (user == null)
            {
                loggedIn = false;
                return Json(loggedIn);
            }
            if (user.Password != userVM.Password)
            {
                loggedIn = false;
                return Json(loggedIn);
            }

            if (loggedIn)
            {
                user.LastLoginDate = DateTime.Now;
                var update = Business.UserRepo.Update(user);
            }

            return Json(loggedIn);

        }
    }
}