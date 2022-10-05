using Model;

namespace UnitTest
{
    [TestClass]
    public class HumanResourcesTests
    {
        private HumanResources _humanResources;

        public HumanResourcesTests()
        {
            var humanResources = new HumanResources();
        }

        [TestMethod]
        public void Can_AddWorker()
        {
            // arrange
            var name = "Juan";
            var birthdate = new DateTime(1995, 12, 24);
            var email = "juan@gmail.com";
            var phone = 88888888;
            var department = Departments.Automation;

            var resourcesCount = _humanResources.Count;

            // act
            _humanResources.AddWorker(name, birthdate, email, phone, department);

            // assert
            Assert.AreEqual(resourcesCount + 1, _humanResources.Count);
        }
    }
}