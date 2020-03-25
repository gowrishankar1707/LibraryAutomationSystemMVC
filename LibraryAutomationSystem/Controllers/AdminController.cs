using System.Collections.Generic;using LibraryAutomationSystem.DAL;
using System.Web.Mvc;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.BL;

namespace LibraryAutomationSystem.Controllers
{
    public class AdminController : Controller
    {
        IAccountBL accountBL;
        public AdminController()
        {
            accountBL = new AccountBL();
        }
        // GET: Admn

        public ActionResult AdminChoice()
        {
            return View();
        }

        public ActionResult ManageUser()
        {
            UserRepository repository = new UserRepository();
            IEnumerable<User> user = accountBL.ViewUser();
            return View(user);
        }
        public ActionResult DeleteUser(int userId)
        {
            int result = accountBL.DeleteUser(userId);
            if (result >= 1)
                return RedirectToAction("ManageUser");
            return View();
        }



    }
}