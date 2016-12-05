using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day4
{
    class Program
    {
        static string alphabet = "abcdefghijklmnopqrstuvwxyz";
        static List<string> decryptedList = new List<string>();
        static void Main(string[] args)
        {
            string puzzleInput = File.ReadAllText("puzzleInput.txt");
            var rows = SplitString(puzzleInput, Environment.NewLine);

            int sum = 0;
            foreach (var row in rows)
            {
                int sectorId = GetSectorId(row);
                if (sectorId != 0)
                {
                    sum += sectorId;
                    Decrypt(sectorId, row);
                }
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }

        private static void Decrypt(int sectorId, string row)
        {
            int[] count = new int['z' - 'a' + 1];
            var splitted = row.Split('[');
            var checksum = splitted[1].TrimEnd(']');
            int sectorIdIndex = row.LastIndexOf('-');
            var chiffer = splitted[0].Substring(0, sectorIdIndex).ToCharArray();

            for (int i = 0; i < chiffer.Length; i++)
            {
                char c = chiffer[i];
                c = (char)(c - 'a');
                c = (char)(c + sectorId);
                c = (char)(c % alphabet.Length);
                c = (char)(c + 'a');
                chiffer[i] = c;
            }

            string decrypted = new string(chiffer);
            decryptedList.Add(decrypted);
            if (decrypted.Contains("north"))
            {
                Console.WriteLine(sectorId + ": " + decrypted);
            }
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
                foreach (char c in alphabet)
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