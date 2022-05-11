using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataProject;
using DataProject.Models;
using WebApplication1.ViewModels.Users;

namespace WebApplication1.Controllers
{   
    public class UsersController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        
        public ActionResult Create()
        {
            var model = new UserVM();
            var roles = db.Roles;
            model.Roles = db.Roles.Select(x => new SelectListItem(){Text=x.RoleName,Value=x.ID.ToString()}).ToList();



            return View(model);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Password,Email,CreatedDate,LastLoginDate")] UserVM userVM)
        {
            
            if (ModelState.IsValid)
            {
                var user = new User();
                user.Username = userVM.Username;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userVM);
        }

        // GET: Users/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var model = new UserVM();
            model.Username = user.Username;
            model.Password = user.Password;
            model.Email = user.Email;
            model.CreatedDate = user.CreatedDate;
            model.LastLoginDate = user.LastLoginDate;

            var roles = db.Roles;
            model.Roles = db.Roles.Select(x => new SelectListItem() { Text = x.RoleName, Value = x.ID.ToString() }).ToList();
            return View(model);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Password,Email,CreatedDate,LastLoginDate")] UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user.Username = userVM.Username;
                user.Password = userVM.Password;
                user.Email = userVM.Email;
                user.CreatedDate = userVM.CreatedDate;
                user.LastLoginDate = userVM.LastLoginDate;
                var userRole = new UsersRole();
              
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userVM);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
