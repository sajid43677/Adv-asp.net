using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zerohunger.DTOs
{
    public class requestDTO
    {
        public int id { get; set; }
        public double weight { get; set; }
        public System.DateTime validity { get; set; }
        public System.DateTime start { get; set; }
        public string status { get; set; }
        public int rid { get; set; }
        public int cid { get; set; }
    }
}