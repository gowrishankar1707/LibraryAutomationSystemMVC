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
                IEnumerable<BookLanguage> list = dbConnection.BookLanguages.ToList();
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
                    catch (Exception)
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
        public int Update_Book_Language(Entity.BookLanguage bookLanguage)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    //try
                    //{
                    SqlParameter languageName = new SqlParameter("@Language_Name", bookLanguage.BookLanguageName);
                    SqlParameter languageId = new SqlParameter("@Language_Id", bookLanguage.BookLanguageId);
                    var result = dbConnection.Database.ExecuteSqlCommand("BookLanguage_Update @Language_Id,@Language_Name", languageId, languageName);
                    transaction.Commit();
                    return result;

                    //}
                    //catch(Exception )
                    //{

                    //        transaction.Rollback();
                    //        return 0;
                    //    }
                }
            }
        }
        public int Delete_Book_Language(int Book_Language_Id)
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        //BookLanguage language = Find_Book_Language_Id(Book_Language_Id);
                        SqlParameter Id = new SqlParameter("@Language_Id", Book_Language_Id);
                        var result = dbConnection.Database.ExecuteSqlCommand("BookLanguage_Delete @Language_Id", Id);
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
