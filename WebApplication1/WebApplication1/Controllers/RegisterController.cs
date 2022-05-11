using DataProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class RegisterController : BaseController
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateUser(LoginVM userVM)
        {
            var user = new User();
            user.Email = userVM.Email;
            user.Username = userVM.Username;
            user.Password = userVM.Password;
            user.CreatedDate = DateTime.Now;
            
            var created = Business.UserRepo.Create(user);
            
            return Json(created);
        }
    }
}