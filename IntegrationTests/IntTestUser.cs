using Models;
using Xunit;
using Allure.Xunit.Attributes;
namespace IntegrationTests
{
    [AllureOwner("Viet Anh")]
    [AllureSuite("User Integration Tests")]
    [Collection("ITCollection")]
    public class IntTestUser : IDisposable
    {
        private readonly ITFixture _fixture;
        public IntTestUser(ITFixture fixture)
        {
            _fixture = fixture;
        }
        public void Dispose() { }
        [AllureXunit]
        public void TestAddUser()
        {
            //Arrange
            int count = _fixture.Context.Users.Count() + 1;
            User user = ObjectMothers.UserOM.CreateStudent(count).buildBL();

            //Act
            _fixture.userServices.addUser(user);

            //Assert
            Assert.Equal(count, _fixture.Context.Users.Count());
        }
        [AllureXunit]
        public void TestGetIdUser()
        {
            //Arrange
            string login = "alex";
            //Action
            int id = _fixture.userServices.getIdUser(login);
            //Assert
            Assert.Equal(1, id);
        }
        [AllureXunit]
        public void TestGetUserFromLogin()
        {
            //Arrange
            string login = "alex";
            //Action
            User user = _fixture.userServices.getUserFromLogin(login);
            //Assert
            Assert.Equal(1, user.Id);
            Assert.Equal(login, user.Login);
        }
        [AllureXunit]
        public void TestUserExists()
        {
            //Arrange
            string login = "alex";
            //Action
            int flag = _fixture.userServices.userExists(login);
            //Assert
            Assert.Equal(1, flag);
        }
    }
}
