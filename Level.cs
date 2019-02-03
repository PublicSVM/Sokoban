using System.Collections.Generic;

namespace Sokoban
{
    internal class Level
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Tile PlayerPosition { get; set; }
        public List<Tile> Walls { get; set; }
        public List<Tile> Targets { get; set; }
        public List<Tile> Boxes { get; set; }

        public Level(int width, int height, Tile playerPosition, List<Tile> walls, List<Tile> targets, List<Tile> boxes)
        {
            Width = width;
            Height = height;
            PlayerPosition = playerPosition;
            Walls = walls;
            Targets = targets;
            Boxes = boxes;
        }
    }
}
