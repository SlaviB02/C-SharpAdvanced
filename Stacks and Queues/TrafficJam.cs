using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int number = int.Parse(Console.ReadLine());
            int count = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if(input=="end")
                {
                    Console.WriteLine($"{count} cars passed the crossroads.");
                    break;
                }
                else if(input=="green")
                {
                    if(number>=queue.Count)
                    {
                        while (queue.Count > 0)
                        {
                            string car = queue.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            count++;
                        }
                    }
                    else
                    {
                        for(int i=0;i<number;i++)
                        {
                            string car = queue.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }


        }
    }
}
