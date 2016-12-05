using System;
using System.IO;

namespace Day1
{
    public enum Directions { north, west, south, east };

    class PartOne
    {
        public static string puzzleString = File.ReadAllText("puzzleInput.txt");
        public static Directions direction = Directions.north;
        public static int northSteps = 0;
        public static int eastSteps = 0;

        static void Main(string[] args)
        {
            var instructions = puzzleString.Replace(" ", string.Empty).Split(',');

            foreach (var instruction in instructions)
            {
                HandleInstruction(instruction);
            }

            Console.WriteLine("North steps: " + northSteps);
            Console.WriteLine("East steps: " + eastSteps);
            int blocksAway = Math.Abs(northSteps) + Math.Abs(eastSteps);
            Console.WriteLine("Blocks away: " + blocksAway);
            Console.ReadLine();
        }

        static void HandleInstruction(string instruction)
        {
            bool goLeft = instruction[0] == 'L';
            int steps = int.Parse(instruction.Substring(1));

            switch (direction)
            {
                case Directions.north:
                    eastSteps += goLeft ? (steps * -1) : steps;
                    direction = goLeft ? Directions.west : Directions.east;
                    break;
                case Directions.west:
                    northSteps += goLeft ? (steps * -1) : steps;
                    direction = goLeft ? Directions.south : Directions.north;
                    break;
                case Directions.south:
                    eastSteps += goLeft ? steps : (steps * -1);
                    direction = goLeft ? Directions.east : Directions.west;
                    break;
                case Directions.east:
                    northSteps += goLeft ? steps : (steps * -1);
                    direction = goLeft ? Directions.north : Directions.south;
                    break;
            }
        }
    }
}