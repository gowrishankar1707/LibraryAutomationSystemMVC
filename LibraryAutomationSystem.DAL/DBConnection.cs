using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibraryAutomationSystem.Entity;


namespace LibraryAutomationSystem.DAL
{
    class DBConnection:DbContext
    {
        public DBConnection():base("connect")
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookLanguage> BookLanguages { get; set; }
        public DbSet<Book> Book { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookLanguage>().MapToStoredProcedures();
            modelBuilder.Entity<Book>().MapToStoredProcedures();
        }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<User>().HasIndex(c => c.e_Mail).IsUnique();        
        //}

    }
}
