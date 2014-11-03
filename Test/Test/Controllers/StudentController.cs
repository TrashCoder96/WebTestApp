using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class StudentController : BaseController
    {
        //
        // GET: /Student/

        
        public ActionResult CreateRequest()
        {
            return View();
        }

    }
}
