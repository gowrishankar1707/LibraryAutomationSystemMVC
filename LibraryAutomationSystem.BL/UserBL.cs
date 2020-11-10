using LibraryAutomationSystem.DAL;

namespace LibraryAutomationSystem.BL
{
    public interface IUserBL
    {
        int GetUserId(string userName);
    }
   public class UserBL:IUserBL
    {
        UserRepository userRepository = new UserRepository()
;        public int GetUserId(string userName)
        {
            return userRepository.GetUserId(userName);
        }
    }
}
