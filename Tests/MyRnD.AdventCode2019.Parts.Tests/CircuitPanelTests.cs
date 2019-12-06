using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRnD.AdventCode2019.Parts.Math2D;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRnD.AdventCode2019.Parts.Tests
{
    [TestClass]
    public sealed class CircuitPanelTests
    {
        private CircuitPanel _circuitPanel;

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _circuitPanel = null;
        }
        
        #region Part A

        [TestMethod]
        public void CircuitPanel_FullBox_PartAExample1()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths1();

            // Act
            var actualFullBox = _circuitPanel.FullBox;

            // Assert
            Assert.AreEqual(0, actualFullBox.LeftBottom.X, actualFullBox.ToString());
            Assert.AreEqual(0, actualFullBox.LeftBottom.Y, actualFullBox.ToString());
            Assert.AreEqual(8, actualFullBox.RightTop.X, actualFullBox.ToString());
            Assert.AreEqual(7, actualFullBox.RightTop.Y, actualFullBox.ToString());
        }

        [TestMethod]
        public void CircuitPanel_FullBox_PartAExample2()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths2();

            // Act
            var actualFullBox = _circuitPanel.FullBox;

            // Assert
            Assert.AreEqual(0, actualFullBox.LeftBottom.X, actualFullBox.ToString());
            Assert.AreEqual(-30, actualFullBox.LeftBottom.Y, actualFullBox.ToString());
            Assert.AreEqual(238, actualFullBox.RightTop.X, actualFullBox.ToString());
            Assert.AreEqual(117, actualFullBox.RightTop.Y, actualFullBox.ToString());
        }

        [TestMethod]
        public void CircuitPanel_FullBox_PartAExample3()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths3();

            // Act
            var actualFullBox = _circuitPanel.FullBox;

            // Assert
            Assert.AreEqual(0, actualFullBox.LeftBottom.X, actualFullBox.ToString());
            Assert.AreEqual(-16, actualFullBox.LeftBottom.Y, actualFullBox.ToString());
            Assert.AreEqual(179, actualFullBox.RightTop.X, actualFullBox.ToString());
            Assert.AreEqual(104, actualFullBox.RightTop.Y, actualFullBox.ToString());
        }

        [TestMethod]
        public void CircuitPanel_ClosestDistance_PartAExample1()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths1();

            // Act
            int closestDistance = _circuitPanel.ClosestIntersectionDistance;
            Point closestPoint = _circuitPanel.ClosestIntersectionPoint;
            List<Point> intersections = _circuitPanel.Intersections;

            // Assert
            PrintGrid(_circuitPanel);
            Assert.AreEqual(2, intersections.Count);
            Assert.AreEqual(6, closestDistance, closestPoint.ToString());
            Assert.AreEqual(3, closestPoint.X, closestPoint.ToString());
            Assert.AreEqual(3, closestPoint.Y, closestPoint.ToString());
        }

        [TestMethod]
        public void CircuitPanel_ClosestDistance_PartAExample2()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths2();

            // Act
            int closestDistance = _circuitPanel.ClosestIntersectionDistance;
            Point closestPoint = _circuitPanel.ClosestIntersectionPoint;
            List<Point> intersections = _circuitPanel.Intersections;

            // Assert
            PrintGrid(_circuitPanel);
            Assert.AreEqual(4, intersections.Count);
            Assert.AreEqual(159, closestDistance, closestPoint.ToString());
            Assert.AreEqual(155, closestPoint.X, closestPoint.ToString());
            Assert.AreEqual(34, closestPoint.Y, closestPoint.ToString());
        }

        [TestMethod]
        public void CircuitPanel_ClosestDistance_PartAExample3()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths3();

            // Act
            int closestDistance = _circuitPanel.ClosestIntersectionDistance;
            Point closestPoint = _circuitPanel.ClosestIntersectionPoint;
            List<Point> intersections = _circuitPanel.Intersections;

            // Assert
            PrintGrid(_circuitPanel);
            Assert.AreEqual(5, intersections.Count);
            Assert.AreEqual(135, closestDistance, closestPoint.ToString());
            Assert.AreEqual(124, closestPoint.X, closestPoint.ToString());
            Assert.AreEqual(27, closestPoint.Y, closestPoint.ToString());
        }

        #endregion

        #region Part B

        [TestMethod]
        public void CircuitPanel_MinSignalDelaySteps_PartAExample1()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths1();

            // Act
            var actualMinimumSteps = _circuitPanel.MinSignalDelaySteps;

            // Assert
            Assert.AreEqual(30, actualMinimumSteps);
        }


        [TestMethod]
        public void CircuitPanel_WirePointIntersections_PartAExample1()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths1();

            // Act
            var actualWirePointIntersections = _circuitPanel.WirePointIntersections;
            var actualIntersections = _circuitPanel.Intersections;

            // Assert
            Assert.AreEqual(2, actualWirePointIntersections.Count);
            Assert.AreEqual(2, actualIntersections.Count);

            var actualWirePointIntersectionsAsString = $"actualWirePointIntersections: {string.Concat(actualWirePointIntersections)}";
            Console.WriteLine(actualWirePointIntersectionsAsString);
            Console.WriteLine($"actualIntersections: {string.Concat(actualIntersections)}");

            Assert.AreEqual("actualWirePointIntersections: [6, 5 | IsX: 'True' | #15 steps][3, 3 | IsX: 'True' | #20 steps]",
                actualWirePointIntersectionsAsString);
        }

        [TestMethod]
        public void CircuitPanel_MinSignalDelaySteps_PartAExample2()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths2();

            // Act
            var actualMinimumSteps = _circuitPanel.MinSignalDelaySteps;

            // Assert
            Assert.AreEqual(610, actualMinimumSteps);
        }

        [TestMethod]
        public void CircuitPanel_WirePointIntersections_PartAExample2()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths2();

            // Act
            var actualWirePointIntersections = _circuitPanel.WirePointIntersections;
            var actualIntersections = _circuitPanel.Intersections;

            // Assert
            Assert.AreEqual(4, actualWirePointIntersections.Count);
            Assert.AreEqual(4, actualIntersections.Count);
            var actualWirePointIntersectionsAsString = $"actualWirePointIntersections: {string.Concat(actualWirePointIntersections)}";
            Console.WriteLine(actualWirePointIntersectionsAsString);
            Console.WriteLine($"actualIntersections: {string.Concat(actualIntersections)}");

            Assert.AreEqual("actualWirePointIntersections: [158, -12 | IsX: 'True' | #206 steps][146, 46 | IsX: 'True' | #290 steps][155, 4 | IsX: 'True' | #341 steps][155, 11 | IsX: 'True' | #378 steps]",
                actualWirePointIntersectionsAsString);

            // We cannot compare both list because one is absolute X|Y (all positive) for the visual, the other is actual X|Y (negative values).
            //foreach (var wirePoint in actualWirePointIntersections)
            //{
            //    var commonPoints = actualIntersections.FindAll(p => p.X == wirePoint.X && p.Y == wirePoint.Y);
            //    Assert.AreEqual(1, commonPoints.Count, $"WirePoint: {wirePoint}.");
            //}
        }

        [TestMethod]
        public void CircuitPanel_MinSignalDelaySteps_PartAExample3()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths3();

            // Act
            var actualMinimumSteps = _circuitPanel.MinSignalDelaySteps;

            // Assert
            Assert.AreEqual(410, actualMinimumSteps);
        }

        [TestMethod]
        public void CircuitPanel_WirePointIntersections_PartAExample3()
        {
            // Arrange
            _circuitPanel = ExampleWirePaths3();

            // Act
            var actualWirePointIntersections = _circuitPanel.WirePointIntersections;
            var actualIntersections = _circuitPanel.Intersections;

            // Assert
            Assert.AreEqual(5, actualWirePointIntersections.Count);
            Assert.AreEqual(5, actualIntersections.Count);
            var actualWirePointIntersectionsAsString = $"actualWirePointIntersections: {string.Concat(actualWirePointIntersections)}";
            Console.WriteLine(actualWirePointIntersectionsAsString);
            Console.WriteLine($"actualIntersections: {string.Concat(actualIntersections)}");

            Assert.AreEqual("actualWirePointIntersections: [107, 47 | IsX: 'True' | #154 steps][124, 11 | IsX: 'True' | #207 steps][157, 18 | IsX: 'True' | #301 steps][107, 71 | IsX: 'True' | #232 steps][107, 51 | IsX: 'True' | #252 steps]",
                actualWirePointIntersectionsAsString);
        }

        #endregion

        #region Helpers

        private static void PrintGrid(CircuitPanel circuitPanel)
        {
            string gridText = circuitPanel.VerticalInvertedGridToString();
            Console.WriteLine(gridText);
        }

        private static CircuitPanel ExampleWirePaths1() 
        {
            const string example1WirePath1 = "R8,U5,L5,D3";
            const string example1WirePath2 = "U7,R6,D4,L4";

            List<WirePath> wirePaths = new List<WirePath>();
            {
                var wirePath1TextInLine = example1WirePath1.Split(',');
                var wirePath1 = new WirePath();
                wirePath1.AddRange(wirePath1TextInLine);
                wirePaths.Add(wirePath1);

                var wirePath2TextInLine = example1WirePath2.Split(',');
                var wirePath2 = new WirePath();
                wirePath2.AddRange(wirePath2TextInLine);
                wirePaths.Add(wirePath2);
            }
            var tempCircuitPanel = new CircuitPanel(wirePaths, new CrossedWiresResolver());
            return tempCircuitPanel;
        }


        private static CircuitPanel ExampleWirePaths2()
        {
            const string example2WirePath1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
            const string example2WirePath2 = "U62,R66,U55,R34,D71,R55,D58,R83";

            List<WirePath> wirePaths = new List<WirePath>();
            {
                var wirePath1TextInLine = example2WirePath1.Split(',');
                var wirePath1 = new WirePath();
                wirePath1.AddRange(wirePath1TextInLine);
                wirePaths.Add(wirePath1);

                var wirePath2TextInLine = example2WirePath2.Split(',');
                var wirePath2 = new WirePath();
                wirePath2.AddRange(wirePath2TextInLine);
                wirePaths.Add(wirePath2);
            }
            var tempCircuitPanel = new CircuitPanel(wirePaths, new CrossedWiresResolver());
            return tempCircuitPanel;
        }

        private static CircuitPanel ExampleWirePaths3()
        {
            const string example3WirePath1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51";
            const string example3WirePath2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";

            List<WirePath> wirePaths = new List<WirePath>();
            {
                var wirePath1TextInLine = example3WirePath1.Split(',');
                var wirePath1 = new WirePath();
                wirePath1.AddRange(wirePath1TextInLine);
                wirePaths.Add(wirePath1);

                var wirePath2TextInLine = example3WirePath2.Split(',');
                var wirePath2 = new WirePath();
                wirePath2.AddRange(wirePath2TextInLine);
                wirePaths.Add(wirePath2);
            }
            var tempCircuitPanel = new CircuitPanel(wirePaths, new CrossedWiresResolver());
            return tempCircuitPanel;
        }

        #endregion
    }
}