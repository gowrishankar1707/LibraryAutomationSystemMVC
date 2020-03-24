using System;
using System.Collections.Generic;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.BL;
using LibraryAutomationSystem.Models;

using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Web.Security;

namespace LibraryAutomationSystem.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        UserRepository repository = new UserRepository();


        [ActionName("Login")]
        [OutputCache(CacheProfile = "1MinuteCache")]
        public ActionResult Login_Get()//Return the Get Request of Login
        {
            return View();
        }
        [ActionName("Register")]
        [OutputCache(CacheProfile = "1MinuteCache")]
        public ActionResult Register_Get()//Get Request register
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]//Post Method of Register

        public ActionResult Register_Post(UserModel user)//Post Register method
        {
            if (ModelState.IsValid)
            {
                User userInput = new User                            //Manual Mapping the Register Model and User Entity
                {
                    MemberName = user.MemberName,
                    MemberUserName = user.MemberUserName,
                    MemberPassword = user.MemberPassword,
                    MemberDOB = user.MemberDOB,
                    MemberDOJ = user.MemberDOJ,
                    MemberSex = user.MemberSex,
                    MemberAddress = user.MemberAddress,
                    Email = user.Email,
                    MemberPhoneNumber = Int64.Parse(user.MemberPhoneNumber),
                    Role = Role.user.ToString(),
                    BookRequest=3,
                };


                AccountBL.AddUser(userInput);
                TempData["message"] = "Registered successfully";
                return RedirectToAction("Home","HomeLAS");
            }
            return View();
        }

        [HttpPost]
        [ActionName("Login")]//Post Method of Login
        public ActionResult Login_Post(Login login)
        {
            if (ModelState.IsValid)
            {
                User user= AutoMapper.Mapper.Map<Models.Login, Entity.User>(login);//Automapping the Login Model and User Entity
                //User user = new User
                //{
                //    MemberUserName = login.userName,
                //    MemberPassword = login.password,                 //Manual Mapping for Login Model and User Entity

                //};
                User checkUser = AccountBL.CheckUser(user);//CheckUser is "Admin" Or "User"
                FormsAuthentication.SetAuthCookie(checkUser.MemberUserName, false);
                var authTicket = new FormsAuthenticationTicket(1, checkUser.MemberUserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, checkUser.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                if (checkUser.Role == "admin")//"True" if the  logined user is "Admin"
                {
                    TempData["admin"] = checkUser;
                    TempData["Login"] = "Admin";
                    return RedirectToAction("AdminChoice", "Admin");

                }
                else if (checkUser.Role == "user")//"True" if the Logined user is "User"
                {
                    TempData["User"] = checkUser;
                    TempData["Login"] = user;
                  
                    return RedirectToAction("");
                }
                else                               //If the username or password is does'nt match it will execute
                {
                    TempData["login"] = "UserName or Password incorrect";
                    return View();
                }

            }
            return View();
        }
     
    }
}