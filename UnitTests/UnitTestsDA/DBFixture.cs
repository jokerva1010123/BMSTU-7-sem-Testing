using DataAccess;
using Microsoft.EntityFrameworkCore;
using ObjectMothers;
using Xunit;

namespace UnitTestsDA
{
    public class DBFixture: IDisposable
    {
        private DbContextOptions<AppDbContext> _options;
        public AppDbContext context;
        public RoomDA roomDA;
        public StudentDA studentDA;
        public ThingDA thingDA;
        public UserDA userDA;
        public DBFixture()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseInMemoryDatabase(databaseName: "app")
                            .Options;
            context = new AppDbContext(_options);

            //Rooms
            context.Rooms.Add(RoomOM.createStorage(1).buildDA());
            context.Rooms.Add(RoomOM.createStudentRoom(2).buildDA());
            context.Rooms.Add(RoomOM.createStudentRoom(3).buildDA());
            context.Rooms.Add(RoomOM.createStudentRoom(4).buildDA());

            //Students
            context.Students.Add(StudentOM.createNewStudent(1).buildIdRoom(2).buildDA());
            context.Students.Add(StudentOM.createNewStudent(2).buildIdRoom(3).buildDA());

            //Things
            context.Things.Add(ThingOM.createChair(1).buildDA());
            context.Things.Add(ThingOM.createTable(2).buildDA());
            context.Things.Add(ThingOM.createFree(3).buildDA());

            //Users
            context.Users.Add(UserOM.CreateStudent(1).buildDA());
            context.Users.Add(UserOM.CreateStudent(2).buildDA());

            context.SaveChanges();

            roomDA = new RoomDA(context);
            userDA = new UserDA(context);
            studentDA = new StudentDA(context);
            thingDA = new ThingDA(context);

        }
        public void Dispose() 
        {
            context.ChangeTracker.Clear();
            context.Dispose();
        }
    }
}
