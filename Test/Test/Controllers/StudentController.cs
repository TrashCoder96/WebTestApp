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
            ModelContainer data = new Models.ModelContainer();
            
            Group group = data.Groups.Select(g => g).Where(gr => gr.aspnet_Users.FirstOrDefault(u => u.UserName.ToLower() == User.Identity.Name.ToLower()) != null).First();
            IEnumerable<Models.Test> tests = data.Tests.Select(t => t).Where(t => t.Groups.Contains(group));
            int te = tests.Count();
            return View(tests);
        }

    }
}
