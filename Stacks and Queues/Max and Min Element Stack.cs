using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for(int i=0;i<N;i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if(command[0]==1)
                {
                    stack.Push(command[1]);
                }
                if(command[0]==2)
                {
                    stack.Pop();
                }
                if(command[0]==3)
                {
                    if(stack.Count>0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    
                }
                if(command[0]==4)
                {
                    if(stack.Count>0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                    
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
