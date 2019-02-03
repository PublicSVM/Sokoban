using System.Collections.Generic;
using System.Linq;

namespace Sokoban
{
    internal static class LevelParser
    {
        internal static Level Parse(string[] lines)
        {
            var width = lines.Max(l => l.Length);
            var height = lines.Length;
            var walls = new List<Tile>();
            var targets = new List<Tile>();
            var boxes = new List<Tile>();
            var playerX = 0;
            var playerY = 0;

            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    var c = line[x];
                    if (c == Constants.Target)
                    {
                        targets.Add(new Tile(x, y));
                    }
                    else if (c == Constants.Wall)
                    {
                        walls.Add(new Tile(x, y));
                    }
                    else if (c == Constants.Player)
                    {
                        playerX = x;
                        playerY = y;
                    }
                    else if (c == Constants.PlayerOnTarget)
                    {
                        playerX = x;
                        playerY = y;
                        targets.Add(new Tile(x, y));
                    }
                    else if (c == Constants.Box)
                    {
                        boxes.Add(new Tile(x, y));
                    }
                    else if (c == Constants.BoxOnTarget)
                    {
                        boxes.Add(new Tile(x, y));
                        targets.Add(new Tile(x, y));
                    }
                }
            }

            var playerPosition = new Tile(playerX, playerY);
            return new Level(width, height, playerPosition, walls, targets, boxes);
        }
    }
}
