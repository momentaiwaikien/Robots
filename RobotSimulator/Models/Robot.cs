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
            Direction = CardinalDirection.ToVector[direction];

  
        }

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
            Direction = (Direction.Y * -1, Direction.X);

        }

        public void RotateRight()
        {
            Direction = (Direction.Y, Direction.X * -1);
        }

        public string Report()
        {
            return $"{Position.X},{Position.Y},{CardinalDirection.ToCardinal[Direction]}";
        }
    }
}