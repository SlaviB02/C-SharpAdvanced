using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp29
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();
            int N = int.Parse(Console.ReadLine());
            for(int i=0;i<N;i++)
            {
                string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = Convert.ToDecimal(input[1]);
                if(grades.ContainsKey(name)==true)
                {
                    grades[name].Add(grade);
                }
                else
                {
                    grades.Add(name, new List<decimal>() { grade });
                }
            }
            foreach(var person in grades)
            {
                Console.Write($"{person.Key} -> ");
                    for(int i=0;i<person.Value.Count;i++)
                {
                    Console.Write($"{person.Value[i]:F2}" + " ");
                }
                Console.WriteLine($"(avg: {person.Value.Average():F2})");
            }
        }
    }
}
