using System;
using System.Security.Cryptography;
using System.Text;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzleInput = "uqwqemis";
            string password1 = string.Empty;
            string password2 = "________";
            bool partTwoDone = false;

            int index;
            for (int i = 0; password1.Length < 8 || !partTwoDone; i++)
            {
                string candidate = ToMD5(puzzleInput + i);
                if (candidate.StartsWith("00000"))
                {
                    if (password1.Length < 8)
                    {
                        password1 = password1 + candidate[5];
                        Console.WriteLine("Password 1 progress: " + password1);
                    }

                    if (int.TryParse(candidate[5] + string.Empty, out index))
                    {
                        if (index < password2.Length && password2[index] == '_')
                        {
                            var array = password2.ToCharArray();
                            array[index] = candidate[6];
                            password2 = new string(array);
                            Console.WriteLine("Password 2 progress: " + password2);
                            if (!password2.Contains("_"))
                            {
                                partTwoDone = true;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Password 1: " + password1);
            Console.WriteLine("Password 2: " + password2);
            Console.ReadLine();
        }

        static string ToMD5(string plain)
        {
            var plainBytes = new UTF8Encoding().GetBytes(plain);
            var hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(plainBytes);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
