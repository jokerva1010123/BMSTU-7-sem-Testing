using Services;
using InterfaceDB;
using DataAccess;
using Models;
using Xunit;
using Allure.Xunit.Attributes;
using ObjectMothers;
namespace IntegrationTests
{
    [AllureOwner("Viet Anh")]
    [AllureSuite("User Controller Integration Tests")]
    [Collection("ITCollection")]
    public class IntTestUserController : IDisposable
    {
        private readonly ITFixture _fixture;
        public IntTestUserController(ITFixture fixture)
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
    }
}
