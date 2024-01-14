using Models;
using Services;
using InterfaceDB;
using Xunit;
using Allure.Xunit.Attributes;
using Moq;
using ObjectMothers;
using Error;

namespace Testing.UnitTests.UnitTestsBL
{
    [AllureOwner("Viet_Anh")]
    [AllureSuite("User Services Unit Tests")]
    public class UserServicesUnitTests
    {
        private List<User> users;
        public UserServicesUnitTests()
        {
            User user1 = UserOM.CreateStudent(1).buildBL();
            User user2 = UserOM.CreateKamedan(2).buildBL();
            User user3 = UserOM.CreateManager(3).buildBL();
            users = new List<User>() { user1, user2, user3 };
        }
        [AllureXunit]
        public void TestAddUser()
        {
            //Arrange
            User newUser = UserOM.CreateStudent(4).buildBL();
            var mockIUserDB = new Mock<IUserDB>();
            mockIUserDB.Setup(repo => repo.addUser(newUser))
                .Returns(newUser.Id);
            UserServices userServices = new UserServices(mockIUserDB.Object);
            //Action
            int id_newUser = userServices.addUser(newUser);
            //Assert
            mockIUserDB.Verify(repo => repo.addUser(newUser), Times.Once);
            Assert.Equal(newUser.Id, id_newUser);
        }
        [AllureXunit]
        public void TestAddExistsUser()
        {
            //Arrange
            User newUser = UserOM.CreateStudent(1).buildBL();
            var mockIUserDB = new Mock<IUserDB>();
            mockIUserDB.Setup(repo => repo.getUserFromLogin(newUser.Login))
                .Returns(newUser);
            UserServices userServices = new UserServices(mockIUserDB.Object);
            //Action & Assert
            Assert.Throws<UserExistsException>(() => userServices.addUser(newUser));
        }
        [AllureXunit]
        public void TestGetIdUser()
        {
            //Arrange
            string login = "student1";
            var mockIUserDB = new Mock<IUserDB>();
            mockIUserDB.Setup(repo => repo.getUserFromLogin(login))
                .Returns(users.Where(s => s.Login == login).FirstOrDefault());
            UserServices userServices = new UserServices(mockIUserDB.Object);
            //Action
            int id = userServices.getIdUser(login);
            //Assert
            mockIUserDB.Verify(repo => repo.getUserFromLogin(login), Times.Once);
            Assert.Equal(1, id);
        }
        [AllureXunit]
        public void TestGetUserFromLogin()
        {
            //Arrange
            var mockIUserDB = new Mock<IUserDB>();
            mockIUserDB.Setup(repo => repo.getUserFromLogin("student1"))
                .Returns(users.Where(s => s.Login == "student1").FirstOrDefault());
            UserServices userServices = new UserServices(mockIUserDB.Object);
            //Action
            User user = userServices.getUserFromLogin("student1");
            //Assert
            mockIUserDB.Verify(repo => repo.getUserFromLogin("student1"), Times.Once);
            Assert.Equal(1, user.Id);
            Assert.Equal("student1", user.Login);
        }
        [AllureXunit]
        public void TestUserExists()
        {
            //Arrange
            var mockIUserDB = new Mock<IUserDB>();
            mockIUserDB.Setup(repo => repo.getUserFromLogin("student1"))
                .Returns(users.Where(s => s.Login == "student1").FirstOrDefault());
            UserServices userServices = new UserServices(mockIUserDB.Object);
            //Action
            int flag = userServices.userExists("student1");
            //Assert
            mockIUserDB.Verify(repo => repo.getUserFromLogin("student1"), Times.Once);
            Assert.Equal(1, flag);
        }
    }
}