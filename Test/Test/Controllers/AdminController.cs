using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/

        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult Requests()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            RequestDAO requestdao = new RequestDAO();
            List<Request> requests = (List<Request>)requestdao.ReadAll().Value;
            ViewData["requests"] = requests;
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Reject(string User, string Role)
        {
            RequestDAO requestdao = new RequestDAO();
            requestdao.Delete(User, Role);
            return RedirectToAction("Requests", "Admin");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Accept(Request req)
        {
            return View();
        }

    }
}
