using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.Entity;
using System.Collections.Generic;

namespace LibraryAutomationSystem.BL
{
    public interface IAccountBL//Interface for Dependency Injection
    {
        int AddUser(Entity.User user);
        int DeleteUser(int userId);
        User FindUserById(int userId);
        Entity.User CheckUser(Entity.User user);
        IEnumerable<Entity.User> ViewUser();
        bool CheckUserName(string userName);
    }
    public class AccountBL : IAccountBL
    {
        UserRepository repository = new UserRepository();
        public IEnumerable<Entity.User> ViewUser()
        {
            
            return repository.GetUser();
        }
        public int AddUser(Entity.User user)//Add the User to the Library
        {
            
            return repository.AddUser(user);
        }
        public Entity.User CheckUser(Entity.User user)//Check if the User is available at library.
        {
           
            return repository.CheckUser(user);
        }

        public int DeleteUser(int userId)//Delete The User
        {
            
            return repository.DeleteUser(userId);//Return the affected rows
        }
        public User FindUserById(int userId)//Find the user by Id
        {
            
            return repository.FindUserById(userId);//return the User if the Id is matched in database
        }
        public bool CheckUserName(string userName)
        {
            return repository.CheckUserNameIsAvailable(userName);
        }
    }

}

