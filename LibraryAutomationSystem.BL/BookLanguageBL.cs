using System.Collections.Generic;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;

namespace LibraryAutomationSystem.BL
{
    public interface IBookLanguageBL//Interface for BookLanguage
    {
        IEnumerable<BookLanguage> GetBookLanguage();
        int AddBookLanguage(BookLanguage bookLanguage);
        BookLanguage FindBookLanguageById(int bookLanguageId);
        int UpdateBookLanguage(BookLanguage bookLanguage);
        int DeleteBookLanguage(int bookLanguageId);

    }
    public class BookLanguageBL:IBookLanguageBL
    {
        public IEnumerable<BookLanguage> GetBookLanguage()//Get the BookLanguage as List
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.View_Book_Language();
        }
        public int AddBookLanguage(BookLanguage bookLanguage)//Add the BookLanguage to the User Repository
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.Add_Book_Language(bookLanguage);
        }
        public BookLanguage FindBookLanguageById(int bookLanguageId)//Find the BookLanguage By Id
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.Find_Book_Language_Id(bookLanguageId);
        }
        public int UpdateBookLanguage(BookLanguage bookLanguage)//Update the BookLanguage By sending the Updated entity to the repository
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.Update_Book_Language(bookLanguage);
        }
        public int DeleteBookLanguage(int bookLanguageId)//Delete the BookLanguage 
        {
            Book_Language_Repository repository = new Book_Language_Repository();
            return repository.Delete_Book_Language(bookLanguageId);
        }
    }
}
