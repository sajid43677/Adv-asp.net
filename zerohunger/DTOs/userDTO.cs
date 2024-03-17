using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zerohunger.DTOs
{
    public class userDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string role { get; set; }
    }
}