using MyRnD.AdventCode2019.Parts;
using System;
using System.IO;

namespace MyRnD.AdventCode2019.ConsoleApp
{
    public sealed partial class Program
    {
        private static void Day06_A()
        {
            const string defaultFilename = "UniversalOrbitMap.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day06", defaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading universal orbit map from '{fullFilename}'...");
                Console.WriteLine();

                var factory = new Factory();
                UniversalOrbitMap orbitMap = factory.CreateUniversalOrbitMapFromFile(fullFilename);
                Console.WriteLine($"There are #{orbitMap.Objects.Count} space objects defined on the map.");
                Console.WriteLine();

                int numberOfOrbits = orbitMap.NumberOfOrbits;
                Console.WriteLine($"There #{numberOfOrbits} direct or indirect defined orbits.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }

        private static void Day06_B()
        {
            const string defaultFilename = "UniversalOrbitMap.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day06", defaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading universal orbit map from '{fullFilename}'...");
                Console.WriteLine();

                var factory = new Factory();
                UniversalOrbitMap orbitMap = factory.CreateUniversalOrbitMapFromFile(fullFilename);
                Console.WriteLine($"There are #{orbitMap.Objects.Count} space objects defined on the map.");
                Console.WriteLine();

                int numberOfOrbits = orbitMap.NumberOfOrbits;
                Console.WriteLine($"There #{numberOfOrbits} direct or indirect defined orbits.");
                Console.WriteLine();

                string spaceObject1 = "YOU";
                string spaceObject2 = "SAN";
                (bool hasB, int minimumOrbitalTransfer) = orbitMap.MinimumOrbitalTransfer(spaceObject1, spaceObject2);
                Console.WriteLine($"The minimum orbital transfer(s) to go from '{spaceObject1}' to '{spaceObject2}' is(are) #{minimumOrbitalTransfer} [found: '{hasB}'].");
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }
    }
}