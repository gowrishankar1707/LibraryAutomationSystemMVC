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
            using (dbConnection = new DBConnection())
            {
                dbConnection.user.Add(user);
                dbConnection.SaveChanges();
            }

        }
        public IEnumerable<User> GetUser()
        {
            using (dbConnection = new DBConnection())
            {
                return dbConnection.user.ToList();
            }
        }
        public User CheckLogin(User user)
        {
            using (dbConnection = new DBConnection())
            {

                User checkUser = dbConnection.user.Where(u => u.memberUserName == user.memberUserName && u.memberPassword == user.memberPassword).FirstOrDefault();
                return checkUser;
            }

        }

        public IEnumerable<Category> GetCategory()
        {
            using (dbConnection = new DBConnection())
            {

                return dbConnection.category.ToList();
            }
        }
        public void AddCategory(Category category)
        {
            using (dbConnection = new DBConnection())
            {
                dbConnection.category.Add(category);
                dbConnection.SaveChanges();
            }
        }
        public Category Get_CategoryById(int categoryId)
        {
            using (dbConnection = new DBConnection())
            {
                return dbConnection.category.Find(categoryId);
            }
        }
        public void Update_Category(Category category)
        {
            using (dbConnection = new DBConnection())
            {
                dbConnection.Entry(category).State = System.Data.Entity.EntityState.Modified;
                dbConnection.SaveChanges();
            }
        }
        public void Delete_Category(int CategoryId)
        {

            using (dbConnection = new DBConnection())
            {
                Entity.Category category = dbConnection.category.Find(CategoryId);
                dbConnection.category.Remove(category);
                dbConnection.SaveChanges();
            }
        }
        public IEnumerable<Category> Get_Category()
        {
            using (dbConnection = new DBConnection())
            {
                return dbConnection.category.ToList();
            }

        }
    }
}
