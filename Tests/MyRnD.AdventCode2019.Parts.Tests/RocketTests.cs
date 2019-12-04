using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyRnD.AdventCode2019.Parts.Tests
{
    [TestClass]
    public class RocketTests
    {
        private Rocket _rocket;

        [TestInitialize]
        public void TestInitialize()
        {
            _rocket = new Rocket();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _rocket = null;
        }

        #region Part A

        [TestMethod]
        public void Rocket_FuelCounterUpper_PartAExample1()
        {
            _rocket.Modules.Add(new Module {Mass = 12});

            Assert.AreEqual(1, _rocket.Modules.Count);
            Assert.AreEqual(2, _rocket.FuelCounterUpper);
        }

        [TestMethod]
        public void Rocket_FuelCounterUpper_PartAExample2()
        {
            _rocket.Modules.Add(new Module { Mass = 14 });

            Assert.AreEqual(1, _rocket.Modules.Count);
            Assert.AreEqual(2, _rocket.FuelCounterUpper);
        }

        [TestMethod]
        public void Rocket_FuelCounterUpper_PartAExample3()
        {
            _rocket.Modules.Add(new Module { Mass = 1969 });

            Assert.AreEqual(1, _rocket.Modules.Count);
            Assert.AreEqual(654, _rocket.FuelCounterUpper);
        }

        [TestMethod]
        public void Rocket_FuelCounterUpper_PartAExample4()
        {
            _rocket.Modules.Add(new Module { Mass = 100756 });

            Assert.AreEqual(1, _rocket.Modules.Count);
            Assert.AreEqual(33583, _rocket.FuelCounterUpper);
        }


        [TestMethod]
        public void Rocket_FuelCounterUpper_PartAExampleFrom1To4()
        {
            _rocket.Modules.Add(new Module { Mass = 12 });
            _rocket.Modules.Add(new Module { Mass = 14 });
            _rocket.Modules.Add(new Module { Mass = 1969 });
            _rocket.Modules.Add(new Module { Mass = 100756 });

            Assert.AreEqual(4, _rocket.Modules.Count);
            Assert.AreEqual(2 + 2 + 654 + 33583, _rocket.FuelCounterUpper);
        }

        #endregion

        #region Part B - Fuel itself requires fuel just like a module

        [TestMethod]
        public void Rocket_FuelCounterUpper_PartBExample1()
        {
            _rocket.Modules.Add(new Module { Mass = 12 });

            Assert.AreEqual(1, _rocket.Modules.Count);
            Assert.AreEqual(2, _rocket.FuelCounterUpper2);
        }

        [TestMethod]
        public void Rocket_FuelCounterUpper_PartBExample2()
        {
            _rocket.Modules.Add(new Module { Mass = 14 });

            Assert.AreEqual(1, _rocket.Modules.Count);
            Assert.AreEqual(2, _rocket.FuelCounterUpper2);
        }

        [TestMethod]
        public void Rocket_FuelCounterUpper_PartBExample3()
        {
            _rocket.Modules.Add(new Module { Mass = 1969 });

            Assert.AreEqual(1, _rocket.Modules.Count);
            Assert.AreEqual(654 + 216 + 70 + 21 + 5, _rocket.FuelCounterUpper2);
        }

        [TestMethod]
        public void Rocket_FuelCounterUpper_PartBExample4()
        {
            _rocket.Modules.Add(new Module { Mass = 100756 });

            Assert.AreEqual(1, _rocket.Modules.Count);
            Assert.AreEqual(33583 + 11192 + 3728 + 1240 + 411 + 135 + 43 + 12 + 2, _rocket.FuelCounterUpper2);
        }


        [TestMethod]
        public void Rocket_FuelCounterUpper_PartBExampleFrom1To4()
        {
            _rocket.Modules.Add(new Module { Mass = 12 });
            _rocket.Modules.Add(new Module { Mass = 14 });
            _rocket.Modules.Add(new Module { Mass = 1969 });
            _rocket.Modules.Add(new Module { Mass = 100756 });

            Assert.AreEqual(4, _rocket.Modules.Count);
            Assert.AreEqual(2 + 2 + (654 + 216 + 70 + 21 + 5) + (33583 + 11192 + 3728 + 1240 + 411 + 135 + 43 + 12 + 2), _rocket.FuelCounterUpper2);
        }

        #endregion
    }
}
