using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment1.Models;

namespace assignment1.Controllers
{
    public class HomeController : Controller
    {
        Student student = new Student();
        public ActionResult Index()
        {
            
            student.Name = "Shajid Kamal Joy";
            student.Email = "20-43677-2@aiub.edu";
            student.ID = "20-43677-2";

            ViewBag.student = student;
            return View();
        }

        public ActionResult Education()
        {
            Education[] educations = new Education[3];
            educations[0] = new Education();
            educations[0].Degree = "SSC";
            educations[0].Institution = "BN School and College-Chattogram";
            educations[0].Result = "5.00";
            educations[0].PassingYear = "2017";
            educations[1] = new Education();
            educations[1].Degree = "HSC";
            educations[1].Institution = "BN School and College-Chattogram";
            educations[1].Result = "4.42";
            educations[1].PassingYear = "2019";
            educations[2] = new Education();
            educations[2].Degree = "BSc in CSE";
            educations[2].Institution = "American International University-Bangladesh";
            educations[2].Result = "3.94";
            educations[2].PassingYear = "2024";
            student.Educations = educations;
            ViewBag.student = student;
            return View();
        }

        public ActionResult Personal()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult References()
        {
            return View();
        }

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
    }
}