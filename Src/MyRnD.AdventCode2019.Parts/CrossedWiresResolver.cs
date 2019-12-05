using System;
using System.Collections.Generic;

namespace MyRnD.AdventCode2019.Parts
{
    /// <summary>
    /// A left bottom origin rectangle (O)
    /// ...........
    /// ...........
    /// ...........
    /// ....+----+.
    /// ....|....|.
    /// ....|....|.
    /// ....|....|.
    /// .........|.
    /// .P-------+.    Central Port
    /// O..........    Origin of rectangle (Left Bottom)
    /// 
    /// </summary>
    public sealed class Rectangle
    {
        public Rectangle()
        : this (new Point(0,0), new Point(0,0) )
        {
        }

        public Rectangle(Point leftBottom, Point rightTop)
        {
            LeftBottom = leftBottom;
            RightTop = rightTop;
        }

        public Point LeftBottom { get; }

        public Point RightTop { get; }

        public void AdjustDimensionToIncludePoint(Point newPoint)
        {
            LeftBottom.X = Math.Min(newPoint.X, LeftBottom.X);
            LeftBottom.Y = Math.Min(newPoint.Y, LeftBottom.Y);
            RightTop.X = Math.Max(newPoint.X, RightTop.X);
            RightTop.Y = Math.Max(newPoint.Y, RightTop.Y);
        }

        public override string ToString()
        {
            string s = $"LB [{LeftBottom.X}, {LeftBottom.Y}] => RT [{RightTop.X}, {RightTop.Y}]";
            return s;
        }

        public void Union(Rectangle addedRectangle)
        {
            LeftBottom.X = Math.Min(addedRectangle.LeftBottom.X, LeftBottom.X);
            LeftBottom.Y = Math.Min(addedRectangle.LeftBottom.Y, LeftBottom.Y);
            RightTop.X = Math.Max(addedRectangle.RightTop.X, RightTop.X);
            RightTop.Y = Math.Max(addedRectangle.RightTop.Y, RightTop.Y);
        }
    }

    public sealed class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public sealed class Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }



    public sealed class WirePath : List<string>
    {
        private Rectangle _box = null;

        public Rectangle Box => _box ?? CalculateWireBoxing();

        private Rectangle CalculateWireBoxing()
        {
            if (_box == null)
            {
               // Iterate through
                var tempBox = new Rectangle();
                Point currentPosition = new Point(0, 0);
                foreach (var step in this)
                {
                    currentPosition = UpdatePositionWithStep(step, currentPosition);
                    tempBox.AdjustDimensionToIncludePoint(currentPosition);
                }
                _box = tempBox;
            }
            return _box;
        }

        public Point UpdatePositionWithStep(string step, Point currentPosition)
        {
            var pathOrientation = step[0].ToString().ToUpper();
            var increment = int.Parse(step.Substring(1, step.Length - 1));
            var newPosition = new Point(currentPosition.X, currentPosition.Y);
            switch (pathOrientation)
            {
                case "L":
                    newPosition.Y -= increment;
                    break;
                case "R":
                    newPosition.Y += increment;
                    break;
                case "D":
                    newPosition.X -= increment;
                    break;
                case "U":
                    newPosition.X += increment;
                    break;
                default:
                    throw new InvalidOperationException(
                        $"Unknown orientation '{pathOrientation}' [Step: '{step}'] [Increment: '{increment}'].");
            }
            return newPosition;
        }
    }

    public sealed class CrossedWiresResolver
    {
        public const char CellCentralPort = 'o';
        public const char CellHorizontalWire = '-';
        public const char CellVerticalWire = '|';
        //const char CellTurnedWire = '+';
        public const char CellCrossedWire = 'X';
        public const char CellEmpty = '.';


        private Rectangle _fullBox = null;
        private Size _panelSize = null;

        public CrossedWiresResolver(List<WirePath> wirePaths)
        {
            WirePaths = wirePaths;
        }

        public IReadOnlyList<WirePath> WirePaths { get; }

        public Rectangle FullBox => _fullBox ?? CalculateAllWiresBoxing();

        public Size PanelSize => _panelSize ?? CalculatePanelSize();

        public (int shortest, char[,] grid) DistanceCentralPortToClosestIntersection()
        {
            int closestDistance = -1;

            Rectangle fullBox = FullBox;
            var panelSize = PanelSize;
            char[,] grid = new char[panelSize.Width+1, panelSize.Height+1];

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

            foreach (var wire in WirePaths)
            {
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
                                UpdateGridCell(currentCell, grid, movingCursor, CellHorizontalWire, step);
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
                                UpdateGridCell(currentCell, grid, movingCursor, CellHorizontalWire, step);
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
                                UpdateGridCell(currentCell, grid, movingCursor, CellVerticalWire, step);
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
                                UpdateGridCell(currentCell, grid, movingCursor, CellVerticalWire, step);
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


            return (closestDistance, grid);
        }

        private static void UpdateGridCell(char currentCell, char[,] grid, Point currentPosition, char updateCellValueWith, string step)
        {
            if (currentCell != CellCrossedWire && currentCell != CellCentralPort)
            {
                if (currentCell == CellEmpty)
                    grid[currentPosition.X, currentPosition.Y] = updateCellValueWith;
                else if (currentCell == CellHorizontalWire ||
                         currentCell == CellVerticalWire)
                    grid[currentPosition.X, currentPosition.Y] = CellCrossedWire;
                else
                    throw new InvalidOperationException(
                        $"Unknown cell '{currentCell}' at position [{currentPosition.X}, {currentPosition.Y}] for step '{step}'");
            }
        }

        #region Helpers

        private Size CalculatePanelSize()
        {
            if (_panelSize == null)
            {
                var fullBox = FullBox;
                int width = (int)Math.Ceiling((decimal)Math.Abs(fullBox.LeftBottom.X - fullBox.RightTop.X));
                int height = (int)Math.Ceiling((decimal)Math.Abs(fullBox.LeftBottom.Y - fullBox.RightTop.Y));
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
                Point currentPosition = new Point(0, 0);
                foreach (var wire in WirePaths)
                {
                    tempBox.Union(wire.Box);
                }
                _fullBox = tempBox;
            }
            return _fullBox;
        }

        #endregion
    }
}