using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    public struct Shape
    {
        public int id;
        public int x;
        public int y;
        public int width;
        public int height;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string line;
            Dictionary<Tuple<int,int>, int> grid = new Dictionary<Tuple<int, int>, int>();

            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    while (!String.IsNullOrWhiteSpace(line = sr.ReadLine()))
                    {                        
                        Shape shape = ParseLine(line);
                        for (int x = shape.x; x < shape.x + shape.width; x++)
                        {
                            for (int y = shape.y; y < shape.y + shape.height; y++)
                            {
                                if (grid.ContainsKey(new Tuple<int, int>(x, y)))
                                {
                                    grid[new Tuple<int, int>(x,y)] = grid[new Tuple<int,int>(x,y)] + 1;
                                }
                                else
                                {
                                    grid.Add(new Tuple<int, int>(x,y), 1);
                                }
                            }
                        }
                    }

                    // Now count all the entries that are > 1
                    Console.WriteLine($"Answer is {grid.Values.ToArray().Count(g => g > 1)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
                return;
            }
        }

        private static Shape ParseLine(string line)
        {
            Shape shape = new Shape();
            string idStr = line.Substring(1).Split(' ')[0];
            Int32.TryParse(idStr, out shape.id);

            string xStr = line.Split('@')[1].Split(',')[0];
            Int32.TryParse(xStr, out shape.x);
            string yStr = line.Split(',')[1].Split(':')[0];
            Int32.TryParse(yStr, out shape.y);

            string widthStr = line.Split(':')[1].Split('x')[0].Substring(1);
            Int32.TryParse(widthStr, out shape.width);
            string heightStr = line.Split('x')[1];
            Int32.TryParse(heightStr, out shape.height);

            return shape;
        }
    }
}
