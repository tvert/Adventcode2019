using MyRnD.AdventCode2019.Parts.Math2D;
using System;
using System.Collections.Generic;

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
        
        public (int closestIntersection, char[,] grid, List<Point> intersections, Point closestPoint)
            DistanceCentralPortToClosestIntersection(IReadOnlyList<WirePath> wirePaths, Rectangle fullBox, Size panelSize)
        {
            int closestDistance = int.MaxValue;
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
            foreach (var wire in wirePaths)
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

        #region Helpers - Calculate Intersection points and find the closest in terms of Taxicab geometry / Manhattan distance.

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