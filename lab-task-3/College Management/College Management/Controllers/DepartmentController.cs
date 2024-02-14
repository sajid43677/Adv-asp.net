using College_Management.CollegeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College_Management.Controllers
{
    public class DepartmentController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Create(Department d) {
            if(ModelState.IsValid)
            {
                var db = new collegeEntities();
                db.Departments.Add(d);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
        }

        public ActionResult List() { 
            var db = new collegeEntities();
            var users = db.Departments;
            return View(users);

        }
    }
}