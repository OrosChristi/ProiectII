using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        private Business _business;
        public Business Business
        {
            get
            {
                if (_business == null)
                {
                    _business = new Business();
                }

                return _business;
            }
        }
    }
}