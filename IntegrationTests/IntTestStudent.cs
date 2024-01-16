using Models;
using Xunit;
using Allure.Xunit.Attributes;
using Error;
using InterfaceDB;
using Moq;
using ObjectMothers;
using Services;
namespace IntegrationTests
{
    [AllureOwner("Viet Anh")]
    [AllureSuite("Student Integration Tests")]
    [Collection("ITCollection")]
    public class IntTestStudent : IDisposable
    {
        private readonly ITFixture _fixture;
        public IntTestStudent(ITFixture fixture)
        {
            _fixture = fixture;
        }
        public void Dispose() { }
        [AllureXunit]
        public void TestGetIdStudentFromCode()
        {
            //Arrange
            string code = "1234321";
            //Action
            int result = _fixture.studentServices.getIdStudentFromCode(code);
            //Assert
            Assert.Equal(1, result);
        }
        [AllureXunit]
        public void TestGetRoomStudent()
        {
            //Arrange
            int id_student = 2;
            int id_room = 3;
            //Action
            int result = _fixture.studentServices.getRoomStudent(id_student);
            //Assert
            Assert.Equal(id_room, result);
        }
        [AllureXunit]
        public void TestGetStudent()
        {
            //Arrange
            int id_student = 1;
            //Action
            Student result = _fixture.studentServices.getStudent(id_student);
            //Asssert
            Assert.Equal(id_student, result.Id_student);
        }
        [AllureXunit]
        public void TestGetAllStudent()
        {
            //Arrange
            
            //Action
            List<Student>? result = _fixture.studentServices.getAllStudent();
            //Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id_student, low: 1, high: 2));
        }
    }
}
