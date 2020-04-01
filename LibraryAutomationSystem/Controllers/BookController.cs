using System.Collections.Generic;
using LibraryAutomationSystem.BL;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.Models;
using System.Web.Mvc;
namespace LibraryAutomationSystem.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
     
        IBookBL bookBL;
        public BookController()
        {
            bookBL = new BookBL();
        }
        // GET: Book
        [HttpGet]
        [OutputCache(Duration = 10)]
        [Authorize(Roles = "admin,user")]
        public ViewResult ViewBook()//View the Existing Book in the Database
        {

            IEnumerable<Book> book = bookBL.GetBook();
            return View(book);
        }
        [ActionName("AddBook")]
        [HttpGet]
        [OutputCache(Duration =10)]

    
        public ActionResult AddBook_Get()//Add Book View
        {
            ICategoryBL categoryBL = new CategoryBL();
            IBookLanguageBL bookLanguageBL = new BookLanguageBL();
            ViewBag.Category = new SelectList(categoryBL.GetCategory(), "CategoryId", "CategoryName");
            ViewBag.BookLanguage = new SelectList(bookLanguageBL.GetBookLanguage(), "BookLanguageId", "BookLanguageName");
            return View();
        }

        [ActionName("AddBook")]//Post method of Adding Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook_Post(AddBook addBook)
        {
            if (ModelState.IsValid)
            {
               
               Book book= AutoMapper.Mapper.Map<AddBook, Book>(addBook); //Automapper for book

                int result = bookBL.AddBook(book);//return the affected rows
                if (result>=0)
                {
                    return RedirectToAction("ViewBook");
                }
            }
            return View();

        }

        [HttpPost]
        [ActionName("DeleteBook")]
        public ActionResult DeleteBook(int bookId)//Delete Book By Get The BookId
        {
            bookBL.DeleteBook(bookId);//Find the Book Id and Remove It
            return RedirectToAction("ViewBook");
            
        }
        [HttpGet]
        [OutputCache(CacheProfile = "1MinuteCache")]
        public ActionResult EditBook(int bookId)//Find the Id to Edit the Book Details
        {
            ICategoryBL categoryBL = new CategoryBL();
            IBookLanguageBL bookLanguageBL = new BookLanguageBL();
            ViewBag.Category = new SelectList(categoryBL.GetCategory(), "CategoryId", "CategoryName");//Get the Category Table as Drop Down List
            ViewBag.BookLanguage = new SelectList(bookLanguageBL.GetBookLanguage(), "BookLanguageId", "BookLanguageName");//Get the BookLanguage Table as Drop Down List
            Book book = bookBL.FindBookById(bookId);//Find the Book which is going to Edit
            Models.Edit_Book findedBook = AutoMapper.Mapper.Map<Book, Models.Edit_Book>(book);//Return the Details to the View for Updation
            return View(findedBook);
        }
        [HttpPost]
        public ActionResult UpdateBook(Models.Edit_Book editBook)//Get the Updated Details from Model

        {
            if (ModelState.IsValid)
            {
                ICategoryBL categoryBL = new CategoryBL();
                IBookLanguageBL bookLanguageBL = new BookLanguageBL();
                ViewBag.Category = new SelectList(categoryBL.GetCategory(), "CategoryId", "CategoryName");//Get the Category Table as Drop Down List
                ViewBag.BookLanguage = new SelectList(bookLanguageBL.GetBookLanguage(), "BookLanguageId", "BookLanguageName");//Get the BookLanguage Table as Drop Down List
                Book book = AutoMapper.Mapper.Map<Models.Edit_Book, Entity.Book>(editBook);//Map the Model to Book Entity by AutoMapper
                if (bookBL.UpdateBook(book) >= 1)
                    return RedirectToAction("ViewBook");
            }

            return View("EditBook",new { bookId = editBook.BookId });
        }




    }
}