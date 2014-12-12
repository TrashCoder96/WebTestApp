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
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            DisciplineDAO disciplineDAO = new DisciplineDAO();
            ModelContainer data = new ModelContainer();
            Res r = tdao.ReadTests(test => (disciplineDAO.ReadAllDisciplines(d => d.aspnet_Users.LoweredUserName == User.Identity.Name.ToLower(), data).Value as IEnumerable<Discipline>).Contains(test.Discipline), data);
            Res result = disciplineDAO.ReadAllDisciplines(x => (x.aspnet_Users.LoweredUserName == User.Identity.Name.ToLower()), data);
            return View(new object[] {r.Value, result.Value, data.Groups});
        }

        //тест
        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult Test(string TestId)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r = tdao.ReadTests(test => test.TestId.ToString() == TestId, data);
            if (r.Success)
            {
                Models.Test test = (r.Value as IEnumerable<Test.Models.Test>).First();
                return View(test);
            }
            else
                return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult DeleteTest(string TestId)
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r = tdao.DeleteTests(test => test.TestId.ToString() == TestId, data);
            if (r.Success)
            {
                return RedirectToAction("Tests", "Lector");
            }
            else
                return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult CreateTest(string TestName, string DisciplineId)
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Test.Models.DisciplineDAO ddao = new DisciplineDAO();
            Res r1 = ddao.ReadAllDisciplines(disciline => disciline.DisciplineId.ToString() == DisciplineId, data);
            if (r1.Success)
            {
                Res r2 = tdao.CreateTests(TestName, (r1.Value as IEnumerable<Test.Models.Discipline>).First(), data);
                if (r2.Success)
                {
                    return RedirectToAction("Tests", "Lector");
                }
                else
                    return RedirectToAction("Errors", "Shared");
            }
            else
                return RedirectToAction("Errors", "Shared");
           
        }

        //вопрос
        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult Question(string QuestionId)
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r = tdao.ReadQuastions(quastion => quastion.QuastionId.ToString() == QuestionId, data);
            if (r.Success)
            {
                Models.Quastion quastion = (r.Value as IEnumerable<Test.Models.Quastion>).First();
                return View(quastion);
            }
            else
                return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult CreateQuestion(string TestId, string QuestionText)
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r1 = tdao.ReadTests(test => test.TestId.ToString() == TestId, data);
            if (r1.Success)
            {
                Res r2 = tdao.CreateQuastion((r1.Value as IEnumerable<Test.Models.Test>).First(), QuestionText, data);
                if (r2.Success)
                {
                    return RedirectToAction("Test", "Lector", new { TestId  = TestId });
                }
                else
                    return RedirectToAction("Errors", "Shared");
            }
            else
                return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult DeleteQuestion(string QuestionId)
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r0 = tdao.ReadQuastions(question => question.QuastionId.ToString() == QuestionId, data);
            string TestId = "";
            if (r0.Success)
            {
                TestId = (r0.Value as IEnumerable<Models.Quastion>).First().Test_TestId.ToString();
            }
            Res r1 = tdao.DeleteQuastions(question => question.QuastionId.ToString() == QuestionId, data);
            if (r1.Success && r0.Success)
            {
                
                return RedirectToAction("Test", "Lector", new { TestId = TestId });
            }
            else
                return RedirectToAction("Errors", "Shared");
        }

        //Вариант ответа
        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult Variant(string VariantId)
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r = tdao.ReadVariants(variant => variant.VariantId.ToString() == VariantId, data);
            if (r.Success)
            {
                Models.Variant variant = (r.Value as IEnumerable<Test.Models.Variant>).First();
                return View((r.Value as IEnumerable<Test.Models.Variant>).First());
            }
            else
                return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult CreateVariant(string QuestionId, string VariantText, bool isValid)
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r0 = tdao.ReadQuastions(question => question.QuastionId.ToString() == QuestionId, data);
            Models.Quastion q = null;
            if (r0.Success)
            {
                q = (r0.Value as IEnumerable<Test.Models.Quastion>).First();
            }
            Res r = tdao.CreateVariant(q, VariantText, isValid, data);
            if (r.Success && r0.Success)
            {
                return RedirectToAction("Test", "Lector", new { TestId = q.Test_TestId });
            }
            else
                return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult DeleteVariant(string VariantId)
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r0 = tdao.ReadVariants(variant => variant.VariantId.ToString() == VariantId, data);
            Models.Variant v = null;
            string TestId = "";
            if (r0.Success)
            {
                v = (r0.Value as IEnumerable<Test.Models.Variant>).First();
                TestId = v.Quastion.Test_TestId.ToString();
            }
            Res r = tdao.DeleteVariant(variant => variant.VariantId.ToString() == VariantId, data);
            if (r.Success && r0.Success)
            {
                return RedirectToAction("Test", "Lector", new { TestId = TestId });
            }
            else
                return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult BindGroupAndTest(string TestId, string GroupId)
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Test.Models.GroupDAO gdao = new GroupDAO();

            Group g = (gdao.ReadAll(x => x.GroupId.ToString() == GroupId, data).Value as IEnumerable<Group>).First();
            Models.Test t = (tdao.ReadTests(x => x.TestId.ToString() == TestId, data).Value as IEnumerable<Models.Test>).First();

            tdao.Bind(t, g, data);

            return RedirectToAction("GroupsAndTests", "Lector");

        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult GroupsAndTests()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Test.Models.GroupDAO gdao = new GroupDAO();
            Res rt = tdao.ReadTests(test => test.Discipline.aspnet_Users.LoweredUserName == User.Identity.Name.ToLower(), data);
            Res gr = gdao.ReadAll(group => true, data);
            return View(new object[] { rt.Value , gr.Value });
            
        }

        [HttpGet]
        [Authorize(Roles = "Lector")]
        public ActionResult GetStatistics()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new ModelContainer();
            UserDAO udao = new UserDAO();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            IEnumerable<aspnet_Users> users = (udao.ReadAll(x => x.LoweredUserName == User.Identity.Name.ToLower(), data).Value as IEnumerable<aspnet_Users>);
            IEnumerable<Test.Models.Test> tests = (tdao.ReadTests(test => test.Discipline.aspnet_Users_UserId == users.First().UserId, data).Value as IEnumerable<Test.Models.Test>);
            Object results = (tdao.ReadAllResults(result => tests.Contains(result.Test), data)).Value;
            return View(results);

        }



      

    }
}
