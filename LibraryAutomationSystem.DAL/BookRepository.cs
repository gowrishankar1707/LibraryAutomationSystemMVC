using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using LibraryAutomationSystem.Entity;
using UserEntity;
using System;

namespace LibraryAutomationSystem.DAL
{
    public class BookRepository
    {

        DBConnection dbConnection;

        public int AddBook(Entity.Book book)//Add Book 
        {
            using ( dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        //SqlParameter BookTittle = new SqlParameter("@BookTittle", book.BookTittle);
                        //SqlParameter CategoryId = new SqlParameter("@CategoryId", book.CategoryId);
                        //SqlParameter BookLanguageId = new SqlParameter("@BookLanguageId", book.BookLanguageId);
                        //SqlParameter AuthorName = new SqlParameter("@AuthorName", book.AuthorName);
                        //SqlParameter BookCount = new SqlParameter("@BookCount", book.BookCount);
                        //SqlParameter BookType = new SqlParameter("@BookType", book.BookType);
                        //int result = dbConnection.Database.ExecuteSqlCommand("Book_Insert @BookTittle, @CategoryId, @BookLanguageId, @AuthorName, @BookCount, @BookType", BookTittle, CategoryId, BookLanguageId, AuthorName, BookCount, BookType);
                        dbConnection.Entry(book).State = System.Data.Entity.EntityState.Added;//Add the book using Entity State
                        transaction.Commit();
                        return dbConnection.SaveChanges();
                    }
                    catch
                    {
                        transaction.Rollback();
                        return 0;

                    }
                }
            }
        }
        public IEnumerable<Book> DisplayBook()//Display Book
        {
            using ( dbConnection = new DBConnection())
            {
                return dbConnection.Book.Include("Category").Include("BookLanguage").ToList();
            }

        }
        public Book FindBookById(int bookId)//Find Book
        {
            using ( dbConnection = new DBConnection())
            {
                return dbConnection.Book.Find(bookId);
            }
        }
        public int RemoveBook(int bookId)//Remove Book
        {

            using ( dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        //    SqlParameter Id = new SqlParameter("@BookId", book.BookId);
                        //    int result = dbConnection.Database.ExecuteSqlCommand("Book_Delete @BookId", Id);
                        Book book = FindBookById(bookId);
                        dbConnection.Entry(book).State = System.Data.Entity.EntityState.Deleted;//Delete the book using deleted entity state
                        transaction.Commit();
                        return dbConnection.SaveChanges();
                    }
                    catch
                    {
                        transaction.Rollback();
                        return 0;

                    }
                }
            }

        }
        public int UpdateBook(Book book)//Update Book
        {
            using ( dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        //SqlParameter BookId = new SqlParameter("@BookId", book.BookId);
                        //SqlParameter BookTittle = new SqlParameter("@BookTittle", book.BookTittle);
                        //SqlParameter CategoryId = new SqlParameter("@CategoryId", book.CategoryId);
                        //SqlParameter BookLanguageId = new SqlParameter("@BookLanguageId", book.BookLanguageId);
                        //SqlParameter AuthorName = new SqlParameter("@AuthorName", book.AuthorName);
                        //SqlParameter BookCount = new SqlParameter("@BookCount", book.BookCount);
                        //SqlParameter BookType = new SqlParameter("@BookType", book.BookType);
                        //int result = dbConnection.Database.ExecuteSqlCommand("Book_Update @BookId, @BookTittle,@CategoryId,@BookLanguageId,@AuthorName,@BookCount,@BookType", BookId, BookTittle, CategoryId, BookLanguageId, AuthorName, BookCount, BookType);
                        dbConnection.Entry(book).State = System.Data.Entity.EntityState.Modified;//Update the book by using modified state
                        transaction.Commit();
                        return dbConnection.SaveChanges();
                    }
                    catch
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }

            }
        }
        public int PlaceBookRequest(BookOrder bookOrder)//place the Book Request
        {
            using(dbConnection=new DBConnection())
            {
                dbConnection.BookOrder.Add(bookOrder);
                return dbConnection.SaveChanges();
            }
        }
        public IEnumerable<BookOrder> GetRequestedUser()//Get the requested user
        {
            using (dbConnection = new DBConnection())
            {
                return dbConnection.BookOrder.Where(book => book.BookReceivedDate == null).ToList();
            }
        }
        public BookOrder GetBookOrderById(int bookOrderId)//Get BookOrder Details by id
        {
            using (dbConnection = new DBConnection())
            {
                return dbConnection.BookOrder.Where(book => book.BookOrderId == bookOrderId).FirstOrDefault();

            }
        }
        public int UpdateReceivedDateInBookOrder(BookOrder bookOrder)//Update Received date in BookOrder Details
        {
            using (dbConnection = new DBConnection())
            {
                dbConnection.Entry(bookOrder).State = System.Data.Entity.EntityState.Modified;
                return dbConnection.SaveChanges();

            }
        }
        
    }
}
