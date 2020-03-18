using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;
using System.Web.Mvc;
using System.Configuration;
namespace LibraryAutomationSystem.Controllers
{
    public class BookController : Controller
    {
        // GET: Book

        [ActionName("AddBook")]
        [HttpGet]
        public ActionResult AddBook_Get()
        {
            UserRepository repository = new UserRepository();
            Book_Language_Repository languageRepository = new Book_Language_Repository();
            ViewBag.Category = new SelectList(repository.GetCategory(), "CategoryId", "CategoryName");
            ViewBag.BookLanguage = new SelectList(languageRepository.View_Book_Language(), "BookLanguageId", "BookLanguageName");
            return View();
        }

        [ActionName("AddBook")]
        [HttpPost]
        public ActionResult AddBook_Post(Models.AddBook addBook)
        {
            Entity.Book book = new Book()
            {
                BookTittle = addBook.BookTittle,
                CategoryId = addBook.CategoryId,
                BookLanguageId = addBook.BookLanguageId,
                AuthorName = addBook.AuthorName,
                BookCount = 3,
                BookType = addBook.BookType.ToString(),


            };

            BookRepository repository = new BookRepository();
            int result = repository.AddBook(book);
            if (result != 0)
            {
                return RedirectToAction("");
            }
            return View();

        }
        [HttpGet]
        public ViewResult ViewBook()
        {
            BookRepository repository = new BookRepository();
            IEnumerable<Book> book = repository.DisplayBook();
            return View(book);
        }
        [HttpPost]
        public ActionResult DeleteBook(int bookId)
        {
            BookRepository bookRepository = new BookRepository();
            int result = bookRepository.RemoveBook(bookId);
            if (result != 0)
            {
                return RedirectToAction("ViewBook");
            }
            return View("ViewBook");
        }
        [HttpGet]
        public ActionResult EditBook(int bookId)
        {
            UserRepository repo = new UserRepository();
            ViewBag.Category = new SelectList(repo.GetCategory(), "CategoryId", "CategoryName");
            Book_Language_Repository lang = new Book_Language_Repository();
            ViewBag.BookLanguage = new SelectList(lang.View_Book_Language(), "BookLanguageId", "BookLanguageName");
            BookRepository bookRepository = new BookRepository();
            Book book = bookRepository.FindBookById(bookId);
            Models.Edit_Book findedBook = AutoMapper.Mapper.Map<Book, Models.Edit_Book>(book);
            return View(findedBook);
        }
        [HttpPost]
        public ActionResult UpdateBook(Models.Edit_Book editBook)
        {
            Book book= AutoMapper.Mapper.Map<Models.Edit_Book, Entity.Book>(editBook);
            BookRepository repository = new BookRepository();
            int result=repository.UpdateBook(book);
            if (result >= 1)
                return RedirectToAction("ViewBook");
            return View();
        }




    }
}