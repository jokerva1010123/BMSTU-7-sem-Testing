using Allure.Xunit.Attributes;
using InterfaceDB;
using Models;
using Moq;
using ObjectMothers;
using Services;
using Xunit;

namespace UnitTestsBL
{
    [AllureOwner("Viet_Anh")]
    [AllureSuite("Thing Services Unit Tests")]
    public class ThingServicesUnitTests
    {
        private List<Thing> things;
        private List<Student> students;
        private List<Room> rooms;
        private Mock<IStudentDB> mockIStudentDB;
        private Mock<IRoomDB> mockIRoomDB;
        public ThingServicesUnitTests()
        {
            Thing thing1 = ThingOM.createTable(1).buildBL();
            Thing thing2 = ThingOM.createChair(2).buildBL();
            Thing thing3 = ThingOM.createFree(3).buildBL();
            things = new List<Thing> { thing1, thing2, thing3 };
            Room room1 = RoomOM.createStorage(1).buildBL();
            Room room2 = RoomOM.createStudentRoom(2).buildBL();
            rooms = new List<Room> { room1, room2 };
            mockIRoomDB = new Mock<IRoomDB>();
            mockIRoomDB.Setup(repo => repo.getRoom(2))
                .Returns(rooms.Where(r => r.Id_room == 2).First);
            Student student = StudentOM.createNewStudent(1).buildBL();
            students = new List<Student> { student };
            mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getStudentById(1))
                .Returns(students.Where(s => s.Id_student == 1).First);
        }
        [AllureXunit]
        public void TestAddThing()
        {
            //Arrange
            Thing newThing = ThingOM.createTable(4).buildBL();
            Mock<IThingDB> mockIThingDB = new Mock<IThingDB>();
            mockIThingDB.Setup(repo => repo.getAllThing()).Returns(things);
            ThingServices thingServices = new ThingServices(mockIThingDB.Object, mockIRoomDB.Object, mockIStudentDB.Object);
            //Action
            int id = thingServices.addThing(newThing);
            //Assert
            mockIThingDB.Verify(repo => repo.addThing(newThing), Times.Once);
            mockIThingDB.Verify(repo => repo.getAllThing(), Times.Once);
        }
        [AllureXunit]
        public void TestGetThing()
        {
            //Arrange
            string codeThing = "Table1";
            Mock<IThingDB> mockIThingDB = new Mock<IThingDB>();
            mockIThingDB.Setup(repo => repo.getThing(codeThing))
                .Returns(things.Where(thing => thing.Code == codeThing).First);
            ThingServices thingServices = new ThingServices(mockIThingDB.Object, mockIRoomDB.Object, mockIStudentDB.Object);
            //Action
            Thing thing = thingServices.getThing(codeThing);
            //Assert
            mockIThingDB.Verify(repo => repo.getThing(codeThing), Times.Once);
            Assert.Equal(codeThing, thing.Code);
        }
        [AllureXunit]
        public void TestGetAllThing()
        {
            //Arrange
            Mock<IThingDB> mockIThingDB = new Mock<IThingDB>();
            mockIThingDB.Setup(repo => repo.getAllThing()).Returns(things);
            ThingServices thingServices = new ThingServices(mockIThingDB.Object, mockIRoomDB.Object, mockIStudentDB.Object);
            //Action
            List<Thing>? result = thingServices.getAllThing();
            //Assert
            mockIThingDB.Verify(repo => repo.getAllThing(), Times.Once);
            Assert.Equal(things.Count, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id_thing, 1, 3));
        }
        [AllureXunit]
        public void TestChangeRoomThing()
        {
            //Arrange
            string codeThing = "Chair2";
            int id_room = 2;
            Mock<IThingDB> mockIThingDB = new Mock<IThingDB>();
            mockIThingDB.Setup(repo => repo.getThing(codeThing))
                .Returns(things.Where(thing => thing.Code == codeThing).First);
            ThingServices thingServices = new ThingServices(mockIThingDB.Object, mockIRoomDB.Object, mockIStudentDB.Object);
            //Action
            thingServices.changeRoomThing(codeThing, id_room);
            //Assert
            mockIThingDB.Verify(repo => repo.getThing(codeThing), Times.Once);
            mockIThingDB.Verify(repo => repo.changeRoomThing(codeThing, id_room), Times.Once);
        }
        [AllureXunit]
        public void TestGetFreeThing()
        {
            //Arrang
            Thing newThing = ThingOM.createTable(3).buildBL();
            Mock<IThingDB> mockIThingDB = new Mock<IThingDB>();
            mockIThingDB.Setup(repo => repo.getAllThing()).Returns(things);
            ThingServices thingServices = new ThingServices(mockIThingDB.Object, mockIRoomDB.Object, mockIStudentDB.Object);
            //Action
            List<Thing> result = thingServices.getFreeThing();
            //Assert
            mockIThingDB.Verify(repo => repo.getAllThing(), Times.Once);
            Assert.Single(result);
        }
        [AllureXunit]
        public void TestTranferStudentThing()
        {
            //Arrange
            string codeThing = "Chair3";
            int id_student = 1;
            Mock<IThingDB> mockIThingDB = new Mock<IThingDB>();
            mockIThingDB.Setup(repo => repo.getThing(codeThing))
                .Returns(things.Where(t => t.Code == codeThing).FirstOrDefault);
            ThingServices thingServices = new ThingServices(mockIThingDB.Object, mockIRoomDB.Object, mockIStudentDB.Object);
            //Action
            thingServices.transferStudentThing(id_student, codeThing);
            //Assert
            mockIThingDB.Verify(repo => repo.getThing(codeThing), Times.Once);
            mockIThingDB.Verify(repo => repo.changeStudentThing(codeThing, id_student), Times.Once);
        }
        [AllureXunit]
        public void TestGetStundetThing()
        {
            //Arrange
            Mock<IThingDB> mockIThingDB = new Mock<IThingDB>();
            mockIThingDB.Setup(repo => repo.getAllThing()).Returns(things);
            ThingServices thingServices = new ThingServices(mockIThingDB.Object, mockIRoomDB.Object, mockIStudentDB.Object);
            //Action
            List<Thing> result = thingServices.getStudentThing(1);
            //Assert
            mockIThingDB.Verify(repo => repo.getAllThing(), Times.Once);
            Assert.Equal(1, result.Count);
            Assert.Equal(1, result[0].Id_student);
        }
        [AllureXunit]
        public void TestReturnThing()
        {
            //Arrange
            string codeThing = "Table1";
            int id_student = 1;
            Mock<IThingDB> mockIThingDB = new Mock<IThingDB>();
            mockIThingDB.Setup(repo => repo.getThing(codeThing))
                .Returns(things.Where(thing => thing.Code == codeThing).First);
            ThingServices thingServices = new ThingServices(mockIThingDB.Object, mockIRoomDB.Object, mockIStudentDB.Object);
            //Action
            thingServices.returnThing(id_student, codeThing);
            //Assert
            mockIThingDB.Verify(repo => repo.getThing(codeThing), Times.Once);
            mockIThingDB.Verify(repo => repo.changeStudentThing(codeThing, 0), Times.Once);
        }
    }
}
