using API = ATeam_DroneController.src.api;
using NUnit.Framework;

namespace WARD_UnitTesting
{
    [TestFixture]
    public class apiTest
    {
        private API _api;

        [SetUp]
        public void Setup()
        {
            _api = new API();
        }

        [Test]
        public void StartCheck()
        {
            Assert.IsTrue(_api.Start());
        }

        [Test]
        public void TakeOffCheck()
        {
            Assert.IsTrue(_api.TakeOff());
        }


    }
}
