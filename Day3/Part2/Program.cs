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
            Dictionary<Tuple<int,int>, List<int>> grid = new Dictionary<Tuple<int, int>, List<int>>();
            List<int> overlappingIds = new List<int>();

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
                                    grid[new Tuple<int, int>(x,y)].Add(shape.id);
                                    foreach(int id in grid[new Tuple<int,int>(x,y)])
                                    {
                                        if (!overlappingIds.Contains(id))
                                        {
                                            overlappingIds.Add(id);
                                        }
                                    }
                                }
                                else
                                {
                                    grid.Add(new Tuple<int, int>(x,y), new List<int>{shape.id});
                                }
                            }
                        }
                    }

                    // Now find the Id that is *not* in the list of overlapping Ids
                    int answer = 0;
                    for (int id = 1; id <= 1227; id++)
                    {
                        if (!overlappingIds.Contains(id))
                        {
                            answer = id;                        
                            break;
                        }
                    }
                    Console.WriteLine($"Answer is {answer}");
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
