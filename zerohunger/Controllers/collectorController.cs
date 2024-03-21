using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using zerohunger.Auth;
using zerohunger.DTOs;
using zerohunger.EF;

namespace zerohunger.Controllers
{
    [Access]
    public class collectorController : Controller
    {
        // GET: collector
        ZeroHungerEntities db = new ZeroHungerEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var user = Session["user"] as user;
            var data = fetch(user.id).OrderBy(x => x.validity);
            return View(data);

        }

        [HttpPost]
        public ActionResult Index(int requestId)
        {
            var user = Session["user"] as user;
            var request = db.requests.FirstOrDefault(x => x.id == requestId);
            var collector = db.collectors.FirstOrDefault(x => x.id == user.id);
            request.status = "claimed";
            collector.current_assigned--;
            db.SaveChanges();
            var data = fetch(user.id);
            return View(data);
        }

        public static List<requestDTO> fetch(int id)
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            
            var data = (from r in db.requests
                        where r.collector.id == id
                        select r).ToList();
            var data1 = new List<requestDTO>();
            foreach (var request in data)
            {
                data1.Add(new requestDTO
                {
                    id = request.id,
                    weight = request.weight,
                    validity = request.validity,
                    start = request.start,
                    status = request.status,
                    rid = request.rid,
                    cid = request.cid,
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
            return data1;
        }

        
    }
}