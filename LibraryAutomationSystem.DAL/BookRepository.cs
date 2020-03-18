using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LibraryAutomationSystem.Entity;

namespace LibraryAutomationSystem.DAL
{
    public class BookRepository
    {

        public int AddBook(Entity.Book book)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter BookTittle = new SqlParameter("@BookTittle", book.BookTittle);
                        SqlParameter CategoryId = new SqlParameter("@CategoryId", book.CategoryId);
                        SqlParameter BookLanguageId = new SqlParameter("@BookLanguageId", book.BookLanguageId);
                        SqlParameter AuthorName = new SqlParameter("@AuthorName", book.AuthorName);
                        SqlParameter BookCount = new SqlParameter("@BookCount", book.BookCount);
                        SqlParameter BookType = new SqlParameter("@BookType", book.BookType);
                        int result = dbConnection.Database.ExecuteSqlCommand("Book_Insert @BookTittle, @CategoryId, @BookLanguageId, @AuthorName, @BookCount, @BookType", BookTittle, CategoryId, BookLanguageId, AuthorName, BookCount, BookType);

                        transaction.Commit();
                        return result;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return 0;

                    }
                }
            }
        }
        public IEnumerable<Book> DisplayBook()
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                return dbConnection.Book.Include("Category").Include("BookLanguage").ToList();
            }

        }
        public Book FindBookById(int bookId)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                return dbConnection.Book.Find(bookId);
            }
        }
        public int RemoveBook(int bookId)
        {
            Book book = FindBookById(bookId);
            using (DBConnection dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter Id = new SqlParameter("@BookId", book.BookId);
                        int result = dbConnection.Database.ExecuteSqlCommand("Book_Delete @BookId", Id);
                        transaction.Commit();
                        return result;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }

        }
        public int UpdateBook(Book book)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter BookId = new SqlParameter("@BookId", book.BookId);
                        SqlParameter BookTittle = new SqlParameter("@BookTittle", book.BookTittle);
                        SqlParameter CategoryId = new SqlParameter("@CategoryId", book.CategoryId);
                        SqlParameter BookLanguageId = new SqlParameter("@BookLanguageId", book.BookLanguageId);
                        SqlParameter AuthorName = new SqlParameter("@AuthorName", book.AuthorName);
                        SqlParameter BookCount = new SqlParameter("@BookCount", book.BookCount);
                        SqlParameter BookType = new SqlParameter("@BookType", book.BookType);
                        int result = dbConnection.Database.ExecuteSqlCommand("Book_Update @BookId, @BookTittle,@CategoryId,@BookLanguageId,@AuthorName,@BookCount,@BookType", BookId, BookTittle, CategoryId, BookLanguageId, AuthorName, BookCount, BookType);
                        transaction.Commit();
                        return result;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
           
            }
        }
    }
}
