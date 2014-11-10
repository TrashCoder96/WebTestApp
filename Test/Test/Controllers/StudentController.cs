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
            Result result = groupdao.ReadAll(x => (true), data);
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
            Result result = studentrequestdao.CreateRequest(users.First(x => true), groups.First(x => true), data);

                return RedirectToAction("CreateStudentRequestView", "Student");
      
        }

    }
}
