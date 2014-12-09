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
            Res result = disciplineDAO.ReadAllDisciplines(x => (x.aspnet_Users.LoweredUserName == User.Identity.Name.ToLower()), data);
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
            Res result = disciplineDAO.CreateDiscipline(Name, users.First(x => (x.LoweredUserName == User.Identity.Name.ToLower())), data);
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
            Res result = disciplineDAO.DeleteDiscipline(x => (x.DisciplineName == Name), data);
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

        //список всех тестов
        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult Tests()
        {
            Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            ModelContainer data = new ModelContainer();
            Res r = tdao.ReadTests(test => (disciplineDAO.ReadAllDisciplines(d => d.aspnet_Users.LoweredUserName == User.Identity.Name.ToLower(), data).Value as IEnumerable<Discipline>).Contains(test.Discipline), data);
            Res result = disciplineDAO.ReadAllDisciplines(x => (x.aspnet_Users.LoweredUserName == User.Identity.Name.ToLower()), data);
            return View(new object[] {r.Value, result.Value, data.Groups});
        }

        //Создать тест
        [HttpPost]
        [Authorize(Roles = "Lector")]
        public ActionResult CreateTest(string TestName, string DisciplineId, string GroupId)
        {
             Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
             DisciplineDAO disciplineDAO = new DisciplineDAO();
             ModelContainer data = new ModelContainer();
             Res r = tdao.CreateTests(TestName, (disciplineDAO.ReadAllDisciplines(d => d.DisciplineId.ToString() == DisciplineId, data).Value as IEnumerable<Discipline>).First(), GroupId, data);
             return RedirectToAction("Tests", "Lector");
        }

        //Полностью удалить тест
        [HttpPost]
        [Authorize(Roles = "Lector")]
        public ActionResult DeleteTest(string TestId)
        {
            Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            ModelContainer data = new ModelContainer();
            Res r = tdao.DeleteTests(t => t.TestId.ToString() == TestId, data);
            return RedirectToAction("Tests", "Lector");
        }

        //выбрать конкретный тест
        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult Test(string TestId)
        {
            Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            ModelContainer data = new ModelContainer();
            Models.Test test = (tdao.ReadTests(t => t.TestId.ToString() == TestId, data).Value as IEnumerable<Models.Test>).First();
            return View(test);
        }

        [HttpPost]
        [Authorize(Roles = "Lector")]
        public ActionResult CreateQuastion(string QuastionText, string TestId)
        {
            ModelContainer data = new ModelContainer();
            Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r = tdao.CreateQuastion((tdao.ReadTests(t => t.TestId.ToString() == TestId, data).Value as IEnumerable<Models.Test>).First(), QuastionText, data);
            return RedirectToAction("Test", "Lector", new { TestId });
        }


        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult Variants(string QuastionId, string TestId)
        {
            ModelContainer data = new ModelContainer();
            Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            IEnumerable<Models.Variant> vs = (tdao.ReadTests(t => t.TestId.ToString() == TestId, data).Value as IEnumerable<Models.Test>).First<Models.Test>().Quastions.First(q => q.QuastionId.ToString() == QuastionId).Variants;
            return View(new object[] {vs, (tdao.ReadTests(t => t.TestId.ToString() == TestId, data).Value as IEnumerable<Models.Test>).First<Models.Test>().Quastions.First(q => q.QuastionId.ToString() == QuastionId)});
        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult CreateVariant(string QuastionId, string VariantText)
        {
            ModelContainer data = new ModelContainer();
            Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Quastion q = (tdao.ReadQuastions(x => x.QuastionId.ToString() == QuastionId, data).Value as IEnumerable<Quastion>).First();
            tdao.CreateVariant(q, VariantText, false, data);
            return RedirectToAction("Variants","Lector", new {q.QuastionId, TestId = q.Test_TestId});
        }

        public ActionResult UpdateVariant(string VariantId, string Text,bool isValid)
        {
            ModelContainer data = new ModelContainer();
            Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Variant v = (tdao.ReadVariants(x => x.VariantId.ToString() == VariantId, data).Value as IEnumerable<Variant>).First();
            tdao.ChangeVariant(x => x.VariantId.ToString() == VariantId, Text, isValid, data);
            return RedirectToAction("Variants", "Lector", new { QuastionId = v.Quastion_QuastionId, TestId = v.Quastion.Test_TestId });
        }

        public ActionResult DeleteVariant(string VariantId)
        {
            ModelContainer data = new ModelContainer();
            Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Variant v = (tdao.ReadVariants(x => x.VariantId.ToString() == VariantId, data).Value as IEnumerable<Variant>).First();
            string TestId = v.Quastion.Test_TestId.ToString();
            tdao.DeleteVariant(x => x.VariantId.ToString() == VariantId, data);
            return RedirectToAction("Variants", "Lector", new { QuastionId = v.Quastion_QuastionId, TestId = TestId });
        }

    }
}
