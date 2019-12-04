using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyRnD.AdventCode2019.D1.Rocket
{

    public sealed class Program
    {
        const string DefaultFilename = @"Rocket-day1.txt";

        static void Main(string[] args)
        {
            string fullFilename = Path.Combine(Environment.CurrentDirectory, DefaultFilename);
            Console.WriteLine($"Loading rocket data from '{fullFilename}'...");

            var rocketDay1 = Factory.GetRocketFromFile(fullFilename);
            int fuelNeeded = rocketDay1.FuelCounterUpper;
            int fuelNeeded2 = rocketDay1.FuelCounterUpper2;
            int extraFuel = fuelNeeded2 - fuelNeeded;
            Console.WriteLine($"The rocket has #{fullFilename} module(s) and the sum of the fuel requirements is '{fuelNeeded}'.");
            Console.WriteLine($"However, after taking into account the 'fuel needed for the fuel' the total sum of the fuel requirements is '{fuelNeeded2}' (an extra '{extraFuel}').");
        }
    }

    public sealed class Module
    {
        public int Mass { get; set; }

        /// <summary>
        /// Simple calculation just for the module's mass.
        /// </summary>
        public int FuelCounterUpper
        {
            get { return ((int) Math.Floor(Mass / 3.0) - 2); }
        }

        /// <summary>
        /// Calculates the fuel required by the module and for the fuel itself.
        /// </summary>
        public int FuelCounterUpper2
        {
            get
            {
                int totalFuelNeeded = 0;
                int mass = Mass;
                while (mass > 0)
                {
                    int fuelNeeded = ((int) Math.Floor(mass / 3.0) - 2);
                    if (fuelNeeded > 0)
                        totalFuelNeeded += fuelNeeded;
                    mass = fuelNeeded;
                }

                return totalFuelNeeded;
            }
        }

    }

    public sealed class Rocket
    {
        public Rocket()
            : this(new List<Module>())
        {
        }

        public Rocket(List<Module> modules)
        {
            Modules = modules;
        }

        public List<Module> Modules { get; set; }

        public int FuelCounterUpper
        {
            get
            {
                int total = 0;
                if (Modules != null && Modules.Any())
                {
                    foreach (var module in Modules)
                    {
                        total += module.FuelCounterUpper;
                    }
                }
                return total;
            }
        }

        public int FuelCounterUpper2
        {
            get
            {
                int total = 0;
                if (Modules != null && Modules.Any())
                {
                    foreach (var module in Modules)
                    {
                        total += module.FuelCounterUpper2;
                    }
                }
                return total;
            }
        }

    }

    public abstract class Factory
    {
        const int BufferSize = 1024;

        public static Rocket GetRocketFromFile(string fullFileName)
        {
            var tempRocket = new Rocket();
            using (var fileStream = File.OpenRead(fullFileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // line has only one value
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        int moduleMass = int.Parse(line);
                        var tempModule = new Module {Mass = moduleMass};
                        tempRocket.Modules.Add(tempModule);
                    }
                }
            }
            return tempRocket;
        }
    }
}
