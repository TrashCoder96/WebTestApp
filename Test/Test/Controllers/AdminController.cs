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
        //Запросы
        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult Requests()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            RequestDAO requestdao = new RequestDAO();
            return View(requestdao.ReadAllRequests(x => (true)).Value);
        }

        //Отклонить запрос
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Reject(string User, string Role)
        {
            RequestDAO requestdao = new RequestDAO();
            requestdao.RejectRequest(x => (x.Role == Role && x.User.Login == User));
            return RedirectToAction("Requests", "Admin");
        }

        //Принять запрос
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Accept(string User, string Role)
        {
            RequestDAO requestdao = new RequestDAO();
            requestdao.SatisfyRequest(x => (x.Role == Role && x.User.Login == User));
            return RedirectToAction("Requests", "Admin");
        }


        //Группы
        [HttpGet]
        [Authorize]
        public ActionResult Groups()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            GroupDAO groupDAO = new GroupDAO();
            return View(groupDAO.ReadAll(x => (true)).Value);
        }


        //Вюжка для создания
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGroup()
        {
            return View();
        }

        //Создать группу
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGroup(string Name)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            GroupDAO groupDAO = new GroupDAO();
            groupDAO.CreateGroup(Name);
            return RedirectToAction("Groups", "Admin");
        }

        //Вьюжка для удаления
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteGroupView(string Name)
        {
            return View((object)Name);
        }

        //Удалить группу
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteGroup(string Name)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            GroupDAO groupDAO = new GroupDAO();
            groupDAO.DeleteGroup(x => (x.Name == Name));
            return RedirectToAction("Groups", "Admin");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateGroupView(string Name)
        {
            return View((object)Name);
        }

        //Обновить группу
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateGroup(string NewName, string OldName)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            GroupDAO groupDAO = new GroupDAO();
            groupDAO.UpdateGroup(NewName, OldName);
            return RedirectToAction("Groups", "Admin");
        }
    }
}
