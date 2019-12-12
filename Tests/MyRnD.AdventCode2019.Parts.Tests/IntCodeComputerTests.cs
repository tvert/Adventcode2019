using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;

namespace MyRnD.AdventCode2019.Parts.Tests
{
    [TestClass]
    public sealed class IntCodeComputerTests
    {
        private MockRepository _mockRepos;
        private Mock<IInputter> _mockInputter;
        private Mock<IOutputter> _mockOutputter;

        private IntCodeComputer _intCodeComputer;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepos = new MockRepository(MockBehavior.Default);
            _mockInputter = _mockRepos.Create<IInputter>();
            _mockOutputter = _mockRepos.Create<IOutputter>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _intCodeComputer = null;

            _mockInputter = null;
            _mockOutputter = null;
            _mockRepos = null;
        }

        #region Day 2

        [TestMethod]
        public void IntCodeComputer_Run_Day02ExampleA1()
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

        #endregion

        #region Day 5 - Part A

        [TestMethod]
        public void IntCodeComputer_Run_Day05ExampleA1()
        {
            // Arrange
            int[] opCodes = { 3, 0, 4, 0, 99 };
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]' |Opcode: {32192 % 100}|1st param: {32192 / 100}|2nd param: {32192 / 1000}|3rd param: {32192 / 10000}.");
            }
            const int expectedValue = 5485;

            _mockInputter.Setup(s => s.InputValue())
                .Returns(expectedValue);
            _mockOutputter.Setup(s => s.OutputValue(expectedValue));

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), _mockInputter.Object, _mockOutputter.Object);

            {
                // Act - 1
                var actual = _intCodeComputer.Run();
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");

                // Assert - 1
                Assert.AreEqual(5, opCodes.Length);
                Assert.AreEqual(opCodes.Length, actual.Count);
                Assert.AreEqual(expectedValue, actual[0]);
            }

            // Running a second time should produce the same effect - check the initial list was preserve.
            {
                // Act - 2
                var actual = _intCodeComputer.Run();
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");

                // Assert -2 
                Assert.AreEqual(5, opCodes.Length);
                Assert.AreEqual(opCodes.Length, actual.Count);
                Assert.AreEqual(expectedValue, actual[0]);
            }

            _mockRepos.VerifyAll();
        }


        [TestMethod]
        public void IntCodeComputer_Run_Day05ExampleA2()
        {
            // Arrange
            int[] opCodes = { 1002, 4, 3, 4, 33 };
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
                Assert.AreEqual(5, opCodes.Length);
                Assert.AreEqual(opCodes.Length, actual.Count);
                Assert.AreEqual(99, actual[4]);
            }

            // Running a second time should produce the same effect - check the initial list was preserve.
            {
                // Act - 2
                var actual = _intCodeComputer.Run();
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");

                // Assert -2 
                Assert.AreEqual(5, opCodes.Length);
                Assert.AreEqual(opCodes.Length, actual.Count);
                Assert.AreEqual(99, actual[4]);
            }

            _mockRepos.VerifyAll();
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05ExampleA3()
        {
            // Arrange
            int[] opCodes = { 1101, 100, -1, 4, 0 };
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList());

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(5, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            Assert.AreEqual(99, actual[4]);
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_TEST_Diagnostics()
        {
            // Arrange
            int[] opCodes = TestDiagnosticInput;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(1));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(678, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(10, outputtedValues.Count);
            for(int i = 0; i < outputtedValues.Count - 1; i++)
            {
                Assert.AreEqual(0, outputtedValues[i], $"At index '{i}'");
            }

            Assert.AreEqual(13933662, outputtedValues.Last());
        }

        private static int[] TestDiagnosticInput = { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1101, 37, 61, 225, 101, 34, 121, 224, 1001, 224, -49, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 6, 224, 1, 224, 223, 223, 1101, 67, 29, 225, 1, 14, 65, 224, 101, -124, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 5, 224, 224, 1, 224, 223, 223, 1102, 63, 20, 225, 1102, 27, 15, 225, 1102, 18, 79, 224, 101, -1422, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 1, 224, 1, 223, 224, 223, 1102, 20, 44, 225, 1001, 69, 5, 224, 101, -32, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 1, 224, 224, 1, 223, 224, 223, 1102, 15, 10, 225, 1101, 6, 70, 225, 102, 86, 40, 224, 101, -2494, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 6, 224, 224, 1, 223, 224, 223, 1102, 25, 15, 225, 1101, 40, 67, 224, 1001, 224, -107, 224, 4, 224, 102, 8, 223, 223, 101, 1, 224, 224, 1, 223, 224, 223, 2, 126, 95, 224, 101, -1400, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 3, 224, 1, 223, 224, 223, 1002, 151, 84, 224, 101, -2100, 224, 224, 4, 224, 102, 8, 223, 223, 101, 6, 224, 224, 1, 224, 223, 223, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 108, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 329, 101, 1, 223, 223, 1107, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 344, 101, 1, 223, 223, 8, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 359, 101, 1, 223, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 374, 101, 1, 223, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 389, 1001, 223, 1, 223, 1007, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 404, 1001, 223, 1, 223, 7, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 419, 1001, 223, 1, 223, 1008, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 434, 1001, 223, 1, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 449, 1001, 223, 1, 223, 1008, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 464, 1001, 223, 1, 223, 1108, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 479, 101, 1, 223, 223, 1108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 494, 1001, 223, 1, 223, 107, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 509, 1001, 223, 1, 223, 8, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 524, 1001, 223, 1, 223, 1007, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 539, 1001, 223, 1, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 554, 1001, 223, 1, 223, 1107, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 569, 101, 1, 223, 223, 1108, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 584, 1001, 223, 1, 223, 1007, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 599, 101, 1, 223, 223, 107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 614, 1001, 223, 1, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 629, 101, 1, 223, 223, 7, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 644, 101, 1, 223, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 659, 1001, 223, 1, 223, 108, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226 };


        #endregion

        #region Day 5 - Part B

        private static readonly int[] ExampleB1positionMode = { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
        private static readonly int[] ExampleB2positionMode = { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
        private static readonly int[] ExampleB3positionMode = { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };

        private static readonly int[] ExampleB1immediateMode = { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
        private static readonly int[] ExampleB2immediateMode = { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
        private static readonly int[] ExampleB3immediateMode = { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };

        private static readonly int[] ExampleB4LargerSample =
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125,
            20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        };

        [TestMethod]
        public void IntCodeComputer_Run_Day05_TEST_Thermal_Radiators()
        {
            // Arrange
            int[] opCodes = TestDiagnosticInput;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(5));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(678, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(2369720, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB1_PositionMode_NotEquals_8()
        {
            // Arrange
            int[] opCodes = ExampleB1positionMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(5));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(11, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(0, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB1_PositionMode_Equals_8()
        {
            // Arrange
            int[] opCodes = ExampleB1positionMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(8));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(11, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(1, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB2_PositionMode_LessThan_8()
        {
            // Arrange
            int[] opCodes = ExampleB2positionMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(5));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(11, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(1, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB2_PositionMode_GreaterThan_8()
        {
            // Arrange
            int[] opCodes = ExampleB2positionMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(9));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(11, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(0, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB3_PositionMode_JumpDisplay0_0()
        {
            // Arrange
            int[] opCodes = ExampleB3positionMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(0));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(16, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(0, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB3_PositionMode_JumpDisplay1_5()
        {
            // Arrange
            int[] opCodes = ExampleB3positionMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(5));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(16, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(1, outputtedValues.Last());
        }




        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB1_ImmediateMode_NotEquals_8()
        {
            // Arrange
            int[] opCodes = ExampleB1immediateMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(5));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(11, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(0, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB1_ImmediateMode_Equals_8()
        {
            // Arrange
            int[] opCodes = ExampleB1immediateMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(8));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(11, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(1, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB2_ImmediateMode_LessThan_8()
        {
            // Arrange
            int[] opCodes = ExampleB2immediateMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(5));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(11, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(1, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB2_ImmediateMode_GreaterThan_8()
        {
            // Arrange
            int[] opCodes = ExampleB2immediateMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(9));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(11, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(0, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB3_ImmediateMode_JumpDisplay0_0()
        {
            // Arrange
            int[] opCodes = ExampleB3immediateMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(0));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(13, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(0, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB3_ImmediateMode_JumpDisplay1_5()
        {
            // Arrange
            int[] opCodes = ExampleB3immediateMode;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(5));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(13, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(1, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB4_LargerSample_Display999_7()
        {
            // Arrange
            int[] opCodes = ExampleB4LargerSample;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(7));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(47, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(999, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB4_LargerSample_Display1000_8()
        {
            // Arrange
            int[] opCodes = ExampleB4LargerSample;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(8));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(47, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(1000, outputtedValues.Last());
        }

        [TestMethod]
        public void IntCodeComputer_Run_Day05_ExampleB4_LargerSample_Display1001_9()
        {
            // Arrange
            int[] opCodes = ExampleB4LargerSample;
            {
                var opCodesAsString = string.Concat(opCodes.Select(s => s + ", "));
                System.Console.WriteLine($"Initial '[{opCodesAsString}]'.");
            }

            _intCodeComputer = new IntCodeComputer(opCodes.ToList(), new AutoInputter(9));

            // Act
            var actual = _intCodeComputer.Run();
            {
                var opCodesAsString = string.Concat(actual.Select(s => s + ", "));
                System.Console.WriteLine($"Result '[{opCodesAsString}]'.");
            }

            // Assert
            _mockRepos.VerifyAll();
            Assert.AreEqual(47, opCodes.Length);
            Assert.AreEqual(opCodes.Length, actual.Count);
            List<int> outputtedValues = _intCodeComputer.Outputter.OutputValues;
            Assert.AreEqual(1, outputtedValues.Count);
            Assert.AreEqual(1001, outputtedValues.Last());
        }
        #endregion
    }
}