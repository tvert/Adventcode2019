using System;
using System.Collections.Generic;
using System.Text;

namespace MyRnD.AdventCode2019.Parts
{
    public sealed class CrossedWiresResolver
    {
        public const char CellCentralPort = 'o';
        public const char CellHorizontalWire = '-';
        public const char CellVerticalWire = '|';
        public const char CellTurnedWire = '+';
        public const char CellCrossedWire = 'X';
        public const char CellEmpty = '.';

        private Rectangle _fullBox;
        private Size _panelSize;
        private int? _closestIntersectionDistance;
        private Point _closestIntersectionPoint;
        private char[,] _visualGrid;
        private List<Point> _intersections;


        public CrossedWiresResolver(List<WirePath> wirePaths)
        {
            WirePaths = wirePaths;
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
            (int closestDistance, char[,] grid, List<Point> intersections, Point closestPoint) = DistanceCentralPortToClosestIntersection();

            _closestIntersectionDistance = closestDistance;
            _visualGrid = grid;
            _intersections = intersections;
            _closestIntersectionPoint = closestPoint;
        }

        private (int closestIntersection, char[,] grid, List<Point> intersections, Point closestPoint) DistanceCentralPortToClosestIntersection()
        {
            int closestDistance = int.MaxValue;

            Rectangle fullBox = FullBox;
            var panelSize = PanelSize;
            char[,] grid = new char[panelSize.Width, panelSize.Height];

            // Initialize the array with the 'Empty cell' character
            int horizontalBound = grid.GetUpperBound(0);
            int verticalBound = grid.GetUpperBound(1);
            for (int w = 0; w <= horizontalBound; w++)
            {
                for (int h = 0; h <= verticalBound; h++)
                {
                    grid[w, h] = CellEmpty;
                }
            }

            int originX = -fullBox.LeftBottom.X;
            int originY = -fullBox.LeftBottom.Y;
            var centralPortOrigin = new Point(originX, originY);

            grid[centralPortOrigin.X, centralPortOrigin.Y] = CellCentralPort;
            var previousCell = CellCentralPort;

            int wireNum = 0;
            foreach (var wire in WirePaths)
            {
                wireNum++;
                char wireNumberChar = char.Parse(wireNum.ToString());
                var currentPosition = centralPortOrigin;
                foreach (var step in wire)
                {
                    var pathOrientation = step[0].ToString().ToUpper();
                    var increment = int.Parse(step.Substring(1, step.Length - 1));
                    var newPosition = new Point(currentPosition.X, currentPosition.Y);
                    switch (pathOrientation)
                    {
                        case "L":
                            {
                                newPosition.Y -= increment;
                                var movingCursor = new Point(currentPosition.X, currentPosition.Y);
                                for (int inc = 0; inc < increment; inc++)
                                {
                                    movingCursor.Y = currentPosition.Y - inc;
                                    var currentCell = grid[movingCursor.X, movingCursor.Y];
                                    //previousCell = UpdateGridCell(currentCell, previousCell, grid, movingCursor, CellHorizontalWire, step);
                                    previousCell = UpdateGridCell(currentCell, previousCell, grid, movingCursor, wireNumberChar, step);
                                }
                            }
                            break;
                        case "R":
                            {
                                newPosition.Y += increment;
                                var movingCursor = new Point(currentPosition.X, currentPosition.Y);
                                for (int inc = 0; inc < increment; inc++)
                                {
                                    movingCursor.Y = currentPosition.Y + inc;
                                    var currentCell = grid[movingCursor.X, movingCursor.Y];
                                    //previousCell = UpdateGridCell(currentCell, previousCell, grid, movingCursor, CellHorizontalWire, step);
                                    previousCell = UpdateGridCell(currentCell, previousCell, grid, movingCursor, wireNumberChar, step);
                                }
                            }
                            break;
                        case "D":
                            {
                                newPosition.X -= increment;
                                var movingCursor = new Point(currentPosition.X, currentPosition.Y);
                                for (int inc = 0; inc < increment; inc++)
                                {
                                    movingCursor.X = currentPosition.X - inc;
                                    var currentCell = grid[movingCursor.X, movingCursor.Y];
                                    //previousCell = UpdateGridCell(currentCell, previousCell, grid, movingCursor, CellVerticalWire, step);
                                    previousCell = UpdateGridCell(currentCell, previousCell, grid, movingCursor, wireNumberChar, step);
                                }
                            }
                            break;
                        case "U":
                            {
                                newPosition.X += increment;
                                var movingCursor = new Point(currentPosition.X, currentPosition.Y);
                                for (int inc = 0; inc < increment; inc++)
                                {
                                    movingCursor.X = currentPosition.X + inc;
                                    var currentCell = grid[movingCursor.X, movingCursor.Y];
                                    //previousCell = UpdateGridCell(currentCell, previousCell, grid, movingCursor, CellVerticalWire, step);
                                    previousCell = UpdateGridCell(currentCell, previousCell, grid, movingCursor, wireNumberChar, step);
                                }
                            }
                            break;
                        default:
                            throw new InvalidOperationException(
                                $"Unknown orientation '{pathOrientation}' [Step: '{step}'] [Increment: '{increment}'].");
                    }


                    currentPosition = newPosition;
                }

            }

            List<Point> intersections = new List<Point>();
            for (int w = 0; w <= horizontalBound; w++)
            {
                for (int h = 0; h <= verticalBound; h++)
                {
                    if (grid[w, h] == CellCrossedWire)
                    {
                        var newIntersection = new Point(w, h);
                        intersections.Add(newIntersection);
                    }
                }
            }

            Point closestPoint = centralPortOrigin;
            foreach (var intersectionPoint in intersections)
            {
                int distanceX = centralPortOrigin.X - intersectionPoint.X;
                distanceX = distanceX >= 0 ? distanceX : -distanceX;
                int distanceY = centralPortOrigin.Y - intersectionPoint.Y;
                distanceY = distanceY >= 0 ? distanceY : -distanceY;
                int tempClosestDistance = Math.Min(closestDistance, distanceX + distanceY);
                if (tempClosestDistance != closestDistance)
                {
                    closestPoint = intersectionPoint;
                    closestDistance = tempClosestDistance;
                }
            }

            return (closestDistance, grid, intersections, closestPoint);
        }

