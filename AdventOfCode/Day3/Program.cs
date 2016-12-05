using System;
using System.IO;
namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            int partOneCount = 0;
            int partTwoCount = 0;
            string puzzleInput = File.ReadAllText("puzzleInput.txt");
            var rows = SplitString(puzzleInput, Environment.NewLine);

            foreach (var row in rows)
            {
                int a = int.Parse(row.Substring(2, 3));
                int b = int.Parse(row.Substring(7, 3));
                int c = int.Parse(row.Substring(12, 3));

                if (IsValidTriangle(a, b, c))
                    partOneCount++;
            }

            int rowCount = 0;
            while (rowCount < rows.Length)
            {
                int[] col1 = new int[3];
                int[] col2 = new int[3];
                int[] col3 = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    string currentRow = rows[i + rowCount];
                    col1[i] = int.Parse(currentRow.Substring(2, 3));
                    col2[i] = int.Parse(currentRow.Substring(7, 3));
                    col3[i] = int.Parse(currentRow.Substring(12, 3));
                }

                if (IsValidTriangle(col1))
                    partTwoCount++;
                if (IsValidTriangle(col2))
                    partTwoCount++;
                if (IsValidTriangle(col3))
                    partTwoCount++;

                rowCount += 3;
            }

            Console.WriteLine("Part 1 count: " + partOneCount);
            Console.WriteLine("Part 2 count: " + partTwoCount);
            Console.ReadLine();
        }
        private static bool IsValidTriangle(int[] array)
        {
            return IsValidTriangle(array[0], array[1], array[2]);
        }
        private static bool IsValidTriangle(int a, int b, int c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }
        private static string[] SplitString(string input, string separator)
        {
            return input.Split(new string[] { separator }, StringSplitOptions.None);
        }
    }
}