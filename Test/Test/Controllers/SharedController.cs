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
            UserDAO userdao = new UserDAO();
            Test.Models.ModelContainer data = new ModelContainer();
            IEnumerable<aspnet_Users> users = (IEnumerable<aspnet_Users>)userdao.ReadAll(x => (x.LoweredUserName == User.Identity.Name.ToLower()), data).Value;
            aspnet_Users user = users.First(x => true);
            requestDAO.CreateRequest(user , role, message, data);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Errors()
        {
            return View();
        }

    }
}
