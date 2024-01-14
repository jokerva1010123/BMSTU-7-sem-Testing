using Models;
using Xunit;
using Allure.Xunit.Attributes;
using Error;
using InterfaceDB;
using Moq;
using Services;
namespace IntegrationTests
{
    [AllureOwner("Viet Anh")]
    [AllureSuite("Room Integration Tests")]
    [Collection("ITCollection")]
    public class IntTestRoom : IDisposable
    {
        private readonly ITFixture _fixture;
        public IntTestRoom(ITFixture fixture)
        {
            _fixture = fixture;
        }
        public void Dispose() { }
        [AllureXunit]
        public void TestGetRoom()
        {
            //Arrage
            int id_room = 1;
            //Action
            Room result = _fixture.roomServices.getRoom(id_room);
            //Assert
            Assert.Equal(id_room, result.Id_room);
            Assert.Equal(101, result.Number);
        }
        [AllureXunit]
        public void TestGetNotExistsRoom()
        {
            //Arrage
            int id_room = 0;
            //Action & Assert
            _ = Assert.Throws<RoomNotFoundException>(() => _fixture.roomServices.getRoom(id_room));
        }
        [AllureXunit]
        public void TestGetAllRoom()
        {
            //Arrange
           
            //Action
            List<Room> result = _fixture.roomServices.getAllRoom();
            //Assert          
            Assert.Equal(11, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id_room, low: 1, high: 11));
        }
    }
}
