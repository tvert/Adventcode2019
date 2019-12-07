using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyRnD.AdventCode2019.Parts.Tests
{
    [TestClass]
    public sealed class PasswordEvaluatorTests
    {
        private PasswordEvaluator _passwordEvaluator;

        const int LowerLimit = 372037;
        private const int HigherLimit = 905157;


        [TestInitialize]
        public void TestInitialize()
        {
            _passwordEvaluator = new PasswordEvaluator();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _passwordEvaluator = null;
        }

        #region Part A

        [TestMethod]
        public void PasswordEvaluator_ValidateNumber_PartAExample1()
        {
            // Arrange
            const int number = 111111;

            // Act
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber(number, LowerLimit, HigherLimit);

            // Assert
            Assert.IsTrue(isValid, errorMsg);
            Assert.IsNull(errorMsg, errorMsg);
        }

        [TestMethod]
        public void PasswordEvaluator_ValidateNumber_PartAExample2()
        {
            // Arrange
            const int number = 223450;

            // Act
            (bool isValid, string errorMsg)  = _passwordEvaluator.ValidateNumber(number, LowerLimit, HigherLimit);

            // Assert
            Assert.IsFalse(isValid, number.ToString());
            Assert.AreEqual("Rule 4 is broken: Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679) '50' (at position 6).",
                errorMsg, number.ToString());
        }


        [TestMethod]
        public void PasswordEvaluator_ValidateNumber_PartAExample3()
        {
            // Arrange
            const int number = 123789;

            // Act
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber(number, LowerLimit, HigherLimit);

            // Assert
            Assert.IsFalse(isValid, number.ToString());
            Assert.AreEqual("Rule 3 is broken: Two adjacent digits are the same (like 22 in 122345) '123789'.",
                errorMsg, number.ToString());
        }

        #endregion

        #region Part B

        [TestMethod]
        public void PasswordEvaluator_ValidateNumber2_PartBExample1()
        {
            // Arrange
            const int number = 112233;

            // Act
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber2(number, null, null);

            // Assert
            Assert.IsTrue(isValid, errorMsg);
            Assert.IsNull(errorMsg, errorMsg);
        }

        [TestMethod]
        public void PasswordEvaluator_ValidateNumber2_PartBExample2()
        {
            // Arrange
            const int number = 123444;

            // Act
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber2(number, null, null);

            // Assert
            Assert.IsFalse(isValid, number.ToString());
            Assert.AreEqual("Rule 5 is broken: the two adjacent matching digits are not part of a larger group of matching digits '123444'  | 4 => '44' | 4 => '444'",
                errorMsg, number.ToString());
        }

        [TestMethod]
        public void PasswordEvaluator_ValidateNumber2_PartBExample3()
        {
            // Arrange
            const int number = 111122;

            // Act
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber2(number, null, null);

            // Assert
            Assert.IsTrue(isValid, errorMsg);
            Assert.IsNull(errorMsg, errorMsg);
        }

        [TestMethod]
        public void PasswordEvaluator_ValidateNumber2_AllValid()
        {
            // Arrange
            int[] numbers = {111122, 778899, 111557, 447899 };

            // Act
            foreach (var number in numbers)
            {
                (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber2(number, null, null);
                // Assert
                Assert.IsTrue(isValid, errorMsg);
                Assert.IsNull(errorMsg, errorMsg);
            }

        }

        [TestMethod]
        public void PasswordEvaluator_ValidateNumber2_AllInvalid()
        {
            // Arrange
            int[] numbers = { 111222, 778889, 111555, 447888 };

            // Act
            foreach (var number in numbers)
            {
                (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber2(number, null, null);
                // Assert
                Assert.IsFalse(isValid, number.ToString());
            }
        }


        #endregion

        #region My input

        [TestMethod]
        public void PasswordEvaluator_CalculatePuzzleCombination_MyInput()
        {
            // Arrange
            const string puzzle = "372037-905157";

            // Act
            var actualPossibleCombinations = _passwordEvaluator.CalculatePuzzleCombination(puzzle);

            // Assert
            Assert.AreEqual(481, actualPossibleCombinations, puzzle);
        }

        #endregion
    }
}