using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MyRnD.AdventCode2019.Parts.Tests
{
    [TestClass]
    public sealed class CrossedWiresResolverTests
    {
        const string Example1WirePath1 = "R8,U5,L5,D3";
        const string Example1WirePath2 = "U7,R6,D4,L4";

        const string Example2WirePath1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
        const string Example2WirePath2 = "U62,R66,U55,R34,D71,R55,D58,R83";

        const string Example3WirePath1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51";
        const string Example3WirePath2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";
        private CrossedWiresResolver _crossedWiresResolver;

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _crossedWiresResolver = null;
        }
        
        #region Part A

        [TestMethod]
        public void CrossedWiresResolver_FullBox_PartAExample1()
        {
            // Arrange
            var wirePaths = Example1WirePaths();
            _crossedWiresResolver = new CrossedWiresResolver(wirePaths);

            // Act
            var actualFullBox = _crossedWiresResolver.FullBox;

            // Assert
            Assert.AreEqual(0, actualFullBox.LeftBottom.X, actualFullBox.ToString());
            Assert.AreEqual(0, actualFullBox.LeftBottom.Y, actualFullBox.ToString());
            Assert.AreEqual(7, actualFullBox.RightTop.X, actualFullBox.ToString());
            Assert.AreEqual(8, actualFullBox.RightTop.Y, actualFullBox.ToString());
        }

        [TestMethod]
        public void CrossedWiresResolver_FullBox_PartAExample2()
        {
            // Arrange
            var wirePaths = Example2WirePaths();
            _crossedWiresResolver = new CrossedWiresResolver(wirePaths);

            // Act
            var actualFullBox = _crossedWiresResolver.FullBox;

            // Assert
            Assert.AreEqual(-30, actualFullBox.LeftBottom.X, actualFullBox.ToString());
            Assert.AreEqual(0, actualFullBox.LeftBottom.Y, actualFullBox.ToString());
            Assert.AreEqual(117, actualFullBox.RightTop.X, actualFullBox.ToString());
            Assert.AreEqual(238, actualFullBox.RightTop.Y, actualFullBox.ToString());
        }

        [TestMethod]
        public void CrossedWiresResolver_FullBox_PartAExample3()
        {
            // Arrange
            var wirePaths = Example3WirePaths();
            _crossedWiresResolver = new CrossedWiresResolver(wirePaths);

            // Act
            var actualFullBox = _crossedWiresResolver.FullBox;

            // Assert
            Assert.AreEqual(-16, actualFullBox.LeftBottom.X, actualFullBox.ToString());
            Assert.AreEqual(0, actualFullBox.LeftBottom.Y, actualFullBox.ToString());
            Assert.AreEqual(104, actualFullBox.RightTop.X, actualFullBox.ToString());
            Assert.AreEqual(179, actualFullBox.RightTop.Y, actualFullBox.ToString());
        }

        [TestMethod]
        public void CrossedWiresResolver_ClosestDistance_PartAExample1()
        {
            // Arrange
            var wirePaths = Example1WirePaths();
            _crossedWiresResolver = new CrossedWiresResolver(wirePaths);

            // Act
            (int shortest, char[,] grid, List<Point> intersections, Point closestPoint) = _crossedWiresResolver.DistanceCentralPortToClosestIntersection();

            // Assert
            PrintGrid(_crossedWiresResolver, grid);
            Assert.AreEqual(2, intersections.Count);
            Assert.AreEqual(6, shortest, closestPoint.ToString());
            Assert.AreEqual(3, closestPoint.X, closestPoint.ToString());
            Assert.AreEqual(3, closestPoint.Y, closestPoint.ToString());
        }

        [TestMethod]
        public void CrossedWiresResolver_ClosestDistance_PartAExample2()
        {
            // Arrange
            var wirePaths = Example2WirePaths();
            _crossedWiresResolver = new CrossedWiresResolver(wirePaths);

            // Act
            (int shortest, char[,] grid, List<Point> intersections, Point closestPoint) = _crossedWiresResolver.DistanceCentralPortToClosestIntersection();

            // Assert
            PrintGrid(_crossedWiresResolver, grid);
            Assert.AreEqual(4, intersections.Count);
            Assert.AreEqual(159, shortest, closestPoint.ToString());
            Assert.AreEqual(34, closestPoint.X, closestPoint.ToString());
            Assert.AreEqual(155, closestPoint.Y, closestPoint.ToString());
        }

        [TestMethod]
        public void CrossedWiresResolver_ClosestDistance_PartAExample3()
        {
            // Arrange
            var wirePaths = Example3WirePaths();
            _crossedWiresResolver = new CrossedWiresResolver(wirePaths);

            // Act
            (int shortest, char[,] grid, List<Point> intersections, Point closestPoint) = _crossedWiresResolver.DistanceCentralPortToClosestIntersection();

            // Assert
            PrintGrid(_crossedWiresResolver, grid);
            Assert.AreEqual(5, intersections.Count);
            Assert.AreEqual(135, shortest, closestPoint.ToString());
            Assert.AreEqual(27, closestPoint.X, closestPoint.ToString());
            Assert.AreEqual(124, closestPoint.Y, closestPoint.ToString());
        }

        #endregion

        #region Helpers

        private static void PrintGrid(CrossedWiresResolver crossedWiresResolver, char[,] grid)
        {
            string gridText = crossedWiresResolver.GridToString(grid);
            Console.WriteLine(gridText);
        }

        private static List<WirePath> Example1WirePaths() 
        {
            List<WirePath> wirePaths = new List<WirePath>();
            {
                var wirePath1TextInLine = Example1WirePath1.Split(',');
                var wirePath1 = new WirePath();
                wirePath1.AddRange(wirePath1TextInLine);
                wirePaths.Add(wirePath1);

                var wirePath2TextInLine = Example1WirePath2.Split(',');
                var wirePath2 = new WirePath();
                wirePath2.AddRange(wirePath2TextInLine);
                wirePaths.Add(wirePath2);
            }
            return wirePaths;
        }


        private static List<WirePath> Example2WirePaths()
        {
            List<WirePath> wirePaths = new List<WirePath>();
            {
                var wirePath1TextInLine = Example2WirePath1.Split(',');
                var wirePath1 = new WirePath();
                wirePath1.AddRange(wirePath1TextInLine);
                wirePaths.Add(wirePath1);

                var wirePath2TextInLine = Example2WirePath2.Split(',');
                var wirePath2 = new WirePath();
                wirePath2.AddRange(wirePath2TextInLine);
                wirePaths.Add(wirePath2);
            }
            return wirePaths;
        }

        private static List<WirePath> Example3WirePaths()
        {
            List<WirePath> wirePaths = new List<WirePath>();
            {
                var wirePath1TextInLine = Example3WirePath1.Split(',');
                var wirePath1 = new WirePath();
                wirePath1.AddRange(wirePath1TextInLine);
                wirePaths.Add(wirePath1);

                var wirePath2TextInLine = Example3WirePath2.Split(',');
                var wirePath2 = new WirePath();
                wirePath2.AddRange(wirePath2TextInLine);
                wirePaths.Add(wirePath2);
            }
            return wirePaths;
        }

        #endregion
    }
}