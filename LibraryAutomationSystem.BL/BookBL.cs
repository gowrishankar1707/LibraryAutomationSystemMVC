using System;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.BL
{
    public interface IBookBL
    {
        IEnumerable<Book> GetBook();
        int AddBook(Book book);
        Book FindBookById(int bookId);
        int UpdateBook(Book book);
        int DeleteBook(int bookId);
    }
    public class BookBL:IBookBL
    {
        public IEnumerable<Book> GetBook()
        {
            BookRepository repository = new BookRepository();
            return repository.DisplayBook();
        }
        public int AddBook(Book book)
        {
            BookRepository repository = new BookRepository();
            return repository.AddBook(book);
        }
        public  Book FindBookById(int bookId)
        {
            BookRepository repository = new BookRepository();
            return repository.FindBookById(bookId);
        }
        public  int UpdateBook(Book book)
        {
            BookRepository repository = new BookRepository();
           return repository.UpdateBook(book);
        }
        public  int DeleteBook(int bookId)
        {
            BookRepository repository = new BookRepository();
           return repository.RemoveBook(bookId);
        }

    }
}
