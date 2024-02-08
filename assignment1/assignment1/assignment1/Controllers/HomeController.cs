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
        public int count = 0;
        public ActionResult Index()
        {

            student = Session["student"] as Student ?? new Student();
            return View(student);
         
        }
        [HttpGet]
        public ActionResult SignUp()
        {

            return View(new User());
        }
        [HttpPost]
        public ActionResult SignUp(User u)
        {
            if(ModelState.IsValid)
            {
                student.Name = u.Name;
                student.Email = u.Email;
                student.ID = u.Id;
                Session["student"] = student;
                return RedirectToAction("Index");
            }

            
            return View(u);
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
            return View(student);
        }

        public ActionResult Personal()
        {
            student.Name = "Shajid Kamal Joy";
            student.PhoneNo = "01700000000";
            student.FathersName = "Md. Kamal";
            student.MothersName = "Mrs. Kamal";
            student.PresentAddress = "Chattogram";
            student.DateOfBirth = "24/11/2001";
           

            return View(student);
        }

        public ActionResult Projects()
        {
            Project[] projects = new Project[4];
            projects[0] = new Project();
            projects[0].Name = "Transport Information";
            projects[0].Course = "Object Oriented Programming 1";
            projects[1] = new Project();
            projects[1].Name = "Hostel Management System";
            projects[1].Course = "Object Oriented Programming 2";
            projects[2] = new Project();
            projects[2].Name = "Software Development Project Management";
            projects[2].Course = "Webtech";
            projects[3] = new Project();
            projects[3].Name = "Vokter Odhikar";
            projects[3].Course = "Advance Webtech";
            student.Projects = projects;

           

            return View(student);
        }

        public ActionResult References()
        {
            References[] references = new References[2];
            references[0] = new References();
            references[0].Name = "Dr. Md. Abdur Rahman";
            references[0].Email = "abdur@aiub.edu";
            references[1] = new References();
            references[1].Name = "Dr. Md. Saiful Islam";
            references[1].Email = "saiful@aiub.edu";
            student.References = references;
            
            return View(student);
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