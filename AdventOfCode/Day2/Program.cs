using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static string puzzleInput = File.ReadAllText("puzzleInput.txt");
        static int[,] KeyPad = new int[3, 3] {  {1,2,3} ,
                                                {4,5,6} ,
                                                {7,8,9} };
        static char[,] KeyPad2 = new char[5, 5] {  {'-','-','1','-','-'},
                                                   {'-','2','3','4','-'},
                                                   {'5','6','7','8','9'},
                                                   {'-','A','B','C','-'},
                                                   {'-','-','D','-','-'}
        };
        static int Row;
        static int Column;


        static void Main(string[] args)
        {
            var instructions = puzzleInput.Replace(" ", string.Empty).Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // Part one
            Row = 1;
            Column = 1;
            foreach (var instruction in instructions)
            {
                HandleInstruction(instruction);
                Console.Write(KeyPad[Row, Column]);
            }
            Console.Write("\n");

            // Part two
            Row = 2;
            Column = 0;
            foreach (var instruction in instructions)
            {
                HandleInstruction2(instruction);
                Console.Write(KeyPad2[Row, Column]);
            }
            Console.Write("\n");

            Console.Read();
        }

        static void HandleInstruction2(string instruction)
        {
            foreach (char c in instruction)
            {
                switch (c)
                {
                    case 'U':
                        if (Row > 0 && KeyPad2[Row - 1, Column] != '-')
                            Row--;
                        break;
                    case 'D':
                        if (Row < 4 && KeyPad2[Row + 1, Column] != '-')
                            Row++;
                        break;
                    case 'L':
                        if (Column > 0 && KeyPad2[Row, Column - 1] != '-')
                            Column--;
                        break;
                    case 'R':
                        if (Column < 4 && KeyPad2[Row, Column + 1] != '-')
                            Column++;
                        break;
                }
            }
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
