using Xunit;
using Allure.Xunit.Attributes;
using Models;
using Error;

namespace Testing.UnitTests.UnitTestsBL.Classic
{
    [AllureSuite("Classic Room Unit Tests")]
    [Collection("BLCollection")]
    public class RoomUnitTests : IDisposable
    {
        private BLFixture _fixture;
        public RoomUnitTests(BLFixture fixture)
        {
            _fixture = fixture;
        }
        public void Dispose() { }

        [AllureXunit]
        public void TestGetAllRoom()
        {
            //Arrange
            int roomCount = _fixture.Context.Rooms.Count();
            //Act
            List<Room> result = _fixture.roomService.getAllRoom();
            //Assert
            Assert.Equal(roomCount, result.Count);
        }
        [AllureXunit]
        public void TestGetRoomFailed()
        {
            //Arrange
            int id_room = 100;
            //Act - Assert
            Assert.Throws<RoomNotFoundException>(() => _fixture.roomService.getRoom(id_room));
        }
    }
}
