using MyRnD.AdventCode2019.Parts;
using System;
using System.IO;

namespace MyRnD.AdventCode2019.ConsoleApp
{
    public sealed partial class Program
    {
        private static void Day01()
        {
            const string day01DefaultFilename = @"Rocket-day1.txt";

            string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day01", day01DefaultFilename);
            Console.WriteLine($"Loading rocket data from '{fullFilename}'...");

            var factory = new Factory();
            var rocketDay1 = factory.CreateRocketFromFile(fullFilename);
            int fuelNeeded = rocketDay1.FuelCounterUpper;
            int fuelNeeded2 = rocketDay1.FuelCounterUpper2;
            int extraFuel = fuelNeeded2 - fuelNeeded;
            Console.WriteLine(
                $"The rocket has #{fullFilename} module(s) and the sum of the fuel requirements is '{fuelNeeded}'.");
            Console.WriteLine(
                $"However, after taking into account the 'fuel needed for the fuel' the total sum of the fuel requirements is '{fuelNeeded2}' (an extra '{extraFuel}').");
        }
    }
}