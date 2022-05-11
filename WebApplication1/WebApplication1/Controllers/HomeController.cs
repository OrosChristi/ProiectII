using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
<<<<<<< HEAD
    {   
=======
    { 
>>>>>>> e1e09de4eb3cd78b283d59d3031c6b77aa52a7a4
        public ActionResult Index()
        { 
            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
     
       public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}