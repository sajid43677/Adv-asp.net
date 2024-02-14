using College_Management.CollegeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College_Management.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student d)
        {
            if (ModelState.IsValid)
            {
                var db = new collegeEntities();
                db.Students.Add(d);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
        }

        public ActionResult List()
        {
            var db = new collegeEntities();
            var users = db.Students;
            return View(users);

        }
    }
}