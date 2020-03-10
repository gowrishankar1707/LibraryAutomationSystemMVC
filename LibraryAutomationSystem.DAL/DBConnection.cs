using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibraryAutomationSystem.Entity;
using UserEntity;

namespace LibraryAutomationSystem.DAL
{
    class DBConnection:DbContext
    {
        public DBConnection():base("connect")
        {
            
        }
        public DbSet<User> user { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Book> Book { get; set; }

       

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<User>().HasIndex(c => c.e_Mail).IsUnique();        
        //}

    }
}
