using Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace IntegrationTests
{
    public class ITFixture : IDisposable
    {
        private string _conn = "Server=localhost;Database=web;Username=postgres;Password=0612";
        private DbContextOptions<AppDbContext> _options;

        public AppDbContext Context;
        public UserServices userServices;
        public StudentServices studentServices;
        public ThingServices thingServices;
        public RoomServices roomServices;
        public ITFixture()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                                .UseNpgsql(_conn)
                                .Options;
            Context = new AppDbContext(_options);

            RoomDA roomDA = new RoomDA(Context);
            UserDA userDA = new UserDA(Context);
            StudentDA studentDA = new StudentDA(Context);
            ThingDA thingDA = new ThingDA(Context);

            userServices = new UserServices(userDA);
            thingServices = new ThingServices(thingDA, roomDA, studentDA);
            studentServices = new StudentServices(studentDA, roomDA);
            roomServices = new RoomServices(roomDA);
        }

        public void Dispose()
        {
            Context.ChangeTracker.Clear();
            Context.Dispose();
        }
    }

    [CollectionDefinition("ITCollection")]
    public class ITCollection : ICollectionFixture<ITFixture>
    {
    }
}