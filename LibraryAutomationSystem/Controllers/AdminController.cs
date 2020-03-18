using System;
using System.Collections.Generic;

using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAutomationSystem.Entity;

namespace LibraryAutomationSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admn
        UserRepository repository = new UserRepository();
        public ActionResult AdminChoice()
        {
            return View();
        }
        public ActionResult ManageUser()
        {
            IEnumerable<User> user = repository.GetUser();
            ViewData["user"] = user;
            ViewBag.user = user;
            TempData["user"] = user;
            return View();
        }
        public ActionResult Category()
        {
            ViewBag.Category = repository.GetCategory();
            TempData["Category"] = repository.GetCategory();
            return View();
        }
        [HttpGet]
        [ActionName("Create_Category")]
        public ActionResult Create_Category_Get()
        {
            return View();
        }
        public ActionResult Edit_Category(int CategoryId)
        {
            Models.Category categorylist = new Models.Category();

            Entity.Category category = repository.Get_CategoryById(CategoryId);

            categorylist.CategoryName = category.CategoryName;
            categorylist.CategoryId = category.CategoryId;

            return View(categorylist);
        }

        [HttpPost]
        [ActionName("Create_Category")]
        public ActionResult Create_Category_Post(Models.Category category)
        {
            Entity.Category entityCategory = new Entity.Category()
            {
                CategoryName = category.CategoryName,
            };
            repository.AddCategory(entityCategory);
            return RedirectToAction("Category");
        }
        [HttpPost]
        public ActionResult Update_Category(Models.Category categoryModel)
        {

            if (ModelState.IsValid)
            {
                Entity.Category category = new Entity.Category()
                {
                    CategoryName = categoryModel.CategoryName,
                    CategoryId = categoryModel.CategoryId,
                };
                repository.Update_Category(category);
                return RedirectToAction("Category");
            }
            return View();
        }

        public ActionResult Delete_Category(int CategoryID)
        {
            repository.Delete_Category(CategoryID);

            return RedirectToAction("Category");
        }
        public ActionResult View_Book()
        {
            return View();
        }
        [HttpGet]
        [ActionName("Add_Book")]
        public ActionResult Add_Book_Get()
        {
            ViewBag.Category = new SelectList(repository.GetCategory(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [ActionName("Add_Book")]
        public ActionResult Add_Book_Post(Models.AddBook book)
        {
            LibraryAutomationSystem.Entity.Book addBook = new Entity.Book()
            {
                BookTittle = book.BookTittle,

            };
            return View();
        }
        [HttpGet]
        [ActionName("Create_BookLanguage")]
        public ActionResult Create_BookLanguage_Get()
        {
            return View();
        }
        [ActionName("Create_BookLanguage")]
        [HttpPost]
        public ActionResult Create_BookLanguage_Post(Models.BookLanguage bookLanguage)
        {
            if (ModelState.IsValid)
            {
                var addLanguage = AutoMapper.Mapper.Map<Models.BookLanguage, LibraryAutomationSystem.Entity.BookLanguage>(bookLanguage);
                Book_Language_Repository repository = new Book_Language_Repository();
                repository.Add_Book_Language(addLanguage);
                return RedirectToAction("View_BookLanguage");
            }
            return View();
        }
        [HttpGet]
        public ActionResult View_BookLanguage()
        {
            Book_Language_Repository languageRepository = new Book_Language_Repository();
            IEnumerable<Entity.BookLanguage> languagelist = languageRepository.View_Book_Language();
            ViewBag.view = languagelist;
            return View();
        }
        [HttpGet]
        public ActionResult Edit_Book_Language(int Book_Language_Id)
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            Entity.BookLanguage language = repository.Find_Book_Language_Id(Book_Language_Id);
            Models.Edit_Language edit_language = AutoMapper.Mapper.Map<Entity.BookLanguage, Models.Edit_Language>(language);
            return View(edit_language);
        }
        [HttpPost]
        public ActionResult Update_Book_Language(Models.Edit_Language editLanguage)
        {
            if(ModelState.IsValid)
            {
               Entity.BookLanguage bookLanguage= AutoMapper.Mapper.Map<Models.Edit_Language, Entity.BookLanguage>(editLanguage);
                Book_Language_Repository languageRepository = new Book_Language_Repository();
                int result=languageRepository.Update_Book_Language(bookLanguage);
                if(result>=1)
                {
                    return RedirectToAction("View_BookLanguage");
                }
               
            }
            return RedirectToAction("");
        }
        public ActionResult Delete_Book_Language(int Book_Language_Id)
        {
            Book_Language_Repository languageRepository = new Book_Language_Repository();
            int result=languageRepository.Delete_Book_Language(Book_Language_Id);
            if(result>=1)
            {
                return RedirectToAction("View_BookLanguage");
            }
            else
            {
                return View("");
            }
        }
    }
}