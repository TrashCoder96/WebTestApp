using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class StudentController : BaseController
    {
        //
        // GET: /Student/

        [HttpGet]
        [Authorize(Roles="Student")]
        public ActionResult CreateStudentRequestView()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new ModelContainer();
            GroupDAO groupdao = new GroupDAO();
            Res result = groupdao.ReadAll(x => (true), data);
            if (result.Success)
            return View(result.Value);
             else return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult CreateStudentRequest(string GroupName)
        {
            ModelContainer data = new ModelContainer();
            StudentRequestDAO studentrequestdao = new StudentRequestDAO();
            UserDAO userdao = new UserDAO();
            GroupDAO groupdao = new GroupDAO();
            IEnumerable<aspnet_Users> users = (IEnumerable<aspnet_Users>)(userdao.ReadAll(x => (x.LoweredUserName == User.Identity.Name.ToLower()), data).Value);
            IEnumerable<Group> groups = (IEnumerable<Group>)(groupdao.ReadAll(x => (x.GroupName == GroupName), data).Value);
            Res result = studentrequestdao.CreateRequest(users.First(x => true), groups.First(x => true), data);
                return RedirectToAction("CreateStudentRequestView", "Student");
      
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult StudentRequests()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new Models.ModelContainer();
            StudentRequestDAO studentdao = new Models.StudentRequestDAO();
            Res result = studentdao.ReadAllStudentRequests(x => x.aspnet_Users.UserName == User.Identity.Name, data);
            if (result.Success)
                return View(result.Value);
            else return RedirectToAction("Errors", "Shared");
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Tests()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new Models.ModelContainer();
            GroupDAO gdao = new GroupDAO();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            UserDAO udao = new UserDAO();
            IEnumerable<aspnet_Users> users = (udao.ReadAll(x => x.LoweredUserName == User.Identity.Name.ToLower(), data).Value as IEnumerable<aspnet_Users>);
            IEnumerable<Group> groups = (gdao.ReadAll(x => x.aspnet_Users.Contains(users.First()), data).Value as IEnumerable<Group>);
            IEnumerable<Test.Models.Test> tests = (tdao.ReadTests(x => x.Groups.Contains(groups.First()), data).Value as IEnumerable<Models.Test>);
            return View(tests);
        }


        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Begin(string TestId)
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            Res r = tdao.ReadTests(test => test.TestId.ToString() == TestId, data);
            if (r.Success)
            {
                Test.Models.Test test = (r.Value as IEnumerable<Test.Models.Test>).First();
                //полностью клонируем его и суём в сессию
                Test.Models.Test test1 = data.Tests.Create();
                test1.TestId = test.TestId;
                test1.Name = test.Name;
                foreach (Quastion q in test.Quastions)
                {
                    Quastion q1 = data.Quastions.Create();
                    q1.Text = q.Text;
                    q1.QuastionId = q.QuastionId;
                    test1.Quastions.Add(q1);

                    foreach (Variant v in q.Variants)
                    {
                        Variant v1 = data.Variants.Create();
                        q1.Variants.Add(v1);
                        v1.Text = v.Text;
                        v1.VariantId = v.VariantId;
                        v1.IsValid = false;
                    }
                }
                Session["test"] = test1;
                return RedirectToAction("Test", "Student");
            }
            else
                return RedirectToAction("Errors", "Shared");
        }

        //тест
        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Test()
        {
            ViewData["links"] = getLinks();
            ViewData["functions"] = getFunctions();
            return View(Session["test"]);

        }

       
        //редактировать ответ
        [HttpGet]
        [Authorize(Roles = "Student")]
        
        public ActionResult ChangeVariant(string VariantId, bool newisValid)
        {
            foreach (Quastion q in (Session["test"] as Models.Test).Quastions)
            {
                IEnumerable<Variant> var = q.Variants.Select(row => row).Where(x => x.VariantId.ToString() == VariantId);
                int n = var.Count();
                if (n > 0)
                var.First().IsValid = !newisValid;
            }
                return RedirectToAction("Test", "Student");
        }

        //отправить тест на проверку
        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult SendTest()
        {
            ModelContainer data = new ModelContainer();
            Test.Models.DAO.TestDAO tdao = new Models.DAO.TestDAO();
            UserDAO udao = new UserDAO();
            IEnumerable<aspnet_Users> users = (udao.ReadAll(x => x.LoweredUserName == User.Identity.Name.ToLower(), data).Value as IEnumerable<aspnet_Users>);
            Res r = tdao.Check((Session["test"] as Test.Models.Test), data, users.First());
            return View(r.Value);
        }

        




    }
}
