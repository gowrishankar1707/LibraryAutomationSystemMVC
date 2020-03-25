using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;
using System.Collections.Generic;


namespace LibraryAutomationSystem.BL
{
    public interface IBookBL//Interface for BookBL 
    {
        IEnumerable<Book> GetBook();
        int AddBook(Book book);
        Book FindBookById(int bookId);
        int UpdateBook(Book book);
        int DeleteBook(int bookId);
    }
    public class BookBL : IBookBL
    {
        public IEnumerable<Book> GetBook()//Get the Book From Database
        {
            BookRepository repository = new BookRepository();
            return repository.DisplayBook();//return the books back to the controller
        }
        public int AddBook(Book book)//Add Book
        {
            BookRepository repository = new BookRepository();
            return repository.AddBook(book);//send the details to the repository
        }
        public Book FindBookById(int bookId)//Find Book By Id
        {
            BookRepository repository = new BookRepository();
            return repository.FindBookById(bookId);//return the entity to the controller
        }
        public int UpdateBook(Book book)
        {
            BookRepository repository = new BookRepository();
            return repository.UpdateBook(book);//update the book by sending the entity to the repository
        }
        public int DeleteBook(int bookId)
        {
            BookRepository repository = new BookRepository();
            return repository.RemoveBook(bookId);
        }

    }
}
