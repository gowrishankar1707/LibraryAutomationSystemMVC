using System.Data.Entity;
using LibraryAutomationSystem.Entity;
using UserEntity;

namespace LibraryAutomationSystem.DAL
{
   public class DBConnection:DbContext
    {
        public DBConnection():base("connect")
        {
            
        }
        public DbSet<User> Users { get; set; }//User Dbset
        public DbSet<Category> Categories { get; set; }//Category Dbset
        public DbSet<BookLanguage> BookLanguages { get; set; }//BookLanguage Dbset
        public DbSet<Book> Book { get; set; }//Book Dbset
        public DbSet<BookOrder> BookOrder { get; set; } //BookOrder DBset
        public DbSet<ExceptionLogger> ExceptionLogger { get; set; }//Exception Logger DBset
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookLanguage>().MapToStoredProcedures();//BookLanguage Stored Procedure
            modelBuilder.Entity<Book>().MapToStoredProcedures();//Book Stored Procedure
        }   

    }
}
