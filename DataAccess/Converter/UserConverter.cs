using Models;
using DBModels;
using DataAccess;

namespace Converter
{
    public class UserConverter
    {
        public static User? DBtoBL(UserModel? user)
        {
            if (user == null) return null;
            return new User(user.ID, user.Login, user.Password, user.Level);
        }
        public static UserModel? BLtoDB(User? user)
        {
            if (user == null) return null;
            return new UserModel
            {
                ID = user.Id,
                Login = user.Login,
                Password = user.Password,
                Level = user.UserLevel
            };
        }
    }
}
