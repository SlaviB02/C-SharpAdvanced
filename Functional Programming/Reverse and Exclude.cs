using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x.Reverse()));
            Predicate<int> filter = s => s % n!=0;
            Func<int, bool> divisible = f => filter(f);
            numbers = numbers.Where(divisible).ToArray();
            print(numbers);

        }
    }
}
