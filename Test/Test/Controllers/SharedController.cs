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

        //Представление для верификации
        [HttpGet]
        [Authorize]
        public ActionResult CreateRequest()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            return View();
        }

        //Запросить верификацию
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

    }
}
