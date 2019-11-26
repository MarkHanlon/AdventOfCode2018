using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            List<string> lines = new List<string>();
            string line = "0";

            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    line = sr.ReadLine();

                    while (!String.IsNullOrWhiteSpace(line))
                    {
                        lines.Add(line);
                        line = sr.ReadLine();
                    }
                }

                int first = 0, second = 0;

                for (int i = 0; i < lines.Count - 1; i++)
                {
                    for (int j = i + 1; j < lines.Count - 1; j++)
                    {
                        if (OneCharDifferent(lines[i], lines[j]))
                        {
                            first = i;
                            second = j;
                            break;
                        }
                    }
                }

                int pos = FindDifferentCharacterPosition(lines[first], lines[second]);
                string answer = lines[first].Remove(pos) + lines[first].Substring(pos+1);
                timer.Stop();
                Console.WriteLine($"Answer is {answer}, in {timer.ElapsedMilliseconds}ms");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
                return;
            }
            
            
        }

        private static int FindDifferentCharacterPosition(string v1, string v2)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] != v2[i])
                    return i;
            }

            return -1; // Shouldn't get here!
        }

        private static bool OneCharDifferent(string v1, string v2)
        {
            int differences = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] != v2[i])
                    differences++;
            }
            
            if (differences == 1)
                return true;
            else
                return false;
        }

    }
}
