using Models;

namespace InterfaceDB
{
    public interface IUserDB
    {
        public User? getUserFromLogin(string login);
        public int changePassword(int id_user, string newPass);
        public int addUser(User user);
    }
}
