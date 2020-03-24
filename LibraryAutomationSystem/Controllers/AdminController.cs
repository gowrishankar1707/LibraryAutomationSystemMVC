using System;
using System.Collections.Generic;

using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.BL;

namespace LibraryAutomationSystem.Controllers
{
    public class AdminController : Controller
    {
        IUserBL userBL;
        public AdminController()
        {
            userBL = new UserBL();
        }
        // GET: Admn

        public ActionResult AdminChoice()
        {
            return View();
        }

        public ActionResult ManageUser()
        {
            UserRepository repository = new UserRepository();
            IEnumerable<User> user = userBL.ViewUser();
            return View(user);
        }
        public ActionResult DeleteUser(int userId)
        {
            int result = userBL.DeleteUser(userId);
            if (result >= 1)
                return RedirectToAction("ManageUser");
            return View();
        }



    }
}