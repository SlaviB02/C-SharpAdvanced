using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> cities = new Dictionary<string, Dictionary<string, List<string>>>();
            int N = int.Parse(Console.ReadLine());
            for(int i=0;i<N;i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                if(!cities.ContainsKey(continent))
                {
                    cities[continent] = new Dictionary<string, List<string>>();
                }
                if(!cities[continent].ContainsKey(country))
                {
                    cities[continent][country] = new List<string>();
                }
                cities[continent][country].Add(city);

            }
            foreach(var (continentName,countries) in cities)
            {
                Console.WriteLine($"{continentName}:");
                foreach(var (countryName,city) in countries)
                {
                    Console.Write($"  {countryName} -> ");
                    
                        Console.WriteLine(string.Join(", ",city));
                    
                }
            }
           
        }
    }
}
