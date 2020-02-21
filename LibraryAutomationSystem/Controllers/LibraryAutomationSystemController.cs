using System;
using System.Collections.Generic;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.DAL;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
    public class LibraryAutomationSystemController : Controller
    {
        UserRepository userRepository;
        // GET: LibraryUser
        public ActionResult ViewUser()
        {
            IEnumerable<User> user = UserRepository.GetUser();
            ViewData["user"] = user;
            ViewBag.user = user;
            TempData["user"] = user;
            return View();
        }
 [HttpGet]
        [ActionName("RegistrationUser")]
        public ActionResult RegistrationUser_Get()
        {
            return View();
        }
   [HttpPost]
        [ActionName("RegistrationUser")]
     
        public ActionResult RegistrationUser_post()
        {
            User user = new User();
            TryUpdateModel(user);
            if (ModelState.IsValid)
            {
                
                userRepository.AddUser(user);
                return RedirectToAction("ViewUser");

            }
            return View();

        }
        public ActionResult LoginUser()
        {
            return View();
        }
        public ActionResult Edit()
        {
            if(ModelState.IsValid)
            {
                User user = new User();
                UpdateModel(user);
            }
            return View();
        }
    }
}