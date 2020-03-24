using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomationSystem.DAL;
using LibraryAutomationSystem.BL;

namespace LibraryAutomationSystem.BL
{
    public class AccountBL
    {
        public static void AddUser(Entity.User user)
        {
            UserRepository repository = new UserRepository();
            repository.AddUser(user);
        }
        public static Entity.User CheckUser(Entity.User user)
        {
            UserRepository repository = new UserRepository();
            return repository.CheckUser(user);
        }
    }

}

