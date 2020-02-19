using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
    public class LibraryAutomationSystemController : Controller
    {
        // GET: LibraryUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegistrationUser()
        {
            return View();
        }
        public ActionResult LoginUser()
        {
            return View();
        }
    }
}