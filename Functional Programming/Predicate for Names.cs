using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Action<List<string>> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            Predicate<string> filter = s => s.Length<=n;
            Func<string, bool> filterNames = s => filter(s);
            names = names.Where(filterNames).ToList();
            print(names);

        }
    }
}
