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
            Console.WriteLine("Hello World!");
            int total = 0;      
            int fileLoops = 0;  
            int? result = null;
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            dict.Add(total, true);

            try
            {                
                while (result is null)
                {
                    fileLoops++;
                    using (StreamReader sr = new StreamReader("input.txt"))
                    {
                        string line = "0";
                        while (!String.IsNullOrWhiteSpace(line))
                        {
                            line = sr.ReadLine();
                            int val;
                            if (Int32.TryParse(line, out val))
                            {
                                total += val;
                                if (dict.ContainsKey(total))
                                {
                                    result = total;
                                    break;
                                }
                                else
                                {
                                    dict.Add(total, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
                return;
            }
            
            Console.WriteLine($"Answer is {result}, after {fileLoops} loops");            
        }
    }
}
