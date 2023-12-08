using InterfaceDB;
using Models;
using Error;

namespace Services
{
    public class UserServices
    {
        private IUserDB iuserDB;
        public IUserDB IuserDB { get => iuserDB; set => iuserDB = value; }
        public UserServices(IUserDB iuserDB)
        {
            this.iuserDB = iuserDB;
        }
        public int addUser(User user)
        {
            if (this.iuserDB.getUserFromLogin(user.Login) != null)
                throw new UserExistsException();
            return this.iuserDB.addUser(user);
        }
        public int getIdUser(string login)
        {
            User? user = this.iuserDB.getUserFromLogin(login);
            if (user == null)
                throw new UserNotFoundException();
            else 
                return user.Id;
        }
        public User getUserFromLogin(string login)
        {
            User? user = this.iuserDB.getUserFromLogin(login);
            if(user == null)
                throw new UserNotFoundException();
            else 
                return user;
        }
        public int userExists(string login)
        {
            if(this.iuserDB.getUserFromLogin(login) != null)
                return 1;
            return 0;
        }
    }
}
