using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using System.Web.Security;

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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Accept(string User, string Role)
        {
            RequestDAO requestdao = new RequestDAO();
            Roles.AddUserToRole(User, Role);
            requestdao.Delete(User, Role);
            return RedirectToAction("Requests", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Groups()
        {

            return View();
        }
    }
}
