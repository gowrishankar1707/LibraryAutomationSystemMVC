/*
 * 
 */

using System;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.BL;
using LibraryAutomationSystem.Models;
using LibraryAutomationSystem.Common;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryAutomationSystem.Controllers
{
    public class AccountController : Controller
    {
        IAccountBL accountBL;
        public AccountController()
        {
            accountBL = new AccountBL();
        }
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
        [ValidateAntiForgeryToken]
        public ActionResult Register_Post(RegistrationModel user)//Post Register method
        {
            if (ModelState.IsValid)
            {

                User userInput = AutoMapper.Mapper.Map<RegistrationModel, User>(user);
                userInput.Role = Role.user.ToString();
                userInput.BookRequest =LibraryAutomationSystem.Common.StaticInformation. bookRequest;
                int result = accountBL.AddUser(userInput);
                if (result >= 1)
                {
                    return RedirectToAction("Home", "HomeLAS");
                }
                return View();
            }
            return View();
        }
        //[HttpPost]
        ////[ActionName("Login")]//Post Method of Login 
        //[ValidateAntiForgeryToken]
        [HttpPost]


        [ActionName("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult Validate_User(LoginModel login)
        {
            //LoginModel login = new LoginModel {MemberUserName=userName,MemberPassword=password };
            if (ModelState.IsValid)
            {
                User user = AutoMapper.Mapper.Map<Models.LoginModel, Entity.User>(login);//Automapping the Login Model and User Entity
                User checkUser = accountBL.CheckUser(user);//CheckUser is "Admin" Or "User"
                FormsAuthentication.SetAuthCookie(checkUser.MemberUserName, false);
                var authTicket = new FormsAuthenticationTicket(1, checkUser.MemberUserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, checkUser.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpContext.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));
                if (checkUser.Role == Role.admin.ToString())//"True" if the  logined user is "Admin"   
                {

                    return RedirectToAction("Home", "HomeLAS");
                }
                else if (checkUser.Role == Role.user.ToString())//"True" if the Logined user is "User"           
                    return RedirectToAction("Home", "HomeLAS");
            }
            return View();
        }
        [HttpPost]
        public JsonResult CheckUserName(string userName)
        {
            bool result = accountBL.CheckUserName(userName);
            return Json(result);


        }
        [HttpGet]
        public RedirectToRouteResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}