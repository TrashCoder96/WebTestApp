﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using System.Web.Security;
using Test.Models;

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
            ModelContainer data = new Models.ModelContainer();
            RequestDAO requestdao = new RequestDAO();
            Result result = requestdao.ReadAllRequests(x => (true), data);
            if (result.Success)
                return View(result.Value);
            else return RedirectToAction("Errors", "Shared");

        }

        //Отклонить запрос
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Reject(string UserLogin, string Role)
        {
            RequestDAO requestdao = new RequestDAO();
            ModelContainer data = new Models.ModelContainer();
            Result result = requestdao.RejectRequest(x => (x.aspnet_Users.LoweredUserName == UserLogin.ToLower() && x.aspnet_Roles.RoleName == Role), data);
            if (result.Success)
                return RedirectToAction("Requests", "Admin"); 
            else return RedirectToAction("Errors", "Shared");
        }

        //Принять запрос
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Accept(string UserLogin, string Role)
        {
            RequestDAO requestdao = new RequestDAO();
            ModelContainer data = new Models.ModelContainer();
            Result result = requestdao.SatisfyRequest(x => (x.aspnet_Users.LoweredUserName == UserLogin.ToLower() && x.aspnet_Roles.RoleName == Role), data);
            if (result.Success)
                return RedirectToAction("Requests", "Admin");
            else return RedirectToAction("Errors", "Shared");
        }


        //Группы
        [HttpGet]
        [Authorize]
        public ActionResult Groups()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            GroupDAO groupdao = new GroupDAO();
            ModelContainer data = new Models.ModelContainer();
            Result result = groupdao.ReadAll(x => (true), data);
            if (result.Success)
                return View(result.Value);
            else return RedirectToAction("Errors", "Shared");
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
        public ActionResult CreateGroup(string GroupName)
        {
            GroupDAO groupDAO = new GroupDAO();
            ModelContainer data = new Models.ModelContainer();
            Result result = groupDAO.CreateGroup(GroupName, data);
            if (result.Success)
                return RedirectToAction("Groups", "Admin");
            else return RedirectToAction("Errors", "Shared");
        }

        //Вьюжка для удаления
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteGroupView(string GroupName)
        {
            return View((object)GroupName);
        }

        //Удалить группу
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteGroup(string GroupName)
        {
            GroupDAO groupDAO = new GroupDAO();
            ModelContainer data = new Models.ModelContainer();
            Result result = groupDAO.DeleteGroup(x => (x.GroupName == GroupName), data);
            if (result.Success)
                return RedirectToAction("Groups", "Admin");
            else return RedirectToAction("Errors", "Shared");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateGroupView(string GroupName)
        {
            return View((object)GroupName);
        }

        //Обновить группу
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateGroup(string NewGroupName, string OldGroupName)
        {
            GroupDAO groupDAO = new GroupDAO();
            ModelContainer data = new Models.ModelContainer();
            Result result = groupDAO.UpdateGroup(NewGroupName, OldGroupName, data);
            if (result.Success)
                return RedirectToAction("Groups", "Admin");
            else return RedirectToAction("Errors", "Shared");
        }


        //Запросы студентов
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult StudentRequests()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new Models.ModelContainer();
            StudentRequestDAO studentdao = new Models.StudentRequestDAO();
            Result result = studentdao.ReadAllStudentRequests(x => true, data);
            if (result.Success)
                return View(result.Value);
            else return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AcceptStudentRequest(string UserLogin, string GroupName)
        {
            ModelContainer data = new Models.ModelContainer();
            StudentRequestDAO studentdao = new Models.StudentRequestDAO();
            Result result = studentdao.SatisfyRequest(x => (x.aspnet_Users.LoweredUserName == UserLogin.ToLower() && x.Group.GroupName == GroupName), data);
            if (result.Success)
                return RedirectToAction("Groups", "Admin");
            else return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult RejectStudentRequest(string UserLogin, string GroupName)
        {
            ModelContainer data = new Models.ModelContainer();
            StudentRequestDAO studentdao = new Models.StudentRequestDAO();
            Result result = studentdao.RejectRequest(x => (x.aspnet_Users.LoweredUserName == UserLogin.ToLower() && x.Group.GroupName == GroupName), data);
            if (result.Success)
                return RedirectToAction("Groups", "Admin");
            else return RedirectToAction("Errors", "Shared");
        }
    }
}
