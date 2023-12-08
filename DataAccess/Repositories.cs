using InterfaceDB;

namespace DataAccess
{
    public class Repositories
    {
        private readonly string conn;
        public Repositories(string conn)
        {
            this.conn = conn;
        }
        public IRoomDB CreateRoomDB()
        {
            return new RoomDA(new AppDbContext(conn));
        }
        public IStudentDB CreateStudentDB()
        {
            return new StudentDA(new AppDbContext(conn));
        }
        public IThingDB CreateThingDB()
        {
            return new ThingDA(new AppDbContext(conn));
        }
        public IUserDB CreateUserDB()
        {
            return new UserDA(new AppDbContext(conn));
        }

    }
}
