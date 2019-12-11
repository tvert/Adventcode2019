using MyRnD.AdventCode2019.Parts;
using System;
using System.IO;

namespace MyRnD.AdventCode2019.ConsoleApp
{
    public sealed partial class Program
    {
        private static void Day02_A()
        {
            const string defaultFilename = "IntCode-1202Program.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day02", defaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading IntCode data from '{fullFilename}'...");
                Console.WriteLine();

                var factory = new Factory();
                var intCodeComputer = factory.CreateIntCodeComputerFromFile(fullFilename);
                Console.WriteLine(
                    $"There are #{intCodeComputer.InitialIntCodes.Count} Op codes in this IntCode program.");
                Console.WriteLine();

                var finalOpCodes = intCodeComputer.Run();
                Console.WriteLine(
                    $"The value left at position 0 is '{finalOpCodes[0]}' after running the IntCode program.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }

        private static void Day02_B()
        {
            const string defaultFilename = @"IntCode-MyInput.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day02", defaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading IntCode data from '{fullFilename}'...");
                Console.WriteLine();

                var factory = new Factory();
                var intCodeComputer = factory.CreateIntCodeComputerFromFile(fullFilename);
                Console.WriteLine(
                    $"There are #{intCodeComputer.InitialIntCodes.Count} Op codes in this IntCode program.");
                Console.WriteLine();

                var finalOpCodes = intCodeComputer.Run();
                Console.WriteLine(
                    $"The value left at position 0 is '{finalOpCodes[0]}' after running the IntCode program.");
                Console.WriteLine();

                int expectedOutput = 19690720;
                (int noun, int verb) = intCodeComputer.FindNounAndVerbForOutput(expectedOutput);
                Console.WriteLine();
                Console.WriteLine(
                    $"The expected value '{expectedOutput}' can be compute with noun='{noun}' and verb='{verb}' ({noun:00}{verb:00}).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }
    }
}