using Services;
using InterfaceDB;
namespace DataAccess
{
    public class RepositoriesFactory: IRepositoriesFactory
    {
        private AppDbContext _dbContext;
        public RepositoriesFactory(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUserDB CreateUserInterface()
        {
            return new UserDA(_dbContext);
        }
        public IStudentDB CreateStudentInterface()
        {
            return new StudentDA(_dbContext);
        }
        public IRoomDB CreateRoomInterface()
        {
            return new RoomDA(_dbContext);
        }
        public IThingDB CreateThingInterface()
        {
            return new ThingDA(_dbContext);
        }
    }
}
