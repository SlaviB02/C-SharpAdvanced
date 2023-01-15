using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            HashSet<int> final = new HashSet<int>();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = input[0];
            int M = input[1];
            for(int i=0;i<N;i++)
            {
                int number = int.Parse(Console.ReadLine());
                first.Add(number);
            }
            for (int i = 0; i < M; i++)
            {
                int number = int.Parse(Console.ReadLine());
                second.Add(number);
            }
            foreach(var num in first)
            {
                if(second.Contains(num)==true)
                {
                    final.Add(num);
                }
            }
            if(final.Count>0)
            {
                Console.WriteLine(string.Join(" ", final));
            }
            
        }
    }
}
