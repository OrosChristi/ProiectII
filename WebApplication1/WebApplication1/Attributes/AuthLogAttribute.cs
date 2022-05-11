using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Attributes
{
    public class AuthLogAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }
        private void IsUserAuthorized(AuthorizationContext filterContext)
        {
            
            if (filterContext.Result == null)
                return;
            
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
            }
        }
    }
}