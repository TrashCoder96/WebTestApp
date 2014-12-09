using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary2;

namespace Test.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            return View();
        }
    }
}
