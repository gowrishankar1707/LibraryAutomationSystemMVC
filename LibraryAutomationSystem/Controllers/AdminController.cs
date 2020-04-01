using System.Collections.Generic;
using System.Web.Mvc;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.BL;

namespace LibraryAutomationSystem.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IAccountBL accountBL;
        public AdminController()
        {
            accountBL = new AccountBL();
        }
        // GET: Admn
        [Authorize]
        public ActionResult AdminChoice()
        {
            User user=TempData["User"] as User;
            TempData["Admin"] = user;
            return View();
        }

        public ActionResult ManageUser()
        {
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