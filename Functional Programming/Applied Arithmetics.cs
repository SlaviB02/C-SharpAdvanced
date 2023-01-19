using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp39
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));
            Func<List<int>, List<int>> subtract = x => x.Select(x => x - 1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(x => x*2).ToList();
            Func<List<int>, List<int>> add = x => x.Select(x => x+1).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if(command=="end")
                {
                    break;
                }
                if(command=="add")
                {
                    numbers = add(numbers);
                }
                if(command=="subtract")
                {
                    numbers=subtract(numbers);
                }
                if(command=="multiply")
                {
                   numbers=multiply(numbers);
                }
                if(command=="print")
                {
                    print(numbers);
                }

            }
        }
    }
}
