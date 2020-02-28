using System;
using System.Collections.Generic;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.DAL;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace LibraryAutomationSystem.Controllers
{
    public class LibraryAutomationSystemController : Controller
    {
        UserRepository repository = new UserRepository();
        // GET: LibraryUser
        public ActionResult ViewUser()
        {
            IEnumerable<User> user = repository.GetUser();
            ViewData["user"] = user;
            ViewBag.user = user;
            TempData["user"] = user;
            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }
        [ActionName("Register")]
        public ActionResult Register_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register_Post(User user)
        {
            if(ModelState.IsValid)
            {
                User userInput = new User
                {
                    memberName = user.memberName,
                    memberUserName = user.memberUserName,
                    memberPassword = user.memberPassword,
                    memberDOB = user.memberDOB,
                    memberDOJ=user.memberDOJ,
                    memberSex=user.memberSex,
                    memberAddress=user.memberAddress,
                    e_Mail=user.e_Mail,
                    memberPhoneNumber=user.memberPhoneNumber
                };
                

                repository.AddUser(userInput);
                return RedirectToAction("ViewUser");
            }
            return View();
        }
        public ActionResult Edit()
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                UpdateModel(user);
            }
            return View();
        }
    }
}