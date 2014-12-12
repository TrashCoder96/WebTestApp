using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary2;

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
                links.Add(new Models.Link("Requests", "Shared", "Ваши запросы"));
            }
            if(User.IsInRole("Admin"))
            {
                links.Add(new Models.Link("Requests", "Admin", "Управление запросами"));
                links.Add(new Models.Link("Groups", "Admin", "Управление группами"));
                links.Add(new Models.Link("StudentRequests", "Admin", "Управление запросами на вступление в группы"));
            }
            if (User.IsInRole("Lector"))
            {
                links.Add(new Models.Link("GetStatistics", "Lector", "Статистика"));
                links.Add(new Models.Link("Disciplines", "Lector", "Управление дисциплинами"));
                links.Add(new Models.Link("Tests", "Lector", "Управление тестами"));
                links.Add(new Models.Link("GroupsAndTests", "Lector", "Связать группы и тесты"));
            }
            if (User.IsInRole("Student"))
            {
                links.Add(new Models.Link("Tests", "Student", "Пройти тест"));
                links.Add(new Models.Link("CreateStudentRequestView", "Student", "Запрос на вступление в группу"));
                links.Add(new Models.Link("StudentRequests", "Student", "Ваши запросы на вступление в группу"));

            }

            return links;
        }
    }
}
