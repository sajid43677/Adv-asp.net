using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohunger.DTOs;
using zerohunger.EF;
using zerohunger.Models;

namespace zerohunger.Controllers
{
    public class HomeController : Controller
    {
        ZeroHungerEntities db = new ZeroHungerEntities();

        public ActionResult Index()
        {
            checkValidity();
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

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View(new login());
        }

        [HttpPost]
        public ActionResult Login(login model)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.users
                            where u.email.Equals(model.Email)
                            && u.pass.Equals(model.Password)
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["user"] = user;
                    if (user.role == "collector")
                    {
                        return RedirectToAction("Index","collector");
                    }
                    else if (user.role == "restaurant")
                    {
                        return RedirectToAction("Index","restaurant");
                    }
                    else if (user.role == "admin")
                    {
                        return RedirectToAction("Index","admin");
                    }
                }
                model.msg = "Invalid Email or Password";
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            ViewBag.Message = "Sign Up";

            return View(new signup());
        }
        [HttpPost]
        public ActionResult SignUp(signup model)
        {
            if (ModelState.IsValid)
            {
                var user = new userDTO
                {
                    email = model.Email,
                    pass = model.Password,
                    role = model.Role
                };
                var userl = Convert(user);
                
                if(user.role == "collector")
                {
                    var collectord = new collectorDTO
                    {
                        name = model.Name,
                        current_assigned = 0
                    };
                    var collector = Convert(collectord);

                    db.collectors.Add(collector);
                }
                else if(user.role == "restaurant")
                {
                    if(model.Location.IsNullOrWhiteSpace() || model.Name.IsNullOrWhiteSpace())
                    {
                        model.msg = "Please fill location fields if you are \n signing up as restaurant user";
                        return View(model);
                    }
                    var restaurantd = new restrurantDTO
                    {
                        name = model.Name,
                        location = model.Location
                    };
                    var restaurant = Convert(restaurantd);
                    db.restrurants.Add(restaurant);
                }
                db.users.Add(userl);
                db.SaveChanges();



                return RedirectToAction("Index");
            }
            model.msg = "Invalid request. Please fill the form correctly!";
            return View(model);
        }

        public static user Convert(userDTO user)
        {
            return new user
            {
                email = user.email,
                pass = user.pass,
                role = user.role
            };
        }

        public static collector Convert(collectorDTO collector)
        {
            return new collector
            {
                name = collector.name,
                current_assigned = collector.current_assigned
            };
        }

        public static restrurant Convert(restrurantDTO restrurant)
        {
            return new restrurant
            {
                name = restrurant.name,
                location = restrurant.location
            };
        }

        //write a function that will convert request status to expired if the validity date is less than the current date
        public static void checkValidity()
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var requests = db.requests.ToList();
            foreach (var request in requests)
            {
                if (request.validity < DateTime.Now)
                {
                    request.status = "Expired";
                }
            }
            db.SaveChanges();
        }
    }
}