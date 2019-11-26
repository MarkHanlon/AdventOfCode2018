using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string line = "0";
            int total = 0;
            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    while (!String.IsNullOrWhiteSpace(line))
                    {
                        line = sr.ReadLine();
                        int val;
                        if (Int32.TryParse(line, out val))
                        {
                            total += val;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
                return;
            }
            
            Console.WriteLine($"Answer is {total}");
        }
    }
}
