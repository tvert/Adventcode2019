using MyRnD.AdventCode2019.Parts;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyRnD.AdventCode2019.ConsoleApp
{
    public sealed partial class Program
    {
        private static void Day03_A()
        {
            const string defaultFilename = "CrossedWires-MyInput.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day03", defaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading Crossed wires data from '{fullFilename}'...");
                Console.WriteLine();

                var factory = new Factory();
                CrossedWiresResolver crossedWiresResolver = factory.CreateCrossedWiresResolverFromFile(fullFilename);
                Console.WriteLine($"There are #{crossedWiresResolver.WirePaths.Count} crossed wires data loaded.");
                Console.WriteLine();

                Console.WriteLine(
                    $"The boxing rectangle for those crossed wires is defined as '{crossedWiresResolver.FullBox}'.");
                Console.WriteLine();

                int closestDistance = crossedWiresResolver.ClosestIntersectionDistance;
                Point closestPoint = crossedWiresResolver.ClosestIntersectionPoint;
                List<Point> intersections = crossedWiresResolver.Intersections;
                Console.WriteLine(
                    $"The closest distance is '{closestDistance}' for point {closestPoint} (there are #{intersections.Count} intersection points in total.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }
        private static void Day03_B()
        {
            const string defaultFilename = "CrossedWires-MyInput.txt";
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, "Day03", defaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading Crossed wires data from '{fullFilename}'...");
                Console.WriteLine();

                var factory = new Factory();
                CrossedWiresResolver crossedWiresResolver = factory.CreateCrossedWiresResolverFromFile(fullFilename);
                Console.WriteLine($"There are #{crossedWiresResolver.WirePaths.Count} crossed wires data loaded.");
                Console.WriteLine();

                Console.WriteLine($"The boxing rectangle for those crossed wires is defined as '{crossedWiresResolver.FullBox}'.");
                Console.WriteLine();

                int closestDistance = crossedWiresResolver.ClosestIntersectionDistance;
                Point closestPoint = crossedWiresResolver.ClosestIntersectionPoint;
                List<Point> intersections = crossedWiresResolver.Intersections;
                Console.WriteLine(
                    $"The closest distance is '{closestDistance}' for point {closestPoint} (there are #{intersections.Count} intersection points in total.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }

    }
}