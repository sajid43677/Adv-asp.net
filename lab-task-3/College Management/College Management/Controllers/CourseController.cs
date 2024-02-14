using College_Management.CollegeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College_Management.Controllers
{
    public class CourseController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Cours());
        }
        [HttpPost]
        public ActionResult Create(Cours d)
        {
            if (ModelState.IsValid)
            {
                var db = new collegeEntities();
                db.Courses.Add(d);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
        }

        public ActionResult List()
        {
            var db = new collegeEntities();
            var users = db.Courses;
            return View(users);

        }
    }
}