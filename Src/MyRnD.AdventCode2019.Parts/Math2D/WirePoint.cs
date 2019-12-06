namespace MyRnD.AdventCode2019.Parts.Math2D
{
    public sealed class WirePoint
    {
        public WirePoint(int x, int y)
            : this(x, y, false, 0)
        {
        }

        public WirePoint(Point p, int steps)
            : this(p.X, p.Y, false, steps)
        {
        }

        public WirePoint(WirePoint wp)
            : this(wp.X, wp.Y, wp.IsCrossed, wp.Steps)
        {
        }

        public WirePoint(int x, int y, bool isCrossed, int steps)
        {
            X = x;
            Y = y;
            IsCrossed = isCrossed;
            Steps = steps;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public bool IsCrossed { get; set; }
        public int Steps { get; set; }

        public bool AreSameCoordinate(WirePoint wp2)
        {
            return X == wp2.X && Y == wp2.Y;
        }

        public override string ToString()
        {
            string s = $"[{X}, {Y} | IsX: '{IsCrossed}' | #{Steps} steps]";
            return s;
        }
    }
}