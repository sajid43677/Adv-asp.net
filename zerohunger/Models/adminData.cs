using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zerohunger.EF;
using zerohunger.DTOs;

namespace zerohunger.Models
{
    public class adminData
    {
      
        public List<requestDTO> requests { get; set; }
        public List<collectorDTO> collectors { get; set; }

    }
}