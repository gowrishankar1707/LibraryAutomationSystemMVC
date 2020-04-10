using System.Collections.Generic;
using System.Web.Mvc;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.BL;

namespace LibraryAutomationSystem.Controllers
{
    [Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        IAccountBL accountBL;
        public UserController()
        {
            accountBL = new AccountBL();
        }
        // GET: Admn
   

        public ActionResult ManageUser()//View the user
        {
            IEnumerable<User> user = accountBL.ViewUser();//Return the User by list to view
            return View(user);
        }
        public ActionResult DeleteUser(int userId)
        {
            int result = accountBL.DeleteUser(userId);
            if (result >= 1)
                return RedirectToAction("ManageUser");//Delete the User By id
            return View();
        }



    }
}