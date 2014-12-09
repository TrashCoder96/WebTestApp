using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Test.Controllers
{
    public class AuthController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registration()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registration(string firstname, string lastname, string login, string password, string repeat, string email)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            if (!Membership.ValidateUser(login, password) && password == repeat)
            {
                Membership.CreateUser(login, password, email);
                FormsAuthentication.SetAuthCookie(login, true);
                return RedirectToAction("Index", "Home");
            }
            else
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult LogOut()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string username, string password)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(username, password))
                {
                    FormsAuthentication.SetAuthCookie(username, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View();
        }

    }
}
