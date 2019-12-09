using System;
using System.Collections.Generic;
using System.Text;
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
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber1To4(number, LowerLimit, HigherLimit);

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
            (bool isValid, string errorMsg)  = _passwordEvaluator.ValidateNumber1To4(number, LowerLimit, HigherLimit);

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
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber1To4(number, LowerLimit, HigherLimit);

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
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber1To5(number, null, null);

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
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber1To5(number, null, null);

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
            (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber1To5(number, null, null);

            // Assert
            Assert.IsTrue(isValid, errorMsg);
            Assert.IsNull(errorMsg, errorMsg);
        }

        [TestMethod]
        public void PasswordEvaluator_ValidateNumber2_AllValid()
        {
            // Arrange
            int[] numbers = { 377788, 377799, 111122, 778899, 111557, 447899 };

            // Act
            foreach (var number in numbers)
            {
                (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber1To5(number, null, null);
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
                (bool isValid, string errorMsg) = _passwordEvaluator.ValidateNumber1To5(number, null, null);
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
            const string rangeAsString = "372037-905157";

            // Act
            (int actualPossibleCombinations, _) = _passwordEvaluator.CalculatePuzzleCombination1(rangeAsString);

            // Assert
            Assert.AreEqual(481, actualPossibleCombinations, rangeAsString);
        }

        [TestMethod]
        public void PasswordEvaluator_CalculatePuzzleCombination2_MyInput()
        {
            // Arrange
            const string rangeAsString = "372037-905157";

            // Act
            (int actualPossibleCombinations1, List<int> validNumbers1) = _passwordEvaluator.CalculatePuzzleCombination1(rangeAsString);
            (int actualPossibleCombinations2, List<int> validNumbers2) = _passwordEvaluator.CalculatePuzzleCombination2(rangeAsString);

            var sb2 = new StringBuilder("Valid Numbers after rule 1 to 5:").AppendLine();
            foreach (var number2 in validNumbers2)
            {
                sb2.AppendLine($"- {number2}");
            }

            var sb1 = new StringBuilder("Valid Numbers after rule 1 to 4:").AppendLine();
            var sb5 = new StringBuilder("Valid Numbers removed by 5:").AppendLine();
            List<int> numbersFailingRule5 = new List<int>();
            foreach (var number1 in validNumbers1)
            {
                if (!validNumbers2.Contains(number1))
                {
                    numbersFailingRule5.Add(number1);
                    sb1.AppendLine($"- {number1} *** Removed by rule 5");
                    sb5.AppendLine($"- {number1}");
                }
                else
                {
                    sb1.AppendLine($"- {number1}");
                }
            }

            Console.WriteLine(sb1.ToString());
            Console.WriteLine(sb2.ToString());
            Console.WriteLine(sb5.ToString());

            // Assert
            Assert.AreEqual(481, actualPossibleCombinations1, rangeAsString);
            Assert.AreEqual(481, validNumbers1.Count);
            Assert.AreEqual(481, validNumbers2.Count + numbersFailingRule5.Count);

            Assert.AreEqual(299, actualPossibleCombinations2);
            Assert.AreEqual(299, validNumbers2.Count);

        }


        #endregion
    }
}