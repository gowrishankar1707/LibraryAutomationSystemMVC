using System;
using System.Collections.Generic;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.DAL;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admn
        UserRepository repository = new UserRepository();
        public ActionResult ManageUser()
        {
            IEnumerable<User> user = repository.GetUser();
            ViewData["user"] = user;
            ViewBag.user = user;
            TempData["user"] = user;
            return View();
        }
       public ActionResult Category()
        {
            ViewBag.Category = repository.GetCategory();
            TempData["Category"] = repository.GetCategory();
            return View();
        }
        [HttpGet]
        [ActionName("Create_Category")]
        public ActionResult Create_Category_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create_Category")]
        public ActionResult Create_Category_Post()
        {

            return RedirectToAction("Category");
        }
    }
}