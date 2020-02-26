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
        public static List<User> userRepository = new List<User>();
        static UserRepository()
        {
            userRepository.Add(new User { memberName = "Gowri", memberUserName = "Gowrishankar", memberDOB = DateTime.Parse("12-01-2012"), memberDOJ = DateTime.Parse("04-05-2020"), memberSex = "Male", memberPhoneNumber = "9487758805", e_Mail = "gowrishankar17022000@gmail.com", memberAddress = "Vasagasalai" });
        }
        public static IEnumerable<User> GetUser()
        {
            return userRepository;
        }
        public void AddUser(User user)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.user.Add(user);
            dbConnection.SaveChanges();
           
        }
        public IEnumerable<User> CreateUser()
        {
            DBConnection dbConnection = new DBConnection();
            return dbConnection.user.ToList();
        }
    }
}
