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
    [AllureSuite("Student Services Unit Tests")]
    public class StudentServicesUnitTests
    {
        private List<Student> students;
        private List<Room> rooms;
        private Mock<IRoomDB> mockIRoomDB;
        public StudentServicesUnitTests()
        {
            Student student1 = StudentOM.createNewStudent(1).buildBL();
            Student student2 = StudentOM.createNewStudent(2).buildBL();
            Student student3 = StudentOM.createNewStudent(3).buildBL();
            students = new List<Student>() { student1, student2, student3 };
            Room room = RoomOM.createStudentRoom(4).buildBL();
            rooms = new List<Room>() { room };
            mockIRoomDB = new Mock<IRoomDB>();
        }
        [AllureXunit]
        public void TestAddStudent()
        {
            //Arrange
            Student newStudent = StudentOM.createNewStudent(4).buildBL();
            Mock<IStudentDB> mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.addStudent(newStudent))
                .Returns(newStudent.Id_student);
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action
            int result = studentServices.addStudent(newStudent);
            //Assert
            mockIStudentDB.Verify(repo => repo.addStudent(newStudent), Times.Once);
            Assert.Equal(newStudent.Id_student, result);
        }
        [AllureXunit]
        public void TestAddExistStudent()
        {
            //Arrange
            Student newStudent = StudentOM.createNewStudent(3).buildBL();
            Mock<IStudentDB> mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getStudentByCode(newStudent.StudentCode))
                .Returns(newStudent);
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action & Assert
            _ = Assert.Throws<AddStudentErrorException>(() => studentServices.addStudent(newStudent));
        }
        [AllureXunit]
        public void TestGetIdStudentFromCode()
        {
            //Arrange
            string code = "alex1IU7";
            Mock<IStudentDB> mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getStudentByCode(code))
                .Returns(students[0]);
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action
            int result = studentServices.getIdStudentFromCode(code);
            //Assert
            mockIStudentDB.Verify(repo => repo.getStudentByCode(code), Times.Once);
            Assert.Equal(1, result);
        }
        [AllureXunit]
        public void TestGetRoomStudent()
        {
            //Arrange
            int id_student = 1;
            int id_room = 1;
            Mock<IStudentDB> mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getStudentById(id_student))
                .Returns(students[0]);
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action
            int result = studentServices.getRoomStudent(id_student);
            //Assert
            mockIStudentDB.Verify(repo => repo.getStudentById(id_student), Times.Once);
            Assert.Equal(id_room, result);
        }
        [AllureXunit]
        public void TestGetStudent()
        {
            //Arrange
            var mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getStudentById(1))
                .Returns(students.Where(s => s.Id_student == 1).FirstOrDefault());
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action
            Student result = studentServices.getStudent(1);
            //Asssert
            mockIStudentDB.Verify(repo => repo.getStudentById(1), Times.Once);
            Assert.Equal(students[0], result);
        }
        [AllureXunit]
        public void TestGetAllStudent()
        {
            //Arrange
            var mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getAllStudent())
                .Returns(students);
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action
            List<Student> result = studentServices.getAllStudent();
            //Assert
            mockIStudentDB.Verify(repo => repo.getAllStudent(), Times.Once);
            Assert.Equal(3, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id_room, low: 1, high: 3));
        }
        [AllureXunit]
        public void TestSetRoomStudent()
        {
            //Arrange
            var mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getStudentById(1))
                .Returns(students.Where(s => s.Id_student == 1).FirstOrDefault());
            mockIRoomDB.Setup(repo => repo.getRoom(4)).Returns(rooms.Where(r => r.Id_room == 4).FirstOrDefault());
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action
            studentServices.setRoomStudent(1, 4);
            //Assert
            mockIStudentDB.Verify(repo => repo.getStudentById(1), Times.Once);
            mockIStudentDB.Verify(repo => repo.changeRoom(It.IsAny<string>(), 4), Times.Once);
        }
        [AllureXunit]
        public void TestReturnRoomStudent()
        {
            //Arrange
            var mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getStudentById(1))
                .Returns(students.Where(s => s.Id_student == 1).FirstOrDefault());
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action
            studentServices.returnRoomStudent(1);
            //Assert
            mockIStudentDB.Verify(repo => repo.getStudentById(1), Times.Once);
            mockIStudentDB.Verify(repo => repo.changeRoom(It.IsAny<string>(), 0), Times.Once);
        }
        [AllureXunit]
        public void TestChangeGroupStudent()
        {
            //Arrage
            Mock<IStudentDB> mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getStudentById(1))
                .Returns(students.Where(s => s.Id_student == 1).FirstOrDefault());
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action
            studentServices.changeStudentGroup(1, "IU6");
            //Assert
            mockIStudentDB.Verify(repo => repo.getStudentById(1), Times.Once);
            mockIStudentDB.Verify(repo => repo.updateStudent(It.IsAny<Student>()), Times.Once);
        }
        [AllureXunit]
        public void TestChangeNameStudent()
        {
            //Arrage
            Mock<IStudentDB> mockIStudentDB = new Mock<IStudentDB>();
            mockIStudentDB.Setup(repo => repo.getStudentById(1))
                .Returns(students.Where(s => s.Id_student == 1).FirstOrDefault());
            StudentServices studentServices = new StudentServices(mockIStudentDB.Object, mockIRoomDB.Object);
            //Action
            studentServices.changeStudentName(1, "bob");
            //Assert
            mockIStudentDB.Verify(repo => repo.getStudentById(1), Times.Once);
            mockIStudentDB.Verify(repo => repo.updateStudent(It.IsAny<Student>()), Times.Once);
        }
    }
}
