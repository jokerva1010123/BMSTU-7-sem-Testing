using Models;
using DBModels;

namespace Builders
{
    public class UserBuilder
    {
        private int id;
        private string login;
        private string password;
        private Levels level;
        public UserBuilder buildId(int id)
        {
            this.id = id;
            return this;
        }
        public UserBuilder buildLogin(string login)
        {
            this.login = login;
            return this;
        }
        public UserBuilder buildPassword(string password)
        {
            this.password = password;
            return this;
        }
        public UserBuilder buildLevel(Levels level)
        {
            this.level = level;
            return this;
        }
        public User buildBL()
        {
            User user = new User(id, login, password, level);
            return user;
        }
        public UserModel buildDA() 
        {
            return new UserModel
            {
                Login = login,
                Password = password,
                Level = level,
                ID = id
            };
        }
    }
}
