using Allure.Xunit.Attributes;
using ObjectMothers;
using Xunit;

namespace Testing.UnitTests.UnitTestsDA
{
    [AllureOwner("Viet_Anh")]
    [AllureSuite("Thing DataAccess Unit Tests")]
    [Collection("DBCollection")]
    public class ThingDAUnitTests : IDisposable
    {
        private DBFixture fixture;
        public ThingDAUnitTests(DBFixture _dbFixture)
        {
            fixture = _dbFixture;
        }
        public void Dispose() { }
        [AllureXunit]
        public async void TestGetAllThing()
        {
            //Arrange
            int count = fixture.context.Things.Count();
            //Action
            var result = fixture.thingDA.getAllThing();
            //Assert
            Assert.Equal(count, result.Count);
        }
        [AllureXunit]
        public async void TestGetThing()
        {
            //Arrange
            string codeThing = "Chair1";
            //Action
            var thing = fixture.thingDA.getThing(codeThing);
            //Assert
            Assert.NotNull(thing);
            Assert.Equal(codeThing, thing.Code);
        }
        [AllureXunit]
        public async void TestAddThing()
        {
            //Arrange
            int count = fixture.context.Things.Count() + 1;
            var thing = ThingOM.createChair(count).buildBL();
            //Action
            var result = fixture.thingDA.addThing(thing);
            //Assert
            Assert.Equal(count, fixture.context.Things.Count());
            Assert.Equal(count, result);
        }
        [AllureXunit]
        public async void TestChangeRoomThing()
        {
            //Arrange
            int id_room = 2;
            string codeThing = "Chair3";
            //Action
            int result = fixture.thingDA.changeRoomThing(codeThing, id_room);
            //Assert
            Assert.Equal(1, result);
        }
        [AllureXunit]
        public async void TestChangeStudentThing()
        {
            //Arrange
            int id_student = 1;
            string codeThing = "Chair3";
            //Action
            int result = fixture.thingDA.changeStudentThing(codeThing, id_student);
            //Assert
            Assert.Equal(1, result);
        }
    }
}
