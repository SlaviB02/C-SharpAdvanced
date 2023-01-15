using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> elements = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                string[] input = Console.ReadLine().Split();
                for(int j=0;j<input.Length;j++)
                {
                    elements.Add(input[j]);
                }
            }
            elements = elements.OrderBy(n => n).ToHashSet();
            if(elements.Count>0)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
        }
    }
}
