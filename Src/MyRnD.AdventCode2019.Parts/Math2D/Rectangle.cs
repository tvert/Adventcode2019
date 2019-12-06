using System;

namespace MyRnD.AdventCode2019.Parts.Math2D
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

        public void AdjustDimensionToIncludePoint(WirePoint newPoint)
        {
            AdjustDimensionToIncludePoint(newPoint.X, newPoint.Y);
        }

        public void AdjustDimensionToIncludePoint(Point newPoint)
        {
            AdjustDimensionToIncludePoint(newPoint.X, newPoint.Y);
        }

        public void AdjustDimensionToIncludePoint(int newPointX, int newPointY)
        {
            LeftBottom.X = Math.Min(newPointX, LeftBottom.X);
            LeftBottom.Y = Math.Min(newPointY, LeftBottom.Y);
            RightTop.X = Math.Max(newPointX, RightTop.X);
            RightTop.Y = Math.Max(newPointY, RightTop.Y);
        }

        public override string ToString()
        {
            string s = $"LB {LeftBottom} => RT {RightTop}";
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
}