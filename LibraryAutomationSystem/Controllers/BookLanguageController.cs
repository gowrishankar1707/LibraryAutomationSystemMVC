using LibraryAutomationSystem.BL;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class BookLanguageController : Controller
    {
        IBookLanguageBL bookLanguageBL;
        public BookLanguageController()
        {
            bookLanguageBL = new BookLanguageBL();//Creates the object for the BookLanguage Bl by IBookLanguageBL reference variable
        }
        // GET: BookLanguage
        [HttpGet]
        [ActionName("Create_BookLanguage")]
        [Authorize(Roles = "admin")]
        public ActionResult Create_BookLanguage_Get()//Get request of CreateBookLanguage
        {
            return View();
        }
        [ActionName("Create_BookLanguage")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_BookLanguage_Post(Models.BookLanguageModel bookLanguage)//Add the BookLanguage 
        {
            if (ModelState.IsValid)
            {
                Entity.BookLanguage addLanguage = AutoMapper.Mapper.Map<Models.BookLanguageModel, LibraryAutomationSystem.Entity.BookLanguage>(bookLanguage);
                if (bookLanguageBL.AddBookLanguage(addLanguage) >= 1)
                    return RedirectToAction("View_BookLanguage");
                return View();
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public ActionResult View_BookLanguage()//View the BookLanguage
        {
            IEnumerable<Entity.BookLanguage> languagelist = bookLanguageBL.GetBookLanguage();
            return View(languagelist);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit_Book_Language(int bookLanguageId)//Edit the book language by its Id
        {
            Entity.BookLanguage language = bookLanguageBL.FindBookLanguageById(bookLanguageId);//Get the Book Language Entity by Its Id
            Models.EditLanguageModel edit_language = AutoMapper.Mapper.Map<Entity.BookLanguage, Models.EditLanguageModel>(language);//Map the Entity to Model and Edit the Changes
            return View(edit_language);
        }
        [HttpPost]
        public ActionResult Update_Book_Language(Models.EditLanguageModel editLanguage)//Update the Book 
        {
            if (ModelState.IsValid)
            {
                Entity.BookLanguage bookLanguage = AutoMapper.Mapper.Map<Models.EditLanguageModel, Entity.BookLanguage>(editLanguage);//Map the Model details to the Entity by Automapper
                if (bookLanguageBL.UpdateBookLanguage(bookLanguage) >= 1)
                    return RedirectToAction("View_BookLanguage");
            }
            return RedirectToAction("Edit_Book_Language", new { bookLanguageId = editLanguage.BookLanguageId });//Modelstate is false return to Edit Book
        }
        [HttpGet]
        public ActionResult Delete_Book_Language(int bookLanguageId)//Delete BookLanguage By Id
        {
            int a = bookLanguageBL.DeleteBookLanguage(bookLanguageId);
            return RedirectToAction("View_BookLanguage");

        }
    }
}