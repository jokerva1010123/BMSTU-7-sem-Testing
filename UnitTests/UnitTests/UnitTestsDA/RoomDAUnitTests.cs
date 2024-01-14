using Allure.Xunit.Attributes;
using Xunit;

namespace Testing.UnitTests.UnitTestsDA
{
    [AllureOwner("Viet_Anh")]
    [AllureSuite("Room DataAccess Unit Tests")]
    [Collection("DBCollection")]
    public class RoomDAUnitTests : IDisposable
    {
        private DBFixture dbFixture;
        public RoomDAUnitTests(DBFixture _dbFixture)
        {
            dbFixture = _dbFixture;
        }
        public void Dispose() { }
        [AllureXunit]
        public void TestGetRoom()
        {
            //Arrange
            int id_room = 1;
            //Action
            var result = dbFixture.roomDA.getRoom(id_room);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(id_room, result.Id_room);
        }
        [AllureXunit]
        public void TestGetAllRoom()
        {
            //Arrange
            int count = dbFixture.context.Rooms.Count();
            //Action
            var result = dbFixture.roomDA.getAllRoom();
            //Assert
            Assert.Equal(count, result.Count);
        }
    }
}
