﻿using System.Collections.Generic;
using LibraryAutomationSystem.BL;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.Models;
using System.Web.Mvc;
using System.IO;
using System;
using UserEntity;

namespace LibraryAutomationSystem.Controllers
{
    
    public class BookController : Controller
    {

        IBookBL bookBL;
        IUserBL userBL;
        public BookController()
        {
            bookBL = new BookBL();
            userBL = new UserBL();
        }
        // GET: Book
        [HttpGet]
        [OutputCache(Duration = 10)]
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
            /********   Declared filename and extension to store the exact image path in the database        *************************/
            string fileName = Path.GetFileNameWithoutExtension(addBook.ImageFile.FileName);
            string extension = Path.GetExtension(addBook.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            addBook.BookImagePath = fileName;

            if (ModelState.IsValid)
            {
                
                Book book = AutoMapper.Mapper.Map<AddBookModel, Book>(addBook); //Automapper for book
                int result = bookBL.AddBook(book);//return the affected rows
                if (result >= 0)
                {
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    addBook.ImageFile.SaveAs(fileName);
                    return RedirectToAction("ViewBook");
                }
            }
            return View();

        }

        [HttpPost]
        [Authorize(Roles ="admin")]
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
            TempData["Imagepath"] = findedBook.BookImagePath;
            return View(findedBook);
        }
        [HttpPost]
        [ActionName("EditBook")]
        public ActionResult UpdateBook(Models.EditBookModel editBook)//Get the Updated Details from Model
        {
            string fileName=null;
            string extension;
            /********** Declared variabls for file processing   ******************* */
            ICategoryBL categoryBL = new CategoryBL();
            IBookLanguageBL bookLanguageBL = new BookLanguageBL();
            ViewBag.Category = new SelectList(categoryBL.GetCategory(), "CategoryId", "CategoryName");//Get the Category Table as Drop Down List
            ViewBag.BookLanguage = new SelectList(bookLanguageBL.GetBookLanguage(), "BookLanguageId", "BookLanguageName");//Get the BookLanguage Table as Drop Down List
            if(editBook.ImageFile==null)
            {
                editBook.BookImagePath = Convert.ToString( TempData["Imagepath"]);
            }
            else 
            {
                 fileName = Path.GetFileNameWithoutExtension(editBook.ImageFile.FileName);
                 extension = Path.GetExtension(editBook.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                editBook.BookImagePath = fileName;
            }
            
            if (ModelState.IsValid) 
            {

                Book book = AutoMapper.Mapper.Map<Models.EditBookModel, Entity.Book>(editBook);//Map the Model to Book Entity by AutoMapper


                if (bookBL.UpdateBook(book) >= 1)
                {
                    if (editBook.ImageFile != null)
                    {
                        fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        editBook.ImageFile.SaveAs(fileName);
                    }

                    return RedirectToAction("ViewBook");//If update successfully It returns to View Book
                }
            }

            return View(editBook);//If modelstate is false it returns to Edit View
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public ActionResult GetBook(string userName,int bookId)
        {
           
            Book book = GetBook(bookId);
           int id= userBL.GetUserId(userName);
            BookOrder bookOrder = new BookOrder();
            bookOrder.Id = id;
            bookOrder.BookId = bookId;
            bookOrder.BookTittle = book.BookTittle;
            bookOrder.AuthorName = book.AuthorName;
            bookOrder.ImagePath = book.BookImagePath;
            bookOrder.RequestedDate = DateTime.Now.Date;
            
             
            int result=   bookBL.PlaceBookRequest(bookOrder); //Place the Request to the BookOrderTable
            if (result > 0)
            {
                TempData["RequestMessage"] = "Request Book Successfully";
                return RedirectToAction("Home", "HomeLAS");
            }
            else
            {
                TempData["RequestMessage"] = "Request Book not Successfully";
                return RedirectToAction("Home", "HomeLAS");

            }
        }
         [Authorize(Roles ="admin")]
        public ActionResult RequestedUser()//Get the Requested user 
        {
            IEnumerable<BookOrder> bookOrders = bookBL.GetRequestedUser();
            return View(bookOrders);
        }
        [Authorize(Roles ="admin")]
        public ActionResult ReceivedBook(int bookOrderId)
        {
            BookOrder bookOrder = bookBL.GetBookOrderById(bookOrderId);
            bookOrder.BookReceivedDate = DateTime.Now.Date;
            int result=bookBL.UpdateReceivedDateInBookOrder(bookOrder);
            if(result>0)
            {
                TempData["UpdateReceiveDate"] = "Received Date Updated Successfully";
                return RedirectToAction("ReceivedBook", "Book");
            }
            else
            {
                TempData["UpdateReceiveDate"] = "Received Date Updated unSuccessfully";
                return RedirectToAction("ReceivedBook", "Book");
            }

           
        }
        [NonAction]
        public Book GetBook(int bookId)
        {
            return bookBL.FindBookById(bookId);
        }
      


    }
}
