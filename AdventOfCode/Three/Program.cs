using System;
using System.IO;
namespace Three
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string puzzleInput = File.ReadAllText("puzzleInput.txt");
            var triangles = SplitString(puzzleInput, Environment.NewLine);

            foreach (var triangle in triangles)
            {
                int a = int.Parse(triangle.Substring(2, 3));
                int b = int.Parse(triangle.Substring(7, 3));
                int c = int.Parse(triangle.Substring(12, 3));

                if (isValidTriangle(a, b, c))
                    count++;
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }

        private static bool isValidTriangle(int a, int b, int c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }
        private static string[] SplitString(string input, string separator)
        {
            return input.Split(new string[] { separator }, StringSplitOptions.None);
        }
    }
}