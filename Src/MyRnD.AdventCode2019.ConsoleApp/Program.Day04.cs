using MyRnD.AdventCode2019.Parts;
using System;
using System.Collections.Generic;

namespace MyRnD.AdventCode2019.ConsoleApp
{
    public sealed partial class Program
    {
        private static void Day04_A()
        {
            const string myInput = @"372037-905157";
            try
            {
                Console.WriteLine();
                Console.WriteLine($"Checking combination for password '{myInput}'...");
                Console.WriteLine();

                var factory = new Factory();
                PasswordEvaluator passwordEvaluator = factory.CreatePasswordEvaluator();
                (int totalCombinations, List<int> validNumbers) = passwordEvaluator.CalculatePuzzleCombination1(myInput);

                Console.WriteLine($"There are #{totalCombinations} different passwords possible for {myInput}.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }
    }
}