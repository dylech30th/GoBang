namespace GoBang
{
    public class Point
    {
        public Point(int x, int y, Chessman chessman)
        {
            X = x;
            Y = y;
            Chessman = chessman;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Chessman Chessman { get; set; }
    }
}