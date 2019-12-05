namespace MyRnD.AdventCode2019.Parts
{
    public sealed class Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            string s = $"[w={Width} x h={Height}]";
            return s;
        }
    }
}