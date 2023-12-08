using InterfaceDB;
using Models;
using DBModels;
using Converter;

namespace DataAccess
{
    public class UserDA : IUserDB
    {
        private readonly AppDbContext db;
        public UserDA(AppDbContext curDb)
        {
            db = curDb;
        }
        public User? getUserFromLogin(string login)
        {
            foreach (UserModel temp in this.db.Users)
                if (temp.Login == login)
                    return UserConverter.DBtoBL(temp);
            return null;
        }
        public int changePassword(int id_user, string newPass)
        {
            UserModel? user = db.Users.Where(u => u.ID == id_user).FirstOrDefault();
            if (user == null)
                return 0;
            user.Password = newPass;
            db.SaveChanges();
            return 1;
        }
        public int addUser(User user)
        {
            List<UserModel>? lst = db.Users.Count() > 0 ? db.Users.ToList() : null;
            int maxid = 0;
            foreach (UserModel temp in lst)
                if (temp.ID > maxid)
                    maxid = temp.ID;
            user.Id = maxid + 1;
            db.Users.Add(UserConverter.BLtoDB(user));
            db.SaveChanges();
            return user.Id;
        }
    }
}
