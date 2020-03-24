using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
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
        public ActionResult Create_BookLanguage_Get()//Get request of CreateBookLanguage
        {
            return View();
        }
        [ActionName("Create_BookLanguage")]
        [HttpPost]
        public ActionResult Create_BookLanguage_Post(Models.BookLanguage bookLanguage)//Add the BookLanguage 
        {
            if (ModelState.IsValid)
            {
                Entity.BookLanguage addLanguage = AutoMapper.Mapper.Map<Models.BookLanguage, LibraryAutomationSystem.Entity.BookLanguage>(bookLanguage);
                if (bookLanguageBL.AddBookLanguage(addLanguage) >= 1)
                    return RedirectToAction("View_BookLanguage");
                return View();
            }
            return View();
        }
        [HttpGet]
        public ActionResult View_BookLanguage()//View the BookLanguage
        {
            IEnumerable<Entity.BookLanguage> languagelist = bookLanguageBL.GetBookLanguage();
            ViewBag.view = languagelist;
            return View();
        }
        [HttpGet]
        public ActionResult Edit_Book_Language(int Book_Language_Id)//Edit the book language by its Id
        {
            Entity.BookLanguage language = bookLanguageBL.FindBookLanguageById(Book_Language_Id);//Get the Book Language Entity by Its Id
            Models.Edit_Language edit_language = AutoMapper.Mapper.Map<Entity.BookLanguage, Models.Edit_Language>(language);//Map the Entity to Model and Edit the Changes
            return View(edit_language);
        }
        [HttpPost]
        public ActionResult Update_Book_Language(Models.Edit_Language editLanguage)//Update the Book 
        {

            Entity.BookLanguage bookLanguage = AutoMapper.Mapper.Map<Models.Edit_Language, Entity.BookLanguage>(editLanguage);//Map the Model details to the Entity by Automapper
            if (bookLanguageBL.UpdateBookLanguage(bookLanguage) >= 1)
                return RedirectToAction("View_BookLanguage");
            return View();
        }
        public ActionResult Delete_Book_Language(int Book_Language_Id)
        {
            if (bookLanguageBL.DeleteBookLanguage(Book_Language_Id) >= 1)
                return RedirectToAction("View_BookLanguage");
            return View();
        }
    }
}