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

        public void AdjustDimensionToIncludePoint(Point newPoint)
        {
            LeftBottom.X = Math.Min(newPoint.X, LeftBottom.X);
            LeftBottom.Y = Math.Min(newPoint.Y, LeftBottom.Y);
            RightTop.X = Math.Max(newPoint.X, RightTop.X);
            RightTop.Y = Math.Max(newPoint.Y, RightTop.Y);
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