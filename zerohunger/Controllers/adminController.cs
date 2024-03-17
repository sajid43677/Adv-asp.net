using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohunger.EF;
using zerohunger.DTOs;
using zerohunger.Models;

namespace zerohunger.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        ZeroHungerEntities db = new ZeroHungerEntities();
        [HttpGet]
        public ActionResult Index()
        {
            
            adminData adminData = fetch();
            return View(adminData);
        }

        [HttpPost]
        public ActionResult Index(int requestId,int collectorId)
        {
            var request = db.requests.FirstOrDefault(x => x.id == requestId);
            var collector = db.collectors.FirstOrDefault(x => x.id == collectorId);
            request.collector = collector;
            request.status = "Assigned";
            collector.current_assigned++;
            db.SaveChanges();
            adminData adminData = fetch();

            return View(adminData);
        }

        public static adminData fetch()
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var data = db.collectors.ToList();
            var dataDTO = Convert(data);
            var data1 = db.requests.ToList();
            adminData adminData = new adminData();
            adminData.collectors = dataDTO;
            adminData.requests = data1;
            return adminData;
        }

        
        public static List<collectorDTO> Convert(List<collector> collectors)
        {
            List<collectorDTO> collectorDTOs = new List<collectorDTO>();
            foreach (var collector in collectors)
            {
                collectorDTO collectorDTO = new collectorDTO();
                collectorDTO.id = collector.id;
                collectorDTO.name = collector.name;
                collectorDTO.current_assigned = collector.current_assigned;
                collectorDTOs.Add(collectorDTO);
            }
            return collectorDTOs;
        }

        
    }
}