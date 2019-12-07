using System;

namespace MyRnD.AdventCode2019.Parts
{
    /// <summary>
    ///
    /// You arrive at the Venus fuel depot only to discover it's protected by a password. The Elves had written the password on a sticky note, but someone threw it out.
    /// 
    /// However, they do remember a few key facts about the password:
    /// 
    /// 1) It is a six-digit number.
    /// 2) The value is within the range given in your puzzle input.
    /// 3) Two adjacent digits are the same (like 22 in 122345).
    /// 4) Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679).
    /// 
    /// Other than the range rule, the following are true:
    /// 
    /// - 111111 meets these criteria (double 11, never decreases).
    /// - 223450 does not meet these criteria (decreasing pair of digits 50).
    /// - 123789 does not meet these criteria (no double).
    /// 
    /// How many different passwords within the range given in your puzzle input meet these criteria?
    /// 
    /// </summary>
    public sealed class PasswordEvaluator
    {
        public const char RangeSeparatorChar = '-';

        public int CalculatePuzzleCombination(string rangeAsString)
        {
            int totalCombinations = 0;
            int totalWrong = 0;

            string[] ranges = rangeAsString.Split(RangeSeparatorChar);

            int lowerRange = int.Parse(ranges[0]);
            int higherRange = int.Parse(ranges[1]);

            // Bypassing Rule 2 with the for loop.
            for (int i = lowerRange; i <= higherRange; i++)
            {
                (bool isValid, string errorMsg) = ValidateNumber2(i, null, null);
                if (isValid)
                    totalCombinations++;
                else
                    totalWrong++;
            }

            int rangeTotal = higherRange - lowerRange + 1;
            if (rangeTotal != totalCombinations + totalWrong)
                throw new InvalidOperationException($"Missing validations [Lower: {lowerRange}, Higher: {higherRange}] => {rangeTotal} | " +
                                                    $"[Valid: {totalCombinations}, Wrong: {totalWrong}] => {totalCombinations + totalWrong}.");

            return totalCombinations;
        }

        public (bool isValid, string errorMsg) ValidateNumber(int number, int? lowerLimit, int? higherLimit)
        {
            // Validate the rules
            // Rule 1: It is a six-digit number.
            if (number < 100000 || number > 999999)
                return (false, $"Rule 1 is broken: It is a six-digit number '{number}'.");

            // Rule 2: The value is within the range given in your puzzle input.
            if (lowerLimit.HasValue && higherLimit.HasValue &&
                number > lowerLimit && number < higherLimit)
                return (false,
                    $"Rule 2 is broken: The value is within the range given in your puzzle input '{number}' [{lowerLimit}, {higherLimit}].");

            // Rule 3: Two adjacent digits are the same (like 22 in 122345).
            string[] twoAdjacent = new[] {"00", "11", "22", "33", "44", "55", "66", "77", "88", "99"};
            string numberAsString = number.ToString();
            bool rule3Success = false;
            foreach (var twoDigits in twoAdjacent)
            {
                rule3Success = numberAsString.IndexOf(twoDigits) >= 0;
                if (rule3Success)
                    break;
            }

            if (!rule3Success)
                return (false, $"Rule 3 is broken: Two adjacent digits are the same (like 22 in 122345) '{number}'.");

            // Rule 4: Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679).
            char previousChar = '0';
            for (int i = 0; i < numberAsString.Length; i++)
            {
                char currentChar = numberAsString[i];
                if (currentChar < previousChar)
                    return (false, $"Rule 4 is broken: " +
                                   $"Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679) " +
                                   $"'{previousChar}{currentChar}' (at position {i + 1}).");
                previousChar = currentChar;
            }

            return (true, null);
        }

        /// <summary>
        /// --- Part Two ---
        /// An Elf just remembered one more important detail: (Rule 5) the two adjacent matching digits are not part of a larger group of matching digits.
        /// 
        /// Given this additional criterion, but still ignoring the range rule, the following are now true:
        /// 
        /// - 112233 meets these criteria because the digits never decrease and all repeated digits are exactly two digits long.
        /// - 123444 no longer meets the criteria (the repeated 44 is part of a larger group of 444).
        /// - 111122 meets the criteria (even though 1 is repeated more than twice, it still contains a double 22).
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="lowerLimit"></param>
        /// <param name="higherLimit"></param>
        /// <returns></returns>

        public (bool isValid, string errorMsg) ValidateNumber2(int number, int? lowerLimit, int? higherLimit)
        {
            // Validate the rules
            // Rule 1: It is a six-digit number.
            if (number < 100000 || number > 999999)
                return (false, $"Rule 1 is broken: It is a six-digit number '{number}'.");

            // Rule 2: The value is within the range given in your puzzle input.
            if (lowerLimit.HasValue && higherLimit.HasValue &&
                number > lowerLimit && number < higherLimit)
                return (false,
                    $"Rule 2 is broken: The value is within the range given in your puzzle input '{number}' [{lowerLimit}, {higherLimit}].");

            // Rule 3: Two adjacent digits are the same (like 22 in 122345).
            string[] twoAdjacent = new[] { "00", "11", "22", "33", "44", "55", "66", "77", "88", "99" };
            string numberAsString = number.ToString();
            {
                bool ruleSuccess3 = false;
                foreach (var twoDigits in twoAdjacent)
                {
                    ruleSuccess3 = numberAsString.IndexOf(twoDigits, StringComparison.Ordinal) >= 0;
                    if (ruleSuccess3)
                        break;
                }

                if (!ruleSuccess3)
                    return (false,
                        $"Rule 3 is broken: Two adjacent digits are the same (like 22 in 122345) '{number}'.");
            }

            // Rule 4: Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679).
            char previousChar = '0';
            for (int i = 0; i < numberAsString.Length; i++)
            {
                char currentChar = numberAsString[i];
                if (currentChar < previousChar)
                    return (false, $"Rule 4 is broken: " +
                                   $"Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679) " +
                                   $"'{previousChar}{currentChar}' (at position {i + 1}).");
                previousChar = currentChar;
            }

            // Rule 5: the two adjacent matching digits are not part of a larger group of matching digits
            int hightest2Adjacent = -1;
            bool has2Adjacent = false;
            for(int i = 0; i < twoAdjacent.Length; i++)
            {
                var twoDigits = twoAdjacent[i];
                has2Adjacent = numberAsString.IndexOf(twoDigits, StringComparison.Ordinal) >= 0;
                hightest2Adjacent = has2Adjacent ? i : hightest2Adjacent;
            }

            string[] threeAdjacent = new[] { "000", "111", "222", "333", "444", "555", "666", "777", "888", "999" };
            int hightest3Adjacent = -1;

            bool has3Adjacent = false;
            for (int i = 0; i < twoAdjacent.Length; i++)
            {
                var twoDigits = threeAdjacent[i];
                has3Adjacent = numberAsString.IndexOf(twoDigits, StringComparison.Ordinal) >= 0;
                hightest3Adjacent = has3Adjacent ? i : hightest3Adjacent;
            }

            bool ruleSuccess5 = (hightest3Adjacent < 0 || hightest3Adjacent < hightest2Adjacent);
            if (!ruleSuccess5)
                return (false,
                    $"Rule 5 is broken: the two adjacent matching digits are not part of a larger group of matching digits '{number}' " +
                    $" | {hightest2Adjacent} => '{twoAdjacent[hightest2Adjacent]}'" +
                    $" | {hightest3Adjacent} => '{(hightest3Adjacent >=0 ? threeAdjacent[hightest3Adjacent] : String.Empty)}'");

            return (true, null);
        }

    }
}
