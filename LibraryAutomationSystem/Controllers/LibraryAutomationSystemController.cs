using System;
using System.Collections.Generic;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Models;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace LibraryAutomationSystem.Controllers
{
    public class LibraryAutomationSystemController : Controller
    {
        UserRepository repository = new UserRepository();
        // GET: LibraryUser
        //public ActionResult ViewUser()//View the database to list
        //{
        //    IEnumerable<User> user = repository.GetUser();
        //    ViewData["user"] = user;
        //    ViewBag.user = user;
        //    TempData["user"] = user;
        //    return View();
        //}
        [ActionName("Login")]
        public ActionResult Login_Get()
        {
            return View();
        }
        [ActionName("Register")]
        public ActionResult Register_Get()//Get Request register
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]

        public ActionResult Register_Post(UserModel user)//Post Register method
        {
            if (ModelState.IsValid)
            {
                User userInput = new User
                {
                    memberName = user.memberName,
                    memberUserName = user.memberUserName,
                    memberPassword = user.memberPassword,
                    memberDOB = user.memberDOB,
                    memberDOJ = user.memberDOJ,
                    memberSex = user.memberSex,
                    memberAddress = user.memberAddress,
                    e_Mail = user.e_Mail,
                    memberPhoneNumber = Int64.Parse(user.memberPhoneNumber),
                    role = "user",

                };


                repository.AddUser(userInput);
                TempData["message"] = "Registered successfully";
                return RedirectToAction("");
            }
            return View();
        }
        
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_Post(Login login)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    memberUserName = login.userName,
                    memberPassword = login.password,

                };
                User checkUser = repository.CheckLogin(user);
                if (checkUser.role == "admin")
                {
                    TempData["admin"] = user;
                    TempData["Login"] = "Admin";
                    return RedirectToAction("AdminChoice","Admin");
                
                }
                else if (checkUser.role == "user")
                {
                    TempData["Login"] = user;
                    TempData["User"] = checkUser;
                    return RedirectToAction("");
                }
                else
                {
                    TempData["login"] = "UserName or Password incorrect";
                    return View();
                }
                
            }
            return View();
        }
        public ActionResult Edit(string userName)
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