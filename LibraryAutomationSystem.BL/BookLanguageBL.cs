using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;

namespace LibraryAutomationSystem.BL
{
    public interface IBookLanguageBL
    {
        IEnumerable<BookLanguage> GetBookLanguage();
        int AddBookLanguage(BookLanguage bookLanguage);
        BookLanguage FindBookLanguageById(int bookLanguageId);
        int UpdateBookLanguage(BookLanguage bookLanguage);
        int DeleteBookLanguage(int bookLanguageId);

    }
    public class BookLanguageBL:IBookLanguageBL
    {
        public IEnumerable<BookLanguage> GetBookLanguage()
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.View_Book_Language();
        }
        public int AddBookLanguage(BookLanguage bookLanguage)
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.Add_Book_Language(bookLanguage);
        }
        public BookLanguage FindBookLanguageById(int bookLanguageId)
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.Find_Book_Language_Id(bookLanguageId);
        }
        public int UpdateBookLanguage(BookLanguage bookLanguage)
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.Update_Book_Language(bookLanguage);
        }
        public int DeleteBookLanguage(int bookLanguageId)
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.Delete_Book_Language(bookLanguageId);
        }
    }
}
