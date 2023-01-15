using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                string[] colorAndClothes = Console.ReadLine().Split(" -> ");
                string color = colorAndClothes[0];
                string[] clothes = colorAndClothes[1].Split(",");
                if(wardrobe.ContainsKey(color))
                {
                    for (int j = 0; j < clothes.Length; j++)
                    {
                        if (wardrobe[color].ContainsKey(clothes[j]))
                        {
                            wardrobe[color][clothes[j]]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothes[j], 1);
                        }
                    }
                }
                else
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    for(int j=0;j<clothes.Length;j++)
                    {
                        if(wardrobe[color].ContainsKey(clothes[j]))
                        {
                            wardrobe[color][clothes[j]]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothes[j], 1);
                        }
                    }
                }
            }
            string[] seachedThing = Console.ReadLine().Split();
            string colour = seachedThing[0];
            string piece = seachedThing[1];
            foreach(var thing in wardrobe)
            {
                Console.WriteLine($"{thing.Key} clothes:");
                foreach(var cloth in thing.Value)
                {
                    if(cloth.Key==piece && thing.Key==colour)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
