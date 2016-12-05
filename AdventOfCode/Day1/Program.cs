using System;
using System.IO;

namespace Day1
{
    public enum Directions { north, west, south, east };

    class Program
    {
        public static string puzzleString = File.ReadAllText("puzzleInput.txt");
        public static Directions direction = Directions.north;
        public static int northSteps = 0;
        public static int eastSteps = 0;
        public static bool doneFirstReturn = false;
        public static int firstReturnNorth = 0;
        public static int firstReturnEast = 0;

        static bool[,] VisitMap = new bool[5000, 5000];

        static void Main(string[] args)
        {
            var instructions = puzzleString.Replace(" ", string.Empty).Split(',');

            foreach (var instruction in instructions)
            {
                HandleInstruction(instruction);
            }

            int finalDestinationBlocksAway = Math.Abs(northSteps) + Math.Abs(eastSteps);
            int firstReturnBlocksAway = Math.Abs(firstReturnNorth) + Math.Abs(firstReturnEast);
            Console.WriteLine("Blocks away to final destination: " + finalDestinationBlocksAway);
            Console.WriteLine("Blocks away to first return: " + firstReturnBlocksAway);
            Console.ReadLine();
        }

        static void CheckVisitMap()
        {
            if (!doneFirstReturn)
            {
                if (VisitMap[2500 - northSteps, 2500 - eastSteps])
                {
                    firstReturnEast = eastSteps;
                    firstReturnNorth = northSteps;
                    doneFirstReturn = true;
                }
                VisitMap[2500 - northSteps, 2500 - eastSteps] = true;
            }
        }

        static void HandleInstruction(string instruction)
        {
            bool goLeft = instruction[0] == 'L';
            int steps = int.Parse(instruction.Substring(1));

            switch (direction)
            {
                case Directions.north:

                    for (int i = 0; i < steps; i++)
                    {
                        eastSteps += goLeft ? -1 : 1;
                        CheckVisitMap();
                    }
                    direction = goLeft ? Directions.west : Directions.east;
                    break;

                case Directions.west:
                    for (int i = 0; i < steps; i++)
                    {
                        northSteps += goLeft ? -1 : 1;
                        CheckVisitMap();
                    }
                    direction = goLeft ? Directions.south : Directions.north;
                    break;
                case Directions.south:
                    for (int i = 0; i < steps; i++)
                    {
                        eastSteps += goLeft ? 1 : -1;
                        CheckVisitMap();
                    }
                    direction = goLeft ? Directions.east : Directions.west;
                    break;
                case Directions.east:
                    for (int i = 0; i < steps; i++)
                    {
                        northSteps += goLeft ? 1 : -1;
                        CheckVisitMap();
                    }
                    direction = goLeft ? Directions.north : Directions.south;
                    break;
            }
        }
    }
}