using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;

namespace LibraryAutomationSystem.BL
{
    public interface IUserBL
    {
       IEnumerable<User> ViewUser();
        User CheckUser(User user);
        int AddUser(User user);
        int DeleteUser(int userId);
        User FindUserById(int userId);

    }
    public class UserBL : IUserBL
    {
        public IEnumerable<User> ViewUser()
        {
            UserRepository repository = new UserRepository();
            return repository.GetUser();
        }
        public User CheckUser(User user)
        {
            UserRepository repository = new UserRepository();
            return repository.CheckUser(user);
        }
        public int AddUser(User user)
        {
            UserRepository repository = new UserRepository();
            return repository.AddUser(user);
        }
        public int DeleteUser(int userId)
        {
            UserRepository repository = new UserRepository();
            return repository.DeleteUser(userId);
        }
        public User FindUserById(int userId)
        {
            UserRepository repository = new UserRepository();
            return repository.FindUserById(userId);
        }

    }
}
