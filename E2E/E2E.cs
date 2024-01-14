using Microsoft.EntityFrameworkCore;
using Allure.Xunit.Attributes;
using Services;
using DataAccess;
using Models;
using Xunit;

namespace E2ETest
{

    [AllureSuite("E2ETest")]
    public class E2E : IDisposable
    {
        private string _conn = "Host=localhost; Port=5432; Database=web; Username=postgres; Password=0612";
        private DbContextOptions<AppDbContext> _options;

        private AppDbContext _context;

        public E2E()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>().UseNpgsql(_conn).Options;
            _context = new AppDbContext(_options);
        }
        public void Dispose() { }

        [AllureXunit]
        public void TestSetAndDeleteStudentRoom()
        {
            //Arrange
            StudentDA studentDA = new StudentDA(_context);
            RoomDA roomDA = new RoomDA(_context);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);
            int id_student = 1;
            int id_room = 4;
            //Act
            studentServices.setRoomStudent(id_student, id_room);
            //Assert
            Student result = studentServices.getStudent(id_student);

            Assert.Equal(result.Id_room, id_room);

            //End Act
            studentServices.returnRoomStudent(id_student);
            //End Assert
            result = studentServices.getStudent(id_student);
            Assert.Equal(result.Id_room, 0);
        }
    }
}