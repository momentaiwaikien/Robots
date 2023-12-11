namespace RobotSimulator.Models
{
    public static class WorldMap
    {
        public static int YLength = 5;
        public static int XLength = 5;

        public static bool CheckPosition((int X, int Y) pos)
        {
            return (pos.X >= 0 && pos.X < XLength && pos.Y >= 0 && pos.Y < YLength);
        }

        public static bool CheckPosition((string X, string Y) pos)
        {
            return CheckPosition((int.Parse(pos.X), int.Parse(pos.Y)));
        }
    }
}