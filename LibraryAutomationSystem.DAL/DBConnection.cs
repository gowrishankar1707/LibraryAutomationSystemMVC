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
        public DbSet<User> user { get; set; }
        
    }
}
