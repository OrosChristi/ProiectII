using DataProject;
using DataProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class RoleController : Controller
    {
        DataBaseContext context;
        public RoleController()
        {
            context = new DataBaseContext();
        }
        // GET: Role
        public ActionResult Index()
        { var Roles=context.Roles.ToList();
            return View(Roles);
            
        }
        public ActionResult Create()
        {
            var Role = new Role();
            return View(Role);

        }
        [HttpPost]
        public ActionResult Create(Role Role)
        {    
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}