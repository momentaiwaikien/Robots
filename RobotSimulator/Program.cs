using RobotSimulator.Models;
using System;
using System.Text.RegularExpressions;

namespace RobotSimulator
{
    internal class Program
    {
        private static bool _isRobotPlaced = false;

        private 
        static void Main(string[] args)
        {
            Robot robot = null;
            while(true)
            {
                Console.WriteLine("Enter a command:");
                var command = Console.ReadLine().ToUpper();
                if (!Regex.IsMatch(command, @"((PLACE) \d+,\d+,((NORTH)|(EAST)|(SOUTH)|(WEST)))|(REPORT)|(MOVE)|(LEFT)|(RIGHT)", RegexOptions.Singleline))
                {
                    Console.WriteLine("Invalid Command, Please try again");
                }
                else
                {
                    var parts = command.Split(' ');
                    switch (parts[0])
                    {
                        case "EXIT":
                            return;
                        case "LEFT":
                            robot?.RotateLeft();
                            break;
                        case "RIGHT":
                            robot?.RotateRight();
                            break;
                        case "MOVE":
                            robot?.MoveForward();
                            break;
                        case "REPORT":
                            Console.WriteLine(robot?.Report());
                            break;
                        default:
                            var placeCommands = parts[1].Split(',');
                            if (WorldMap.CheckPosition((placeCommands[0], placeCommands[1])))
                            {
                                robot = new Robot(placeCommands[0], placeCommands[1], placeCommands[2]);
                            }
                            else
                            {
                                Console.WriteLine("Placement is out of bounds");
                            }
                            break;

                    }
                }
            }
        }
    }
}
