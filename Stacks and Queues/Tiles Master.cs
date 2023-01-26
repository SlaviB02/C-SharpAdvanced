using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp47
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>();
            Queue<int> grayTiles = new Queue<int>();
            int[] whiteInput = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] grayInput = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < whiteInput.Length; i++)
            {
                whiteTiles.Push(whiteInput[i]);
            }
            for (int i = 0; i < grayInput.Length; i++)
            {
                grayTiles.Enqueue(grayInput[i]);
            }
            Dictionary<string, int> result = new Dictionary<string, int>();
            Dictionary<string, int> areas = new Dictionary<string, int>()
            {
                {"Sink", 40 },
                {"Oven", 50 },
                {"Countertop", 60 },
                {"Wall", 70 },
            };
            while(whiteTiles.Count>0)
            {
                if(!whiteTiles.Any() ||!grayTiles.Any())
                {
                    break;
                }
                int w = whiteTiles.Peek();
                int g = grayTiles.Peek();
                if(w==g)
                {
                    int tile = w + g;
                    string place = "";
                    if(areas.ContainsValue(tile))
                    {
                        foreach(var area in areas)
                        {
                            if(area.Value==tile)
                            {
                                place = area.Key;
                            }
                        }
                        
                    }
                    else
                    {
                        place = "Floor";
                    }
                    if (result.ContainsKey(place))
                    {
                        result[place]++;
                    }
                    else
                    {
                        result.Add(place, 1);
                    }
                    whiteTiles.Pop();
                    grayTiles.Dequeue();

                }
                else
                {
                    w /= 2;
                    whiteTiles.Pop();
                    whiteTiles.Push(w);
                    grayTiles.Enqueue(grayTiles.Dequeue());
                }

            }
            if(whiteTiles.Count==0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {String.Join(", ",whiteTiles)}");
            }
            if (grayTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {String.Join(", ", grayTiles)}");
            }
            var sortedDictionary = result.OrderByDescending(n => n.Value).ThenBy(n => n.Key);
            foreach(var item in sortedDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
