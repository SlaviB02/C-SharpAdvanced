using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Func<string, int, bool> filter = (a, b) => a.Sum(n => n) >= b;
            Func<Func<string, int, bool>, List<string>, string> returnFirst = (a, b) => b.FirstOrDefault(s => a(s, N));
            string result = returnFirst(filter, names);
            if(result!=string.Empty)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(string.Empty);
            }
        }
    }
}
          

