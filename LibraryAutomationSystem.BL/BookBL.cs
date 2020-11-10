using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;
using System;
using System.Collections.Generic;
using UserEntity;

namespace LibraryAutomationSystem.BL
{
    public interface IBookBL//Interface for BookBL 
    {
        IEnumerable<Book> GetBook();
        int AddBook(Book book);
        Book FindBookById(int bookId);
        int UpdateBook(Book book);
        int DeleteBook(int bookId);
        int PlaceBookRequest(BookOrder bookOrder);
        IEnumerable<BookOrder> GetRequestedUser();
        BookOrder GetBookOrderById(int bookOrderId);
        int UpdateReceivedDateInBookOrder(BookOrder bookOrder);





    }
    public class BookBL : IBookBL
    {
        BookRepository repository = new BookRepository();
        public IEnumerable<Book> GetBook()//Get the Book From Database
        {

            return repository.DisplayBook();//return the books back to the controller
        }
        public int AddBook(Book book)//Add Book
        {

            return repository.AddBook(book);//send the details to the repository
        }
        public Book FindBookById(int bookId)//Find Book By Id
        {

            return repository.FindBookById(bookId);//return the entity to the controller
        }
        public int UpdateBook(Book book)
        {

            return repository.UpdateBook(book);//update the book by sending the entity to the repository
        }
        public int DeleteBook(int bookId)//method for Deleting the book
        {

            return repository.RemoveBook(bookId);
        }
        public int PlaceBookRequest(BookOrder bookOrder)//Place the order for requesting the book
        {
            return repository.PlaceBookRequest(bookOrder);
        }
        public IEnumerable<BookOrder> GetRequestedUser()//Get the requested user
        {
            return repository.GetRequestedUser();
        }
        public BookOrder GetBookOrderById(int bookOrderId)// Get Order Details by BookOrder Id
        {
            return repository.GetBookOrderById(bookOrderId);
        }
        public int UpdateReceivedDateInBookOrder(BookOrder bookOrder)//Update Receive Date in Order Details
        {
            return repository.UpdateReceivedDateInBookOrder(bookOrder);
        }

    }


}


