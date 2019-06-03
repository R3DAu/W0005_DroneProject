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
        public void LandCheck()
        {
            Assert.IsTrue(_api.Land());
        }

        [Test]
        public void TakeOffCheck()
        {
            Assert.IsTrue(_api.TakeOff());
        }

        [Test]
        public void StartCheck()
        {
            Assert.IsTrue(_api.Start());
        }

        [Test]
        public void StopCheck()
        {
            Assert.IsTrue(_api.Stop());
        }

        [Test]
        public void HoverCheck()
        {
            Assert.IsTrue(_api.Hover());
        }

        [Test]
        public void PitchForwardCheck()
        {
            Assert.IsTrue(_api.PitchForward());
        }

        [Test]
        public void PitchBackCheck()
        {
            Assert.IsTrue(_api.PitchBack());
        }

        [Test]
        public void RollLeftCheck()
        {
            Assert.IsTrue(_api.RollLeft());
        }

        [Test]
        public void RollRightCheck()
        {
            Assert.IsTrue(_api.RollRight());
        }

        [Test]
        public void AscendCheck()
        {
            Assert.IsTrue(_api.Ascend());
        }

        [Test]
        public void DescendCheck()
        {
            Assert.IsTrue(_api.Descend());
        }

        [Test]
        public void EmergencyCheck()
        {
            Assert.IsTrue(_api.Emergency());
        }

        [Test]
        public void ResetEmergencyCheck()
        {
            Assert.IsTrue(_api.ResetEmergency());
        }

        [Test]
        public void JumpCheck()
        {
            Assert.IsTrue(_api.Jump());
        }
    }
}
