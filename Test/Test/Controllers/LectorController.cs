using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class LectorController : BaseController
    {
        //
        // GET: /Lector/

        //Дисциплины
        [HttpGet]
        [Authorize(Roles="Lector")]
        public ActionResult Disciplines()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            ModelContainer data = new ModelContainer();
            Result result = disciplineDAO.ReadAllDisciplines(x => (x.aspnet_Users.LoweredUserName == User.Identity.Name.ToLower()), data);
            return View(result.Value);
        }

        //Вюжка для Создания дисциплины
        [HttpGet]
        [Authorize(Roles="Lector")]
        public ActionResult CreateDisciplineView()
        {
            return View();
        }

        //Создать дисциплину
        [HttpPost]
        [Authorize(Roles="Lector")]
        public ActionResult CreateDiscipline(string Name)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new ModelContainer();
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            UserDAO userDAO = new UserDAO();
            IEnumerable<aspnet_Users> users = (IEnumerable<aspnet_Users>)userDAO.ReadAll(x => (x.LoweredUserName == User.Identity.Name.ToLower()), data).Value;
            Result result = disciplineDAO.CreateDiscipline(Name, users.First(x => (x.LoweredUserName == User.Identity.Name.ToLower())), data);
            return RedirectToAction("Disciplines", "Lector");
        
        }

        //Вьюжка для удаления дисциплины
        [HttpGet]
        [Authorize(Roles="Lector")]
        public ActionResult DeleteDisciplineView(string Name)
        {
            return View((object)Name);
        }

        //Удалить дисциплину
        [HttpPost]
        [Authorize(Roles="Lector")]
        public ActionResult DeleteDiscipline(string Name)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new ModelContainer();
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            UserDAO userDAO = new UserDAO();
            IEnumerable<aspnet_Users> users = (IEnumerable<aspnet_Users>)userDAO.ReadAll(x => (x.LoweredUserName == User.Identity.Name.ToLower()), data).Value;
            Result result = disciplineDAO.DeleteDiscipline(x => (x.DisciplineName == Name), data);
            return RedirectToAction("Disciplines", "Lector");
        }

        [HttpGet]
        [Authorize(Roles="Lector")]
        public ActionResult UpdateDisciplineView(string Name)
        {
            return View((object)Name);
        }

        //Обновить дисциплину
        [HttpPost]
        [Authorize(Roles="Lector")]
        public ActionResult UpdateDiscipline(string NewName, string OldName)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new ModelContainer();
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            disciplineDAO.RenameDiscipline(NewName, OldName, data);
            return RedirectToAction("Disciplines", "Lector");
        }

    }
}
