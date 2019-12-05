using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyRnD.AdventCode2019.Parts.Tests
{
    [TestClass]
    public sealed class CrossedWiresResolverTests
    {
        const string Example1WirePath1 = "R8,U5,L5,D3";
        const string Example1WirePath2 = "U7,R6,D4,L4";

        const string Example2WirePath1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
        const string Example2WirePath2 = "U62,R66,U55,R34,D71,R55,D58,R83";


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

        private static void PrintGrid(char[,] grid)
        {
            int horizontalBound = grid.GetUpperBound(0);
            int verticalBound = grid.GetUpperBound(1);
            var sb = new StringBuilder();
            for (int w = horizontalBound; w >= 0; w--)
            {
                for (int h = 0; h <= verticalBound; h++)
                {
                    sb.Append(grid[w, h]);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
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
            Assert.AreEqual(5, actualFullBox.RightTop.X, actualFullBox.ToString());
            Assert.AreEqual(8, actualFullBox.RightTop.Y, actualFullBox.ToString());

            _crossedWiresResolver.DistanceCentralPortToClosestIntersection();

        }

        [TestMethod]
        public void CrossedWiresResolver_DistanceCentralPortToClosestIntersection_PartAExample1()
        {
            // Arrange
            var wirePaths = Example1WirePaths();
            _crossedWiresResolver = new CrossedWiresResolver(wirePaths);

            // Act
            (int shortest, char[,] grid) = _crossedWiresResolver.DistanceCentralPortToClosestIntersection();

            PrintGrid(grid);

            // Assert
            Assert.AreEqual(0, shortest);
        }

        [TestMethod]
        public void CrossedWiresResolver_DistanceCentralPortToClosestIntersection_PartAExample2()
        {
            // Arrange
            var wirePaths = Example2WirePaths();
            _crossedWiresResolver = new CrossedWiresResolver(wirePaths);

            // Act
            (int shortest, char[,] grid) = _crossedWiresResolver.DistanceCentralPortToClosestIntersection();

            PrintGrid(grid);

            // Assert
            Assert.AreEqual(0, shortest);
        }

        #endregion

        #region Helpers

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

        #endregion
    }
}