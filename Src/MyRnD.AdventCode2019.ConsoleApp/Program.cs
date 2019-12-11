using System;
using System.Collections.Generic;
using System.IO;
using MyRnD.AdventCode2019.Parts;

namespace MyRnD.AdventCode2019.ConsoleApp
{

    public sealed partial class Program
    {
        static void Main(string[] args)
        {
#if false
            Console.WriteLine("PRESS ENTER TO START ...");
            Console.ReadLine();
            Separator(nameof(Program.Day01));
            Day01();

            Separator(nameof(Program.Day02_A));
            Day02_A();
            Separator(nameof(Program.Day02_B));
            Day02_B();

            Separator(nameof(Program.Day03_A));
            Day03_A();
            Separator(nameof(Program.Day03_B));
            Day03_B();

            Separator(nameof(Program.Day04_A));
            Day04_A();

            Separator(nameof(Program.Day06_A));
            Day06_A();
            Separator(nameof(Program.Day06_B));
            Day06_B();
#endif

            Separator(nameof(Program.Day05_A));
            Day05_A();

            Console.WriteLine("PRESS ENTER TO STOP.");
            Console.ReadLine();
        }

        static void Separator(string name)
        {
            Console.WriteLine();
            Console.WriteLine($"***************** {name.ToUpper()} ********************");
        }

        private static void Day05_A()
        {
            const string defaultFilename = @"IntCode-MyInput.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day05", defaultFilename);
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
