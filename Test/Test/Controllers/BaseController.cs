using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class BaseController : Controller
    {
        protected List<Models.Link> getLinks()
        {
            List<Models.Link> links = new List<Models.Link>();
            if (!User.Identity.IsAuthenticated)
            {
                links.Add(new Models.Link("Login", "Auth", "Войти"));
                links.Add(new Models.Link("Registration", "Auth", "Зарегистрироваться"));
            }
            else
            {
                links.Add(new Models.Link("LogOut", "Auth", "Выйти"));
            }
            return links;
        }

        protected List<Models.Link> getFunctions()
        {
            List<Models.Link> links = new List<Models.Link>();
            if (User.Identity.IsAuthenticated)
            {
                links.Add(new Models.Link("CreateRequest", "Shared", "Запросить верификацию"));
            }
            if(User.IsInRole("Admin"))
            {
                links.Add(new Models.Link("Requests", "Admin", "Управление запросами"));
                links.Add(new Models.Link("Groups", "Admin", "Управление группами"));
                links.Add(new Models.Link("Tests", "Admin", "Управление тестами"));
            }
            if (User.IsInRole("Lector"))
            {
                links.Add(new Models.Link("Tests", "Lector", "Управление тестами"));

            }
            if (User.IsInRole("Student"))
            {
                links.Add(new Models.Link("Take", "Student", "Пройти тест"));
                links.Add(new Models.Link("Take", "Student", "Пройти тест"));

            }
            return links;
        }
    }
}
