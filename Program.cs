using System;
using System.IO;

namespace Sokoban
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"Resources\Levels\level0.txt");
            var level = LevelParser.Parse(lines);
            var game = new SokobanGame(level);

            while (true)
            {
                Console.Clear();
                Display(game.Level);

                if (game.HasWon())
                {
                    Console.WriteLine("\nYou won!\n");
                    return;
                }

                Console.WriteLine("\nWASD or arrow keys to move\nEsc to exit");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        game.MovePlayer(Direction.North);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        game.MovePlayer(Direction.East);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        game.MovePlayer(Direction.South);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        game.MovePlayer(Direction.West);
                        break;
                }
            }
        }

        public static void Display(Level level)
        {
            for (var y = 0; y < level.Height; y++)
            {
                for (var x = 0; x < level.Width; x++)
                {
                    Console.Write(CharacterAt(level, new Tile(x, y)));
                }
                Console.WriteLine();
            }
        }

        private static char CharacterAt(Level level, Tile tile)
        {
            if (level.Walls.Contains(tile))
            {
                return Constants.Wall;
            }

            if (level.PlayerPosition.Equals(tile))
            {
                return level.Targets.Contains(tile)
                    ? Constants.PlayerOnTarget
                    : Constants.Player;
            }

            if (level.Boxes.Contains(tile))
            {
                return level.Targets.Contains(tile)
                    ? Constants.BoxOnTarget
                    : Constants.Box;
            }

            return level.Targets.Contains(tile)
                ? Constants.Target
                : Constants.Empty;
        }
    }
}
