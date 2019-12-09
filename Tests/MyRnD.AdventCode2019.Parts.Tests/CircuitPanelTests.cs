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

        [TestMethod]
        public void CircuitPanel_MinSignalDelaySteps_MyInputWirePaths()
        {
            // Arrange
            _circuitPanel = MyInputWirePaths();

            // Act
            var actualMinimumSteps = _circuitPanel.MinSignalDelaySteps;

            // Assert
            Assert.AreEqual(10554, actualMinimumSteps);
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

        private static CircuitPanel MyInputWirePaths()
        {
            const string path1 = "R990,D362,L316,U101,R352,U798,L314,D564,R961,D634,L203,U601,R973,U227,R996,D639,L868,D135,L977,D201,R911,D486,R906,U719,L546,U324,R302,D200,L879,D206,L872,U681,R628,D272,R511,D827,L929,U915,L399,U696,R412,D640,R234,U487,R789,U354,L620,D914,L7,D228,L55,D591,L250,D228,R816,U935,R553,U98,L833,D418,R582,D793,R804,U283,R859,D206,L842,U663,L935,U495,L995,D181,R75,D33,R126,U489,L894,D675,R33,U239,L623,D931,L830,U63,R77,D576,L85,D415,R443,U603,R654,U495,L273,U583,R10,D648,L840,U904,R489,D655,R997,U559,L614,U917,R809,U540,L41,U519,R256,U111,R29,D603,L931,U518,R443,D51,L788,U483,L665,U890,L392,D701,R907,D125,L438,D107,L266,U766,R743,D343,R898,U293,L318,U417,L23,U44,L668,U614,R83,U31,R452,U823,R16,D418,R68,U823,L53,D638,L394,D714,R992,U196,R913,D526,L458,U428,L412,U901,R610,U348,L904,D815,R274,U439,R207,D81,L20,D507,L179,U249,L221,U603,L897,U490,R127,U99,L709,U925,L818,D777,R292,U935,R801,U331,R412,U759,L698,D53,L969,U492,L502,D137,R513,D999,L808,D618,L240,U378,L284,D726,L609,U530,R537,D36,L504,D26,R244,D692,L186,U767,L690,U182,R559,D926,R706,D132,L325,D846,R494,U238,L519,U655,R57,U658,L471,D717,L964,D346,L448,U286,L457,D504,R614,U652,R583,D780,R882,U417,R573,D297,L144,U347,L254,D589,L387,U309,L88,D510,R435,U636,L640,U801,R774,U678,R247,D846,L775,U527,L225,U798,R577,U897,R11,U153,L297,D748,L284,U806,R512,U906,L181,U39,R264,D47,L561,D441,L181,U210,L278,U998,R256,D278,R350,U466,L335,D310,L4,U298,L531,D423,R851,U285,L235,D139,R209,U882,R801,D36,L777,D153,L63";
            const string path2 = "L995,D598,R577,U346,L797,D375,R621,D709,R781,U55,R965,U327,L479,U148,L334,U93,R644,U632,L557,D136,L690,D548,R982,D703,L971,U399,R600,D785,L504,U984,R18,U190,L755,D737,L787,D921,R303,U513,L544,U954,L814,U239,R550,D458,R518,D538,R362,D350,L103,U17,L362,D480,L80,U639,L361,D75,L356,D849,R635,U633,R934,U351,L314,U960,R657,U802,L687,U385,L558,D984,L996,U765,L147,D366,R908,U981,R44,U336,R396,U85,R819,D582,L21,D920,L627,D103,R922,U195,L412,D385,L159,U446,L152,U400,L303,U549,R734,D709,R661,U430,R177,U857,L53,U555,R35,D919,L163,D630,L162,U259,R46,D89,R965,D410,R37,U39,R621,D606,L816,D659,L668,D418,L775,D911,R296,U488,L129,U869,L455,U663,L942,U813,L274,D677,R161,D338,R455,D580,R976,D984,L336,U742,R334,U130,L210,U523,R958,U177,R126,U469,L513,D14,L772,D423,L369,D661,R167,D449,L685,U871,L930,U630,L54,D581,L921,U839,R782,D844,L581,D995,R110,U365,L594,D595,R391,D298,R297,U469,L148,D34,R5,D609,L654,U172,R940,D858,L682,D92,R395,D683,R947,U311,L850,U151,R452,U641,L599,D640,R86,U584,L518,D597,L724,D282,L691,D957,L119,U30,L8,D514,R237,U599,R775,U413,R802,D132,R925,U133,L980,D981,R272,U632,R995,U427,R770,D722,L817,D609,R590,D799,L699,U923,L881,U893,R79,U327,L405,D669,L702,D612,R895,D132,R420,U958,L955,U993,L817,D492,R453,D342,L575,D253,R97,U54,R456,U748,L912,U661,L987,D182,L816,U218,R933,D797,L207,D71,R546,U578,L894,D536,L253,D525,L164,D673,R784,U915,L774,U586,R733,D80,L510,U449,L403,D915,L612,D325,L470,U179,L460,U405,R297,D803,R637,U893,R565,U952,R550,U936,R378,D932,L669";


            List<WirePath> wirePaths = new List<WirePath>();
            {
                var wirePath1TextInLine = path1.Split(',');
                var wirePath1 = new WirePath();
                wirePath1.AddRange(wirePath1TextInLine);
                wirePaths.Add(wirePath1);

                var wirePath2TextInLine = path2.Split(',');
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