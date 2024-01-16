using Models;
using Xunit;
using Allure.Xunit.Attributes;
using InterfaceDB;
using Moq;
using ObjectMothers;
using Services;
namespace IntegrationTests
{
    [AllureOwner("Viet Anh")]
    [AllureSuite("Thing Integration Tests")]
    [Collection("ITCollection")]
    public class IntTestThing : IDisposable
    {
        private readonly ITFixture _fixture;
        public IntTestThing(ITFixture fixture)
        {
            _fixture = fixture;
        }
        public void Dispose() { }
        /*[AllureXunit]
        public void TestAddThing()
        {
            //Arrange
            Thing newThing = ThingOM.createTable(10).buildBL();
            //Action
            int id = _fixture.thingServices.addThing(newThing);
            //Assert
            Assert.Equal(10, id);
        }*/
        [AllureXunit]
        public void TestGetThing()
        {
            //Arrange
            string codeThing = "1233321";
            //Action
            Thing thing = _fixture.thingServices.getThing(codeThing);
            //Assert           
            Assert.Equal(codeThing, thing.Code);
        }
        [AllureXunit]
        public void TestGetAllThing()
        {
            //Arrange
            
            //Action
            List<Thing>? result = _fixture.thingServices.getAllThing();
            //Assert
            Assert.Equal(_fixture.Context.Things.Count(), result.Count);
        }
    }
}
