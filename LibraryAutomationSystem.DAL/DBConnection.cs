using System.Data.Entity;
using LibraryAutomationSystem.Entity;


namespace LibraryAutomationSystem.DAL
{
    class DBConnection:DbContext
    {
        public DBConnection():base("connect")
        {
            
        }
        public DbSet<User> Users { get; set; }//User Dbset
        public DbSet<Category> Categories { get; set; }//Category Dbset
        public DbSet<BookLanguage> BookLanguages { get; set; }//BookLanguage Dbset
        public DbSet<Book> Book { get; set; }//Book Dbset
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookLanguage>().MapToStoredProcedures();//BookLanguage Stored Procedure
            modelBuilder.Entity<Book>().MapToStoredProcedures();//Book Stored Procedure
        }

    }
}
