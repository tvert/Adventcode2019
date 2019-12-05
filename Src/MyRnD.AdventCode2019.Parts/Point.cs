namespace MyRnD.AdventCode2019.Parts
{
    public sealed class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            string s = $"[{X}, {Y}]";
            return s;
        }
    }
}