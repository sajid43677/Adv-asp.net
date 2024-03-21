using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohunger.Auth;
using zerohunger.DTOs;
using zerohunger.EF;

namespace zerohunger.Controllers
{
    [Access]
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
            return View(requestDTOs(data));
            
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
                request.collector = db.collectors.FirstOrDefault(u => u.id == 0);
                db.requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult delete()
        {
            var user = Session["user"] as user;
            var requests = (from r in db.requests
                            where r.restrurant.id == user.id && r.status == "Expired"
                            select r).ToList();
            foreach (var request in requests)
            {
                db.requests.Remove(request);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
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
        
        public static List<requestDTO> requestDTOs(List<request> requests)
        {
            var data = new List<requestDTO>();
            foreach (var request in requests)
            {
                data.Add(new requestDTO
                {
                    id = request.id,
                    weight = request.weight,
                    validity = request.validity,
                    start = request.start,
                    status = request.status,
                    collector = request.collector == null ? null : new collectorDTO
                    {
                        id = request.collector.id,
                        name = request.collector.name,
                        current_assigned = request.collector.current_assigned
                    },
                    restrurant = request.restrurant == null ? null : new restrurantDTO
                    {
                        id = request.restrurant.id,
                        name = request.restrurant.name,
                        location = request.restrurant.location
                    }
                });
            }
            return data;
        }
    }
}