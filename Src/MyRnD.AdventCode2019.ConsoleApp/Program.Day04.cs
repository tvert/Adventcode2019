using MyRnD.AdventCode2019.Parts;
using System;

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
                int h = passwordEvaluator.CalculatePuzzleCombination(myInput);

                Console.WriteLine($"There are #{h} different passwords possible for {myInput}.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }
    }
}