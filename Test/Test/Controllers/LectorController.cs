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
            disciplineDAO.ReadAllDisciplines(x => (x.Lector.Login == User.Identity.Name));
            return View(disciplineDAO.ReadAllDisciplines(x => (x.Lector.Login.ToLower() == User.Identity.Name.ToLower())).Value);
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
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            disciplineDAO.CreateDiscipline(Name, User.Identity.Name);
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
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            disciplineDAO.DeleteDiscipline(x => (x.Name == Name));
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
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            disciplineDAO.RenameDiscipline(NewName, OldName);
            return RedirectToAction("Discipline", "Lector");
        }

    }
}
