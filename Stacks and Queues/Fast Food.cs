using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
                Console.WriteLine(queue.Max());
            while(queue.Count>0)
            {
                int order = queue.Peek();
                if(food<order)
                {
                    Console.Write($"Orders left: ");
                    Console.Write(string.Join(" ", queue));
                    return;
                }
                else
                {
                    queue.Dequeue();
                    food -= order;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
