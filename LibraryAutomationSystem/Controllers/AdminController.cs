using System;
using System.Collections.Generic;
using LibraryAutomationSystem.Entity;
using UserEntity;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            
            Entity.Category category = repository.Get_CategoryById( CategoryId);

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
                CategoryName=category.CategoryName,
            };
            repository.AddCategory(entityCategory);
            return RedirectToAction("Category");
        }
        [HttpPost]
        public ActionResult Update_Category(Models.Category categoryModel)
        {

            if(ModelState.IsValid)
            {
                Entity.Category category = new Entity.Category()
                {
                    CategoryName=categoryModel.CategoryName,
                    CategoryId=categoryModel.CategoryId,
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
        public ActionResult Add_Book_Post(Models.Book book)
        {
            UserEntity.Book addBook = new UserEntity.Book()
            {
                BookName=book.BookName,
                category=book.Category,

            };
            return View();
        }

        


    }
}