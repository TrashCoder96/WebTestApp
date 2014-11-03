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
            UserDAO userDAO = new UserDAO();
            List<User> users = (List<User>)userDAO.ReadAll().Value;
            Request req = new Request(users.Find(x => (x.Login == User.Identity.Name)), role, message);
            requestDAO.Insert(req);
            return RedirectToAction("Index", "Home");
        }





    }
}
