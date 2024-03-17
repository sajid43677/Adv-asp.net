using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohunger.DTOs;
using zerohunger.EF;

namespace zerohunger.Controllers
{
    public class restaurantController : Controller
    {
        // GET: restaurant
        ZeroHungerEntities db = new ZeroHungerEntities();
        public ActionResult Index()
        {
            var user = Session["user"] as user;
            var data = (from r in db.requests
                        where r.restrurant.id == user.id
                        select r).ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult create()
        {
            Console.WriteLine(Session["user"]);
            return View(new requestDTO());
        }

        [HttpPost]
        public ActionResult create(requestDTO model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(Session["user"]);
                var user = Session["user"] as user;
                var request = convert(model, user);
                request.restrurant = db.restrurants.FirstOrDefault(u => u.id == user.id);
                request.collector = db.collectors.FirstOrDefault(u => u.id == 1);
                db.requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        

        public static request convert(requestDTO model,user id)
        {
            return new request
            {
                weight = model.weight,
                validity = model.validity,
                start = DateTime.Now,
                status = "pending",
                

            };

        }
    }
}