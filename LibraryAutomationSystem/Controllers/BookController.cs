using System.Collections.Generic;
using LibraryAutomationSystem.BL;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.Models;
using System.Web.Mvc;
namespace LibraryAutomationSystem.Controllers
{
    [Authorize(Roles = "admin,user")]
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
        [OutputCache(Duration = 10)]
        [Authorize(Roles = "admin")]
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
        public ActionResult AddBook_Post(AddBookModel addBook)
        {
            ICategoryBL categoryBL = new CategoryBL();
            IBookLanguageBL bookLanguageBL = new BookLanguageBL();
            ViewBag.Category = new SelectList(categoryBL.GetCategory(), "CategoryId", "CategoryName");
            ViewBag.BookLanguage = new SelectList(bookLanguageBL.GetBookLanguage(), "BookLanguageId", "BookLanguageName");
            if (ModelState.IsValid)
            {

                Book book = AutoMapper.Mapper.Map<AddBookModel, Book>(addBook); //Automapper for book
                int result = bookBL.AddBook(book);//return the affected rows
                if (result >= 0)
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
        [Authorize(Roles = "admin")]
        public ActionResult EditBook(int bookId)//Find the Id to Edit the Book Details
        {
            ICategoryBL categoryBL = new CategoryBL();
            IBookLanguageBL bookLanguageBL = new BookLanguageBL();
            ViewBag.Category = new SelectList(categoryBL.GetCategory(), "CategoryId", "CategoryName");//Get the Category Table as Drop Down List
            ViewBag.BookLanguage = new SelectList(bookLanguageBL.GetBookLanguage(), "BookLanguageId", "BookLanguageName");//Get the BookLanguage Table as Drop Down List
            Book book = bookBL.FindBookById(bookId);//Find the Book which is going to Edit
            Models.EditBookModel findedBook = AutoMapper.Mapper.Map<Book, Models.EditBookModel>(book);//Return the Details to the View for Updation
            return View(findedBook);
        }
        [HttpPost]
        public ActionResult UpdateBook(Models.EditBookModel editBook)//Get the Updated Details from Model
        {
            ICategoryBL categoryBL = new CategoryBL();
            IBookLanguageBL bookLanguageBL = new BookLanguageBL();
            ViewBag.Category = new SelectList(categoryBL.GetCategory(), "CategoryId", "CategoryName");//Get the Category Table as Drop Down List
            ViewBag.BookLanguage = new SelectList(bookLanguageBL.GetBookLanguage(), "BookLanguageId", "BookLanguageName");//Get the BookLanguage Table as Drop Down List
            if (ModelState.IsValid)
            {

                Book book = AutoMapper.Mapper.Map<Models.EditBookModel, Entity.Book>(editBook);//Map the Model to Book Entity by AutoMapper
                if (bookBL.UpdateBook(book) >= 1)
                    return RedirectToAction("ViewBook");//If update successfully It returns to View Book
            }

            return View("EditBook", new { bookId = editBook.BookId });//If modelstate is false it returns to Edit View
        }




    }
}