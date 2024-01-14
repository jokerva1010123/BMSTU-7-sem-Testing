using Allure.Xunit.Attributes;
using ObjectMothers;
using Xunit;

namespace Testing.UnitTests.UnitTestsDA
{
    [AllureOwner("Viet_Anh")]
    [AllureSuite("Student DataAccess Unit Tests")]
    [Collection("DBCollection")]
    public class StudentDAUnitTests : IDisposable
    {
        private DBFixture fixture;
        public StudentDAUnitTests(DBFixture _dbFixture)
        {
            fixture = _dbFixture;
        }
        public void Dispose() { }
        [AllureXunit]
        public void TestGetAllStudent()
        {
            //Arrange
            int count = fixture.context.Students.Count();
            //Action
            var result = fixture.studentDA.getAllStudent();
            //Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
        [AllureXunit]
        public void TestGetStudentByCode()
        {
            //Arrange
            string studentCode = "alex1IU7";
            //Action
            var result = fixture.studentDA.getStudentByCode(studentCode);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(studentCode, result.StudentCode);
        }
        [AllureXunit]
        public void TestGetStudentById()
        {
            //Arrange
            int id = 1;
            //Action
            var result = fixture.studentDA.getStudentById(id);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id_student);
        }
        [AllureXunit]
        public void TestAddStudent()
        {
            //Arrange
            var newStudent = StudentOM.createNewStudent(3).buildBL();
            int count = fixture.context.Students.Count() + 1;
            //Action
            fixture.studentDA.addStudent(newStudent);
            int result = fixture.context.Students.Count();
            //Assert
            Assert.Equal(count, result);
        }
        [AllureXunit]
        public void TestUpdateStudent()
        {
            //Arrange
            int id = 1;
            string newName = "bob";
            var newStudent = StudentOM.createNewStudent(id).buildName(newName).buildBL();
            //Action
            int result = fixture.studentDA.updateStudent(newStudent);
            //Assert
            Assert.Equal(1, result);
        }
        [AllureXunit]
        public void TestChangeRoom()
        {
            //Arrange
            int id_room = 4;
            string studentCode = "alex1IU7";
            //Action
            int result = fixture.studentDA.changeRoom(studentCode, id_room);
            //Assert
            Assert.Equal(1, result);
        }
    }
}
