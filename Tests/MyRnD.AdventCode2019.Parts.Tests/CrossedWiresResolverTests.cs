using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MyRnD.AdventCode2019.Parts.Tests
{
    [TestClass]
    public sealed class CrossedWiresResolverTests
    {
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
            _crossedWiresResolver = Example1WirePaths();

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
            _crossedWiresResolver = Example2WirePaths();

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
            _crossedWiresResolver = Example3WirePaths();

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
            _crossedWiresResolver = Example1WirePaths();

            // Act
            int closestDistance = _crossedWiresResolver.ClosestIntersectionDistance;
            Point closestPoint = _crossedWiresResolver.ClosestIntersectionPoint;
            List<Point> intersections = _crossedWiresResolver.Intersections;

            // Assert
            PrintGrid(_crossedWiresResolver);
            Assert.AreEqual(2, intersections.Count);
            Assert.AreEqual(6, closestDistance, closestPoint.ToString());
            Assert.AreEqual(3, closestPoint.X, closestPoint.ToString());
            Assert.AreEqual(3, closestPoint.Y, closestPoint.ToString());
        }

        [TestMethod]
        public void CrossedWiresResolver_ClosestDistance_PartAExample2()
        {
            // Arrange
            _crossedWiresResolver = Example2WirePaths();

            // Act
            int closestDistance = _crossedWiresResolver.ClosestIntersectionDistance;
            Point closestPoint = _crossedWiresResolver.ClosestIntersectionPoint;
            List<Point> intersections = _crossedWiresResolver.Intersections;

            // Assert
            PrintGrid(_crossedWiresResolver);
            Assert.AreEqual(4, intersections.Count);
            Assert.AreEqual(159, closestDistance, closestPoint.ToString());
            Assert.AreEqual(34, closestPoint.X, closestPoint.ToString());
            Assert.AreEqual(155, closestPoint.Y, closestPoint.ToString());
        }

        [TestMethod]
        public void CrossedWiresResolver_ClosestDistance_PartAExample3()
        {
            // Arrange
            _crossedWiresResolver = Example3WirePaths();

            // Act
            int closestDistance = _crossedWiresResolver.ClosestIntersectionDistance;
            Point closestPoint = _crossedWiresResolver.ClosestIntersectionPoint;
            List<Point> intersections = _crossedWiresResolver.Intersections;

            // Assert
            PrintGrid(_crossedWiresResolver);
            Assert.AreEqual(5, intersections.Count);
            Assert.AreEqual(135, closestDistance, closestPoint.ToString());
            Assert.AreEqual(27, closestPoint.X, closestPoint.ToString());
            Assert.AreEqual(124, closestPoint.Y, closestPoint.ToString());
        }

        #endregion

        #region Helpers

        private static void PrintGrid(CrossedWiresResolver crossedWiresResolver)
        {
            string gridText = crossedWiresResolver.VisualGridToString();
            Console.WriteLine(gridText);
        }

        private static CrossedWiresResolver Example1WirePaths() 
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
            var tempCrossedWiresResolver = new CrossedWiresResolver(wirePaths);
            return tempCrossedWiresResolver;
        }


        private static CrossedWiresResolver Example2WirePaths()
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
            var tempCrossedWiresResolver = new CrossedWiresResolver(wirePaths);
            return tempCrossedWiresResolver;
        }

        private static CrossedWiresResolver Example3WirePaths()
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
            var tempCrossedWiresResolver = new CrossedWiresResolver(wirePaths);
            return tempCrossedWiresResolver;
        }

        #endregion
    }
}