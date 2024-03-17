using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohunger.EF;

namespace zerohunger.Auth
{
    public class Access : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.Session["user"] as user;
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}