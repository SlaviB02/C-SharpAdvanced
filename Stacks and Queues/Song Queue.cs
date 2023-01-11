using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(songs);
            while(queue.Count>0)
            {
                string[] command = Console.ReadLine().Split();
                if(command[0]=="Play")
                {
                    queue.Dequeue();
                }
                if(command[0]=="Add")
                {
                    string []name = new string[command.Length - 1];
                    for(int i=0;i<name.Length;i++)
                    {
                        name[i] = command[i + 1];
                    }
                    string fullName = string.Join(" ", name);
                    if(queue.Contains(fullName)==true)
                    {
                        Console.WriteLine($"{fullName} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(fullName);
                    }

                }
                if(command[0]=="Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                if(queue.Count==0)
                {
                    Console.WriteLine("No more songs!");
                    return;
                }
            }
        }
    }
}
