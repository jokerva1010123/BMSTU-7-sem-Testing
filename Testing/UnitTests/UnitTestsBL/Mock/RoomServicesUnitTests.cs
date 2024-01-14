using Allure.Xunit.Attributes;
using Error;
using InterfaceDB;
using Models;
using Moq;
using ObjectMothers;
using Services;
using Xunit;

namespace Testing.UnitTests.UnitTestsBL.Mock
{
    [AllureOwner("Viet_Anh")]
    [AllureSuite("Room Services Unit Tests")]
    public class RoomServicesUnitTests
    {
        private List<Room> rooms;
        public RoomServicesUnitTests()
        {
            Room room1 = RoomOM.createStorage(1).buildBL();
            Room room2 = RoomOM.createStudentRoom(2).buildBL();
            Room room3 = RoomOM.createStudentRoom(3).buildBL();
            rooms = new List<Room>() { room1, room2, room3 };
        }
        [AllureXunit]
        public void TestGetRoom()
        {
            //Arrage
            int id_room = 1;
            var mockIRoomDB = new Mock<IRoomDB>();
            mockIRoomDB.Setup(repo => repo.getRoom(id_room))
                .Returns(rooms.Where(r => r.Id_room == id_room).FirstOrDefault());
            RoomServices roomServices = new RoomServices(mockIRoomDB.Object);
            //Action
            Room result = roomServices.getRoom(id_room);
            //Assert
            mockIRoomDB.Verify(repo => repo.getRoom(id_room), Times.Once);
            Assert.Equal(id_room, result.Id_room);
            Assert.Equal(101, result.Number);
            Assert.Equal(RoomType.Storage, result.RoomTypes);
        }
        [AllureXunit]
        public void TestGetNotExistsRoom()
        {
            //Arrage
            int id_room = 4;
            var mockIRoomDB = new Mock<IRoomDB>();
            mockIRoomDB.Setup(repo => repo.getRoom(id_room))
                .Returns(rooms.Where(r => r.Id_room == id_room).FirstOrDefault());
            RoomServices roomServices = new RoomServices(mockIRoomDB.Object);
            //Action & Assert
            _ = Assert.Throws<RoomNotFoundException>(() => roomServices.getRoom(id_room));
        }
        [AllureXunit]
        public void TestGetAllRoom()
        {
            //Arrange
            var mockIRoomDB = new Mock<IRoomDB>();
            mockIRoomDB.Setup(repo => repo.getAllRoom())
                .Returns(rooms);
            RoomServices roomServices = new RoomServices(mockIRoomDB.Object);
            //Action
            List<Room> result = roomServices.getAllRoom();
            //Assert
            mockIRoomDB.Verify(repo => repo.getAllRoom(), Times.Once);
            Assert.Equal(3, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id_room, low: 1, high: 3));
        }
    }
}
