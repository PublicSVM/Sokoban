using System;

namespace Sokoban
{
    internal class SokobanGame
    {
        public Level Level { get; }

        public SokobanGame(Level level)
        {
            Level = level;
        }

        public void MovePlayer(Direction direction)
        {
            var nextPosition = new Tile(Level.PlayerPosition.X + direction.X, Level.PlayerPosition.Y + direction.Y);

            if (Level.Walls.Contains(nextPosition))
            {
                return;
            }

            if (!Level.Boxes.Contains(nextPosition))
            {
                Level.PlayerPosition = nextPosition;
                return;
            }

            var aheadOfNextPosition = new Tile(nextPosition.X + direction.X, nextPosition.Y + direction.Y);
            if (Level.Walls.Contains(aheadOfNextPosition) || Level.Boxes.Contains(aheadOfNextPosition))
            {
                return;
            }

            Level.Boxes.Remove(nextPosition);
            Level.Boxes.Add(aheadOfNextPosition);
            Level.PlayerPosition = nextPosition;
        }

        public bool HasWon()
        {
            foreach (var box in Level.Boxes)
            {
                if (!Level.Targets.Contains(box))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
