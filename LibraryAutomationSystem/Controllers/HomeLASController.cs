using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
    public class HomeLASController : Controller
    {
        // GET: HomeLAS
        public ActionResult Home()
        {
            TempData["message"] = TempData["message"] as string;
            return View();
        }
    }
}