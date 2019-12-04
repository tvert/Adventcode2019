using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRnD.AdventCode2019.D02.IntCode;

namespace MyRnD.AdventCode2019.D1.Rocket.Tests
{
    [TestClass]
    public class IntCodeComputerTests
    {
        private IntCodeComputer _intCodeComputer;

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _intCodeComputer = null;
        }

        [TestMethod]
        public void IntCodeComputer_Run_Example1()
        {
            // Arrange
            int[] opCodes = {1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50};
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList());

            {
                // Act - 1
                var actual = _intCodeComputer.Run();
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");

                // Assert - 1
                Assert.AreEqual(12, opCodes.Length);
                Assert.AreEqual(opCodes.Length, actual.Count);
                Assert.AreEqual(3500, actual[0]);
            }

            // Running a second time should produce the same effect - check the initial list was preserve.
            {
                // Act - 2
                var actual = _intCodeComputer.Run();
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");

                // Assert -2 
                Assert.AreEqual(12, opCodes.Length);
                Assert.AreEqual(opCodes.Length, actual.Count);
                Assert.AreEqual(3500, actual[0]);
            }
        }


    }
}