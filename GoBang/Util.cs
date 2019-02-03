namespace GoBang
{
    public static class Util
    {
        public static Point GetPoint(this Point[,] points, int x, int y)
        {
            return points[x, y];
        }

        public static bool IsNumber(this string source)
        {
            return int.TryParse(source, out _);
        }
    }
}