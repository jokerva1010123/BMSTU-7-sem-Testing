using Error;
using Models;
using InterfaceDB;

namespace Services
{
    public class Facade
    {
        private readonly IRepositoriesFactory RepositoriesFactory;
        public Facade(IRepositoriesFactory repFactory)
        {
            if (repFactory == null)
                throw new ArgumentNullException(nameof(repFactory));
            this.RepositoriesFactory = repFactory;
        }
        public User Login(string login, string password)
        {
            IUserDB userDA = RepositoriesFactory.CreateUserInterface();
            if (userDA == null)
                throw new ArgumentNullException(nameof(userDA));
            UserServices userServices = new UserServices(userDA);
            User user = userServices.getUserFromLogin(login);
            if 
        }
    }
}
