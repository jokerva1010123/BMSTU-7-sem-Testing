using InterfaceDB;

namespace Services
{
    public interface IRepositoriesFactory
    {
        public IUserDB CreateUserInterface();
        public IStudentDB CreateStudentInterface();
        public IRoomDB CreateRoomInterface();
        public IThingDB CreateThingInterface();
    }
}
