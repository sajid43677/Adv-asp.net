using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohunger.EF;

namespace zerohunger.Auth
{
    public class AdminAccess: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.Session["user"] as user;
            if (user != null && user.role == "admin")
            {
                return true;
            }
            return false;
        }
    }
}