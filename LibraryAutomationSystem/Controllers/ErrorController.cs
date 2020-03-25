using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()//If 404 Error Thrown This action redirect by use Web.Config
        {
            return View();
        }
    }
}