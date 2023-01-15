using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for(int i=0;i<nums.Length;i++)
            {
                if(numbers.ContainsKey(nums[i])==true)
                {
                    numbers[nums[i]]++;
                }
                else
                {
                    numbers.Add(nums[i], 1);
                }
            }
            foreach(var num in numbers)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
