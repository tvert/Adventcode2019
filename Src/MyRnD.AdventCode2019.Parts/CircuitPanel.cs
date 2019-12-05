using MyRnD.AdventCode2019.Parts.Math2D;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRnD.AdventCode2019.Parts
{
    public sealed class CircuitPanel
    {
        private readonly CrossedWiresResolver _crossedWiresResolver;

        private Rectangle _fullBox;
        private Size _panelSize;
        private int? _closestIntersectionDistance;
        private Point _closestIntersectionPoint;
        private char[,] _visualGrid;
        private List<Point> _intersections;

        public CircuitPanel(List<WirePath> wirePaths, CrossedWiresResolver crossedWiresResolver)
        {
            WirePaths = wirePaths;
            _crossedWiresResolver = crossedWiresResolver;
        }

        public IReadOnlyList<WirePath> WirePaths { get; }

        public Rectangle FullBox => _fullBox ?? CalculateAllWiresBoxing();

        public Size PanelSize => _panelSize ?? CalculatePanelSize();

        public int ClosestIntersectionDistance => _closestIntersectionDistance ?? CalculateClosestIntersection();

        public Point ClosestIntersectionPoint => _closestIntersectionPoint ?? FindClosestIntersectionPoint();

        public char[,] VisualGrid => _visualGrid ?? GenerateVisualGrid();

        public List<Point> Intersections => _intersections ?? GenerateIntersections();

        public string VisualGridToString()
        {
            var visualGrid = VisualGrid;
            int horizontalBound = visualGrid.GetUpperBound(0);
            int verticalBound = visualGrid.GetUpperBound(1);
            var sb = new StringBuilder();
            for (int w = 0; w <= horizontalBound; w++)
            {
                for (int h = 0; h <= verticalBound; h++)
                {
                    sb.Append(visualGrid[w, h]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public string VerticalInvertedGridToString()
        {
            var visualGrid = VisualGrid;
            int horizontalBound = visualGrid.GetUpperBound(0);
            int verticalBound = visualGrid.GetUpperBound(1);
            var sb = new StringBuilder();
            for (int w = horizontalBound; w >= 0; w--)
            {
                for (int h = 0; h <= verticalBound; h++)
                {
                    sb.Append(visualGrid[w, h]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        #region Helpers - Boxing and Panel size

        private Size CalculatePanelSize()
        {
            if (_panelSize == null)
            {
                var fullBox = FullBox;
                int width = Math.Abs(fullBox.LeftBottom.X - fullBox.RightTop.X) + 1;
                int height = Math.Abs(fullBox.LeftBottom.Y - fullBox.RightTop.Y) + 1;
                _panelSize = new Size(width, height);
            }
            return _panelSize;
        }

        private Rectangle CalculateAllWiresBoxing()
        {
            if (_fullBox == null)
            {
                // Iterate through
                var tempBox = new Rectangle();
                foreach (var wire in WirePaths)
                {
                    tempBox.Union(wire.Box);
                }
                _fullBox = tempBox;
            }
            return _fullBox;
        }

        #endregion

        #region Calculate Intersection points and find the closest in terms of Taxicab geometry / Manhattan distance.

        private int CalculateClosestIntersection()
        {
            DoAndUpdateClosestIntersection();
            return _closestIntersectionDistance ?? 0;
        }

        private Point FindClosestIntersectionPoint()
        {
            DoAndUpdateClosestIntersection();
            return _closestIntersectionPoint;
        }

        private char[,] GenerateVisualGrid()
        {
            DoAndUpdateClosestIntersection();
            return _visualGrid;
        }

        private List<Point> GenerateIntersections()
        {
            DoAndUpdateClosestIntersection();
            return _intersections;
        }

        private void DoAndUpdateClosestIntersection()
        {
            (int closestDistance, char[,] grid, List<Point> intersections, Point closestPoint) = 
                _crossedWiresResolver.DistanceCentralPortToClosestIntersection(WirePaths, FullBox, PanelSize);

            _closestIntersectionDistance = closestDistance;
            _visualGrid = grid;
            _intersections = intersections;
            _closestIntersectionPoint = closestPoint;
        }
        #endregion

    }
}