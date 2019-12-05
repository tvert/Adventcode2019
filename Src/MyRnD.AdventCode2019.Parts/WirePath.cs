using System;
using System.Collections.Generic;

namespace MyRnD.AdventCode2019.Parts
{
    public sealed class WirePath : List<string>
    {
        private Rectangle _box;

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
}