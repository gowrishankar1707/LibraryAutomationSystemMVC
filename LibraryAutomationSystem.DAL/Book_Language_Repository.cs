using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LibraryAutomationSystem.Entity;


namespace LibraryAutomationSystem.DAL
{
    public class Book_Language_Repository
    {
        public IEnumerable<BookLanguage> View_Book_Language()
        {
            using (DBConnection dbConnection = new DBConnection())
            {
               IEnumerable<BookLanguage> list= dbConnection.BookLanguages.ToList();
                return list;
            }
              
        }
    
        public void Add_Book_Language(BookLanguage book_Language)
        {

            using (DBConnection dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter LanguageName = new SqlParameter("@Language_Name", book_Language.BookLanguageName);
                        var result = dbConnection.Database.ExecuteSqlCommand("BookLanguage_Insert @Language_Name", LanguageName);
                        transaction.Commit();
                    }
                    catch(Exception)
                    {
                        transaction.Rollback();
                    }
                }

                //dbConnection.Entry(book_Language).State = System.Data.Entity.EntityState.Added;
                //dbConnection.SaveChanges();
            }
        }
        public BookLanguage Find_Book_Language_Id(int Book_Language_Id)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                return dbConnection.BookLanguages.Find(Book_Language_Id);
            }
               
        }

    }
}
