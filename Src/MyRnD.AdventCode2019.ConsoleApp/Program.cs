using MyRnD.AdventCode2019.Parts;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyRnD.AdventCode2019.ConsoleApp
{

    public sealed partial class Program
    {
        static void Main(string[] args)
        {
#if false
            Separator(nameof(Program.Day01));
            Day01();

            Separator(nameof(Program.Day02_A));
            Day02_A();
            Separator(nameof(Program.Day02_B));
            Day02_B();
#endif
            Separator(nameof(Program.Day03_A));
            Day03_A();
        }

        static void Separator(string name)
        {
            Console.WriteLine();
            Console.WriteLine($"***************** {name.ToUpper()} ********************");
        }

        private static void Day03_A()
        {
            const string DefaultFilename = "CrossedWires-MyInput.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day03", DefaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading Crossed wires data from '{fullFilename}'...");
                Console.WriteLine();

                var factory = new Factory();
                CrossedWiresResolver crossedWiresResolver = factory.CreateCrossedWiresResolverFromFile(fullFilename);
                Console.WriteLine($"There are #{crossedWiresResolver.WirePaths.Count} crossed wires data loaded.");
                Console.WriteLine();

                Console.WriteLine($"The boxing rectangle for those crossed wires is defined as '{crossedWiresResolver.FullBox}'.");
                Console.WriteLine();

                (int closest, char[,] grid, List<Point> intersections, Point closestPoint) = crossedWiresResolver.DistanceCentralPortToClosestIntersection();
                Console.WriteLine($"The closest distance is '{closest}' for point {closestPoint} (there are #{intersections.Count} intersection points in total.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }

    }

}
