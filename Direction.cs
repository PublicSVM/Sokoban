namespace Sokoban
{
    internal class Direction
    {
        public static readonly Direction North = new Direction(0, -1);
        public static readonly Direction East = new Direction(1, 0);
        public static readonly Direction South = new Direction(0, 1);
        public static readonly Direction West = new Direction(-1, 0);

        public int X { get; }
        public int Y { get; }

        private Direction(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
