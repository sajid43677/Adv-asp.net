using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using zerohunger.Auth;
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

        public static List<request> fetch(int id)
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            
            var data = (from r in db.requests
                        where r.collector.id == id
                        select r).ToList();
            return data;
        }

        
    }
}