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
        public User CheckLogin(User user)
        {
            //IEnumerable<User> userList = GetUser();
            //foreach (User items in userList)
            //{
            //    if (items.memberUserName == user.memberUserName && items.memberPassword == user.memberPassword)
            //    {
            //        return items.role;
            //    }
            //}


            DBConnection connnect = new DBConnection();
            foreach(var context in connnect.user)
            {
                if(context.memberUserName.Equals(user.memberUserName)&&context.memberUserName.Equals(user.memberPassword))
                {
                    return context;
                }
            }
            return null;
        }
        //public User GetUserByUserName(string userName)
        //{
        //    DBConnection findUser = new DBConnection();
        //    User userInput= findUser.user.Find()
        //}

        public IEnumerable<Category> GetCategory()
        {
            dbConnection = new DBConnection();
            return dbConnection.category.ToList();
        }
    }
}
