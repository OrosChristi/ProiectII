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
        public ActionResult LoginUser(LoginVM userVM)
        {   
            var user = Business.UserRepo.GetUserByUsername(userVM.Username);
            bool loggedIn = true;
            if (user == null)
            {
                loggedIn = false;
                return RedirectToAction("Login");
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
            if (user != null)
            {
                Session["ID"] = user.ID.ToString();
                Session["Username"] = user.Username.ToString();
                return Json(loggedIn);
            }
            return Json(loggedIn);

        }
    }
}