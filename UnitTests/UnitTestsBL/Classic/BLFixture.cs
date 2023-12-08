using Xunit;
using DataAccess;
using Services;

namespace UnitTestsBL
{
    public class BLFixture: IDisposable
    {
        private string _connectionString = "Server=localhost;Database=web;Username=postgres;Password=0612";
        public AppDbContext Context;
        public RoomServices roomService;
        public BLFixture() 
        {
            Context = new AppDbContext(_connectionString);
            roomService = new RoomServices(new RoomDA(Context));
        }
        public void Dispose()
        {
            Context.ChangeTracker.Clear();
            Context.Dispose();
        }
    }
    [CollectionDefinition("BLCollection")]
    public class BLCollection : ICollectionFixture<BLFixture>
    {
    }
}
