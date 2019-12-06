using MyRnD.AdventCode2019.Parts.Math2D;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRnD.AdventCode2019.Parts
{
    public sealed class WirePath : List<string>
    {
        private Rectangle _box;
        private List<WirePoint> _wirePoints;

        public Rectangle Box => _box ?? CalculateWireBoxing();

        public List<WirePoint> WirePoints => _wirePoints ?? GenerateWirePoints();

        private Rectangle CalculateWireBoxing()
        {
            if (_box == null)
            {
                // Iterate through
                var tempBox = new Rectangle();
                var currentPosition = new WirePoint(0, 0);
                foreach (var step in this)
                {
                    (WirePoint newPosition, _)  = UpdatePositionWithStep(step, currentPosition);
                    tempBox.AdjustDimensionToIncludePoint(newPosition);
                    currentPosition = newPosition;
                }
                _box = tempBox;
            }
            return _box;
        }

        private List<WirePoint> GenerateWirePoints()
        {
            if (_wirePoints == null)
            {
                // Iterate through
                var tempPoints = new List<WirePoint>();
                var currentPosition = new WirePoint(0, 0);
                //tempPoints.Add(new WirePoint(currentPosition, panelSteps++));
                foreach (var wireCode in this)
                {
                    (WirePoint newPosition, List<WirePoint> newPoints) = UpdatePositionWithStep(wireCode, currentPosition);
                    tempPoints.AddRange(newPoints);
                    currentPosition = newPosition;
                }
                _wirePoints = tempPoints;
            }
            return _wirePoints;
        }

        private (WirePoint newPosition, List<WirePoint> newPoints) UpdatePositionWithStep(string wireCode, WirePoint currentPosition)
        {
            var newPoints = new List<WirePoint>();
            var pathOrientation = wireCode[0].ToString().ToUpper();
            var steps = int.Parse(wireCode.Substring(1, wireCode.Length - 1));
            //var newPosition = new WirePoint(currentPosition);
            int delta;
            var currentSteps = currentPosition.Steps;
            switch (pathOrientation)
            {
                case "D":
                {
                    delta = currentPosition.Y - steps;
                    for (int dy = currentPosition.Y - 1; dy >= delta; dy--)
                    {
                        var wirePoint = new WirePoint(currentPosition.X, dy, false, ++currentSteps);
                        newPoints.Add(wirePoint);
                    }
                    break;
                }
                case "U":
                {
                    delta = currentPosition.Y + steps;
                    for (int dy = currentPosition.Y + 1; dy <= delta; dy++)
                    {
                        var wirePoint = new WirePoint(currentPosition.X, dy, false, ++currentSteps);
                        newPoints.Add(wirePoint);
                    }
                    break;
                }
                case "L":
                {
                    delta = currentPosition.X - steps;
                    for (int dx = currentPosition.X - 1; dx >= delta; dx--)
                    {
                        var wirePoint = new WirePoint(dx, currentPosition.Y, false, ++currentSteps);
                        newPoints.Add(wirePoint);
                    }
                    break;
                }
                case "R":
                {
                    delta = currentPosition.X + steps;
                    for (int dx = currentPosition.X + 1; dx <= delta; dx++)
                    {
                        var wirePoint = new WirePoint(dx, currentPosition.Y, false, ++currentSteps);
                        newPoints.Add(wirePoint);
                    }
                    break;
                }
                default:
                    throw new InvalidOperationException(
                        $"Unknown orientation '{pathOrientation}' [Step: '{wireCode}'] [Increment: '{steps}'].");
            }
            return (newPoints.Last(), newPoints);
        }

        //TODO-JOAO-REMOVE
#if false
        private List<WirePoint> GenerateWirePoints2()
        {
            if (_wirePoints == null)
            {
                // Iterate through
                var tempPoints = new List<WirePoint>();
                var currentPosition = new WirePoint(0, 0);
                int panelSteps = 0;
                //tempPoints.Add(new WirePoint(currentPosition, panelSteps++));
                foreach (var wireCode in this)
                {
                    (int steps, WirePoint newPosition) = UpdatePositionWithStep(wireCode, currentPosition);
                    if (currentPosition.X == newPosition.X)
                    {
                        int y = currentPosition.Y + 1;
                        int increment = (steps > 0) ? +1 : -1;
                        while (steps != 0)
                        {
                            var wirePoint = new WirePoint(newPosition.X, y, false, panelSteps++);
                            tempPoints.Add(wirePoint);
                            steps -= increment;
                            y += increment;
                        }
                    }
                    else
                    {
                        int x = currentPosition.X + 1;
                        int increment = (steps > 0) ? +1 : -1;
                        while (steps != 0)
                        {
                            var wirePoint = new WirePoint(x, newPosition.Y, false, panelSteps++);
                            tempPoints.Add(wirePoint);
                            steps -= increment;
                            x += increment;
                        }
                    }
                    currentPosition = newPosition;
                }
                _wirePoints = tempPoints;
            }
            return _wirePoints;
        }
#endif

    }
}