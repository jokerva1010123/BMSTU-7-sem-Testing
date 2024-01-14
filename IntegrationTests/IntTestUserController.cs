using Services;
using InterfaceDB;
using DataAccess;
using Models;
using Xunit;
using Allure.Xunit.Attributes;
using 
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
            User
        }
    }
}
