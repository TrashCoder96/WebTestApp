using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class SharedController : BaseController
    {
        //
        // GET: /Shared/

        
        [HttpGet]
        [Authorize]
        public ActionResult CreateRequest()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
           
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateRequest(string message, string role)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            RequestDAO requestDAO = new RequestDAO();
            requestDAO.CreateRequest(User.Identity.Name, role, message);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Groups()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();

            return View();
        }

       





    }
}
