using Allure.Xunit.Attributes;
using Xunit;
using Models;
using ObjectMothers;

namespace Testing.UnitTests.UnitTestsDA
{
    [AllureOwner("Viet_Anh")]
    [AllureSuite("User DataAccess Unit Tests")]
    [Collection("DBCollection")]
    public class UserDAUnitTests : IDisposable
    {
        private DBFixture fixture;
        public UserDAUnitTests(DBFixture _dbFixture)
        {
            fixture = _dbFixture;
        }
        public void Dispose() { }
        [AllureXunit]
        public void TestGetUserFromLogin()
        {
            //Arrange
            string login = "student1";
            //Action
            var result = fixture.userDA.getUserFromLogin(login);
            //Assert
            Assert.Equal(login, result.Login);
        }
        [AllureXunit]
        public void TestChangePassword()
        {
            //Arrange
            int id_user = 1;
            string newPass = "newPass";
            //Action
            fixture.userDA.changePassword(id_user, newPass);
            //Assert
            Assert.Equal(newPass, fixture.context.Users.ToList()[id_user - 1].Password);
        }
        [AllureXunit]
        public async void TestAddUser()
        {
            //Arrange
            User user = UserOM.CreateStudent(3).buildBL();
            int count = fixture.context.Users.Count() + 1;
            //Action
            fixture.userDA.addUser(user);
            //Assert
            Assert.Equal(count, fixture.context.Users.Count());
        }
    }
}