        private static char UpdateGridCell(char currentCell, char previousCell, char[,] grid, Point currentPosition, char updateCellValueWith, string step)
        {
            char result = currentCell;
            if (currentCell != CellCrossedWire && currentCell != CellCentralPort)
            {
                if (currentCell == CellEmpty)
                {
                    updateCellValueWith = (previousCell == updateCellValueWith ||
                                           previousCell == CellCentralPort ||
                                           previousCell == CellTurnedWire ||
                                           previousCell == CellCrossedWire ||
                                           previousCell == CellEmpty) ? updateCellValueWith : CellTurnedWire;
                    result = grid[currentPosition.X, currentPosition.Y] = updateCellValueWith;

                }
                else if (currentCell == updateCellValueWith &&
                         (updateCellValueWith == '1' | updateCellValueWith == '2'))
                    result = grid[currentPosition.X, currentPosition.Y] = updateCellValueWith;
                else if (currentCell != updateCellValueWith &&
                         (updateCellValueWith == '1' | updateCellValueWith == '2'))
                    result = grid[currentPosition.X, currentPosition.Y] = CellCrossedWire;
                else if (currentCell == CellHorizontalWire ||
                         currentCell == CellVerticalWire ||
                         currentCell == CellTurnedWire)
                    result = grid[currentPosition.X, currentPosition.Y] = CellCrossedWire;
                else
                    throw new InvalidOperationException(
                        $"Unknown cell '{currentCell}' at position [{currentPosition.X}, {currentPosition.Y}] for step '{step}' updating with '{updateCellValueWith}'");
            }
            return result;
        }

        #endregion

    }
}