using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "0";
            int twoRepeatCount = 0, threeRepeatCount = 0;

            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    line = sr.ReadLine();
                    while (!String.IsNullOrWhiteSpace(line))
                    {
                        if (ContainsADouble(line))
                            twoRepeatCount++;
                        if (ContainsATriple(line))
                            threeRepeatCount++;
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
                return;
            }
            
            Console.WriteLine($"Answer is {twoRepeatCount * threeRepeatCount}");
        }

        private static Dictionary<char, int> AnalyseString(string line)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in line.ToCharArray())
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] = dict[c] + 1;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            return dict;
        }
        private static bool ContainsATriple(string line)
        {
            var dict = AnalyseString(line);
            return (dict.Values.ToArray().Any(i => i == 3));
        }

        private static bool ContainsADouble(string line)
        {
            var dict = AnalyseString(line);
            return (dict.Values.ToArray().Any(i => i == 2));
        }
    }
}
