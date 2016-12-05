using System;
using System.IO;

namespace Day2
{
    class PartOne
    {
        static string puzzleInput = File.ReadAllText("puzzleInput.txt");
        static int[,] KeyPad = new int[3, 3] {  {1,2,3} ,
                                                {4,5,6} ,
                                                {7,8,9} };
        static int Row = 1;
        static int Column = 1;


        static void Main(string[] args)
        {
            var instructions = puzzleInput.Replace(" ", string.Empty).Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var instruction in instructions)
            {
                HandleInstruction(instruction);
                Console.Write(KeyPad[Row, Column]);
            }
            Console.Write("\n");
            Console.Read();
        }

        static void HandleInstruction(string instruction)
        {
            foreach (char c in instruction)
            {
                switch (c)
                {
                    case 'U':
                        Row--;
                        break;
                    case 'D':
                        Row++;
                        break;
                    case 'L':
                        Column--;
                        break;
                    case 'R':
                        Column++;
                        break;
                }
                Row = Row < 0 ? 0 : Row;
                Row = Row > 2 ? 2 : Row;
                Column = Column < 0 ? 0 : Column;
                Column = Column > 2 ? 2 : Column;
            }
        }
    }
}
