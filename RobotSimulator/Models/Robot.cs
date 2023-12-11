using System;

namespace RobotSimulator.Models
{
    public class Robot
    {
        public Robot(string xPosition, string yPosition, string direction)
        {
            var x = int.Parse(xPosition);
            var y = int.Parse(yPosition);
            Position = (x, y);
            Enum.TryParse(direction, out CardinalDirection dir);
            CardinalDirection = dir;
            switch (dir)
            {
                case CardinalDirection.North:
                    Direction = (0, 1);
                    break;
                case CardinalDirection.South:
                    Direction = (0, -1);
                    break;
                case CardinalDirection.East:
                    Direction = (1, 0);
                    break;
                case CardinalDirection.West:
                    Direction = (-1, 0);
                    break;
            }
        }

        public CardinalDirection CardinalDirection { get; private set; }
        public (int X, int Y) Position { get; private set; }

        public (int X, int Y) Direction { get; private set; }

        public void MoveForward()
        {
            var newLocation = (Position.X + Direction.X, Position.Y + Direction.Y);
            if (WorldMap.CheckPosition(newLocation))
            {
                Position = newLocation;
            }
        }

        public void RotateLeft()
        {
            Position = (Position.Y * -1, Position.X);

        }

        public void RotateRight()
        {
            Position = (Position.Y, Position.X * -1);
        }

        public string Report()
        {
            return $"{Position.X},{Position.Y},{CardinalDirection}";
        }
    }
}