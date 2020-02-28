using LibraryAutomationSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace LibraryAutomationSystem.DAL
{
    public class UserRepository
    {
        DBConnection dbConnection;
        public static List<User> userRepository = new List<User>();
        
        public void AddUser(User user)
        {
            dbConnection = new DBConnection();
            dbConnection.user.Add(user);
            dbConnection.SaveChanges();
           
        }
        public IEnumerable<User> GetUser()
        {
             dbConnection = new DBConnection();
            return dbConnection.user.ToList();
        }
    }
}
