using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyRnD.AdventCode2019.Parts.Tests
{
    [TestClass]
    public sealed class UniversalOrbitMapTests
    {
        private UniversalOrbitMap _universalOrbitMap;

        [TestInitialize]
        public void TestInitialize()
        {
            _universalOrbitMap = new UniversalOrbitMap();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _universalOrbitMap = null;
        }

        #region Part A

        [TestMethod]
        public void UniversalOrbitMap_NumberOfOrbits_PartAExample1()
        {
            // Arrange
            string map = "A)B" + Environment.NewLine +
                         "B)C" + Environment.NewLine +
                         "C)D" + Environment.NewLine +
                         "COM)A";
            _universalOrbitMap.UpdateFromString(map);

            // Act
            int numberOfOrbits = _universalOrbitMap.NumberOfOrbits;

            // Assert
            Assert.AreEqual(10, numberOfOrbits);
        }

        [TestMethod]
        public void UniversalOrbitMap_NumberOfOrbits_PartAExample2()
        {
            // Arrange
            string map = "COM)B" + Environment.NewLine +
                         "B)C" + Environment.NewLine +
                         "C)D" + Environment.NewLine +
                         "D)E" + Environment.NewLine +
                         "E)F" + Environment.NewLine +
                         "B)G" + Environment.NewLine +
                         "G)H" + Environment.NewLine +
                         "D)I" + Environment.NewLine +
                         "E)J" + Environment.NewLine +
                         "J)K" + Environment.NewLine +
                         "K)L";
            _universalOrbitMap.UpdateFromString(map);

            // Act
            int numberOfOrbits = _universalOrbitMap.NumberOfOrbits;

            // Assert
            Assert.AreEqual(42, numberOfOrbits);
        }

        #endregion

        [TestMethod]
        public void UniversalOrbitMap_MinimumOrbitalTransfer_PartBExample1()
        {
            // Arrange
            string map = "COM)B" + Environment.NewLine +
                         "B)C" + Environment.NewLine +
                         "C)D" + Environment.NewLine +
                         "D)E" + Environment.NewLine +
                         "E)F" + Environment.NewLine +
                         "B)G" + Environment.NewLine +
                         "G)H" + Environment.NewLine +
                         "D)I" + Environment.NewLine +
                         "E)J" + Environment.NewLine +
                         "J)K" + Environment.NewLine +
                         "K)L" + Environment.NewLine +
                         "K)YOU" + Environment.NewLine +
                         "I)SAN";
            _universalOrbitMap.UpdateFromString(map);

            // Act
            (bool hasB, int minimumOrbitalTransfer) = _universalOrbitMap.MinimumOrbitalTransfer("YOU", "SAN");

            // Assert
            Assert.IsTrue(hasB, minimumOrbitalTransfer.ToString());
            Assert.AreEqual(4, minimumOrbitalTransfer);
        }

    }
}