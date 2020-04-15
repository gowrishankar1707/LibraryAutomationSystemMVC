using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using LibraryAutomationSystem.Entity;


namespace LibraryAutomationSystem.DAL
{
    public class Book_Language_Repository
    {
        public IEnumerable<BookLanguage> View_Book_Language()
        {
            using (DBConnection dbConnection = new DBConnection())//Dispose the object when the task is finished by using "USING" statement
            {
                IEnumerable<BookLanguage> list = dbConnection.BookLanguages.ToList();//Get the BookLanguage Table objects as list
                return list;//Return the List
            }

        }

        public int Add_Book_Language(BookLanguage bookLanguage)//add the book language and return the affected rows as result
        {

            using (DBConnection dbConnection = new DBConnection())
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        //SqlParameter LanguageName = new SqlParameter("@Language_Name", book_Language.BookLanguageName);
                        //int result = dbConnection.Database.ExecuteSqlCommand("BookLanguage_Insert @Language_Name", LanguageName);//use the sqlparameter to add the book language 
                        //transaction.Commit();//commit the entire transaction
                        //return result;//return the affected result
                        dbConnection.Entry(bookLanguage).State = System.Data.Entity.EntityState.Added;//Add New entity using Entity state.
                        transaction.Commit();
                        return dbConnection.SaveChanges();

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();//if any exception occur rollback to above commited place
                        return 0;//return 0 back if no rows affected or exception is throwned
                    }
                }
            }
        }
        public BookLanguage Find_Book_Language_Id(int Book_Language_Id)//Find the Book Language by id
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                return dbConnection.BookLanguages.Find(Book_Language_Id);//Return the Book Language object similar to the ID
            }

        }
        public int Update_Book_Language(Entity.BookLanguage bookLanguage)//update BookLanguage by BookLanguage Entity
        {
            using (DBConnection dbConnection = new DBConnection())//Dispose the object if the task is completed
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        //SqlParameter languageName = new SqlParameter("@Language_Name", bookLanguage.BookLanguageName);
                        //SqlParameter languageId = new SqlParameter("@Language_Id", bookLanguage.BookLanguageId);
                        //int result = dbConnection.Database.ExecuteSqlCommand("BookLanguage_Update @Language_Id,@Language_Name", languageId, languageName);
                        dbConnection.Entry(bookLanguage).State = System.Data.Entity.EntityState.Modified;//update the entity by using entity state
                        transaction.Commit();//Commit the changes permanently if the rows is updated
                        return dbConnection.SaveChanges();//return the affected rows
                    }
                    catch (Exception)
                    {

                        transaction.Rollback();//Rollback to the previous commit if the exception is throwned
                        return 0;//return 0 
                    }
                }
            }
        }
        public int Delete_Book_Language(int bookLanguageId)
        {
            using (DBConnection dbConnection = new DBConnection())//Dispose the objects if the task is completed 
            {
                using (var transaction = dbConnection.Database.BeginTransaction())
                {
                    try
                    {
                        //SqlParameter Id = new SqlParameter("@Language_Id", Book_Language_Id);
                        //int result = dbConnection.Database.ExecuteSqlCommand("BookLanguage_Delete @Language_Id", Id);//Execute the command by pass the sqlparameter and parameter name
                        //transaction.Commit();//Commit the changes to the underlying database
                        BookLanguage bookLanguage = Find_Book_Language_Id(bookLanguageId);
                        dbConnection.Entry(bookLanguage).State = System.Data.Entity.EntityState.Deleted;
                        transaction.Commit();
                        return dbConnection.SaveChanges();//Return the affected rows
                    }
                    catch
                    {
                        transaction.Rollback();//Rollback if the exception is throwned
                        return 0;//return 0 if no rows is affected
                    }
                }
            }

        }

    }
}
