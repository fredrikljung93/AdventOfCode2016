using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day4
{
    class PartOne
    {
        static void Main(string[] args)
        {
            string puzzleInput = File.ReadAllText("puzzleInput.txt");
            var rooms = SplitString(puzzleInput, Environment.NewLine);

            int sum = 0;
            foreach (var room in rooms)
            {
                sum += GetSectorId(room);
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }

        private static int GetSectorId(string room)
        {
            int[] count = new int['z' - 'a' + 1];
            var splitted = room.Split('[');
            var checksum = splitted[1].TrimEnd(']');
            int sectorIdIndex = room.LastIndexOf('-');
            int sectorId = int.Parse(splitted[0].Substring(sectorIdIndex + 1));

            foreach (char c in room.Substring(0, sectorIdIndex))
            {
                if (c != '-')
                {
                    count[c - 'a']++;
                }
            }
            return ChecksumIsLegit(checksum, count) ? sectorId : 0;
        }

        private static bool ChecksumIsLegit(string checksum, int[] count)
        {
            string calculatedChecksum = CalculateChecksum(count);
            return calculatedChecksum.Substring(0, checksum.Length) == checksum;
        }

        private static string[] SplitString(string input, string separator)
        {
            return input.Split(new string[] { separator }, StringSplitOptions.None);
        }

        private static string CalculateChecksum(int[] count)
        {
            var stringBuilder = new StringBuilder(26);

            foreach (int i in GetOccuringCountsDescending(count))
            {
                foreach (char c in "abcdefghijklmnopqrstuvwxyz")
                {
                    if (count[c - 'a'] == i)
                    {
                        stringBuilder.Append(c);
                    }
                }
            }
            return stringBuilder.ToString();
        }

        private static List<int> GetOccuringCountsDescending(int[] count)
        {
            int maxCount = 0;
            for (int i = 0; i < count.Length; i++)
            {
                maxCount = count[i] > maxCount ? count[i] : maxCount;
            }

            var occuringCounts = new List<int>(26);
            occuringCounts.Add(maxCount);

            for (int occuringCandidate = maxCount - 1; occuringCandidate >= 0; occuringCandidate--)
            {
                foreach (int occuringCount in count)
                {
                    if (occuringCount == occuringCandidate)
                    {
                        occuringCounts.Add(occuringCount);
                        break;
                    }
                }
            }
            return occuringCounts;
        }
    }
}