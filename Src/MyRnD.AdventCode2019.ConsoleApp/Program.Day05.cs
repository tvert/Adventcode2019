using System;
using System.IO;
using System.Linq;
using MyRnD.AdventCode2019.Parts;

namespace MyRnD.AdventCode2019.ConsoleApp
{
    public sealed partial class Program
    {
        private static void Day05_A()
        {
            const string defaultFilename = @"TEST_diagnostic.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day05", defaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading IntCode data from '{fullFilename}'...");
                Console.WriteLine();

                var factory = new Factory();
                IInputter inputter = factory.CreateAutoInputter(1);
                IOutputter outputter = factory.CreateConsoleOutputter();
                var intCodeComputer = factory.CreateIntCodeComputerFromFile(fullFilename, inputter, outputter);
                Console.WriteLine(
                    $"There are #{intCodeComputer.InitialIntCodes.Count} Op codes in this IntCode program.");
                Console.WriteLine();

                var finalOpCodes = intCodeComputer.Run();
                Console.WriteLine(
                    $"The value left at position 0 is '{finalOpCodes[0]}' after running the IntCode program.");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(
                    $"The last value outputted during the diagnosis of TEST is '{intCodeComputer.Outputter.OutputValues.Last()}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }

        private static void Day05_B()
        {
            const string defaultFilename = @"TEST_diagnostic.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day05", defaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading IntCode data from '{fullFilename}'...");
                Console.WriteLine();

                var factory = new Factory();
                IInputter inputter = factory.CreateAutoInputter(1);
                IOutputter outputter = factory.CreateConsoleOutputter();
                var intCodeComputer = factory.CreateIntCodeComputerFromFile(fullFilename, inputter, outputter);
                Console.WriteLine(
                    $"There are #{intCodeComputer.InitialIntCodes.Count} Op codes in this IntCode program.");
                Console.WriteLine();

                var finalOpCodes = intCodeComputer.Run();
                Console.WriteLine(
                    $"The value left at position 0 is '{finalOpCodes[0]}' after running the IntCode program.");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(
                    $"The last value outputted during the diagnosis of TEST is '{intCodeComputer.Outputter.OutputValues.Last()}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }
    }
}