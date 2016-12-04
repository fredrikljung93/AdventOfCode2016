using System;

namespace One
{
    public enum Directions { north, west, south, east };

    class Program
    {
        public static string puzzleString = "R3, L5, R2, L2, R1, L3, R1, R3, L4, R3, L1, L1, R1, L3, R2, L3, L2, R1, R1, L1, R4, L1, L4, R3, L2, L2, R1, L1, R5, R4, R2, L5, L2, R5, R5, L2, R3, R1, R1, L3, R1, L4, L4, L190, L5, L2, R4, L5, R4, R5, L4, R1, R2, L5, R50, L2, R1, R73, R1, L2, R191, R2, L4, R1, L5, L5, R5, L3, L5, L4, R4, R5, L4, R4, R4, R5, L2, L5, R3, L4, L4, L5, R2, R2, R2, R4, L3, R4, R5, L3, R5, L2, R3, L1, R2, R2, L3, L1, R5, L3, L5, R2, R4, R1, L1, L5, R3, R2, L3, L4, L5, L1, R3, L5, L2, R2, L3, L4, L1, R1, R4, R2, R2, R4, R2, R2, L3, L3, L4, R4, L4, L4, R1, L4, L4, R1, L2, R5, R2, R3, R3, L2, L5, R3, L3, R5, L2, R3, R2, L4, L3, L1, R2, L2, L3, L5, R3, L1, L3, L4, L3";
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