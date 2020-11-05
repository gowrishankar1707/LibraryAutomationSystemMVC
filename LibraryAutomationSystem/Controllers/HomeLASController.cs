using System.Web.Mvc;
using LibraryAutomationSystem.BL;
using System.Collections.Generic;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.Models;

namespace LibraryAutomationSystem.Controllers
{
    public class HomeLASController : Controller
    {
     
        IHomeBL homeBL;

        public HomeLASController()//constructor for the HomeLASController
        {
            homeBL = new HomeBL();//object creation for HomeBL
        }
        /*
         * **************   GET REQUEST OF HOME ACTION RESULT*****************
         */
        public ActionResult Home()
        {
            IEnumerable<Book> book= homeBL.DisplayBooks();

            return View(book);
        }

    }
}