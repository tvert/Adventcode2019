using MyRnD.AdventCode2019.Parts;
using MyRnD.AdventCode2019.Parts.Math2D;
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
                CircuitPanel circuitPanel = factory.CreateCircuitPanelFromFile(fullFilename);
                Console.WriteLine($"There are #{circuitPanel.WirePaths.Count} crossed wires loaded on the circuit panel.");
                Console.WriteLine();

                Console.WriteLine(
                    $"The boxing rectangle for those crossed wires is defined within '{circuitPanel.FullBox}'.");
                Console.WriteLine();

                int closestDistance = circuitPanel.ClosestIntersectionDistance;
                Point closestPoint = circuitPanel.ClosestIntersectionPoint;
                List<Point> intersections = circuitPanel.Intersections;
                Console.WriteLine(
                    $"The closest distance from central port to the intersection point {closestPoint} is '{closestDistance}' (there are #{intersections.Count} intersection points in total.");
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
                CircuitPanel circuitPanel = factory.CreateCircuitPanelFromFile(fullFilename);
                Console.WriteLine($"There are #{circuitPanel.WirePaths.Count} crossed wires loaded on the circuit panel.");
                Console.WriteLine();

                Console.WriteLine(
                    $"The boxing rectangle for those crossed wires is defined within '{circuitPanel.FullBox}'.");
                Console.WriteLine();

                var minimumSteps = circuitPanel.MinSignalDelaySteps;
                var wpMinDelayPoint = circuitPanel.MinSignalDelayPoint;

                Console.WriteLine(
                    $"The shortest distance for all signal to cross is at point {wpMinDelayPoint} with '{minimumSteps}' steps.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }

    }
}