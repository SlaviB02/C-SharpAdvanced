using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp45
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new Stack<int>();
            Queue<int> drinks = new Queue<int>();
            int dailyCaff = 0;
            int[] caff = Console.ReadLine().Split(", ").Select(n=>int.Parse(n)).ToArray();
            int[] drink = Console.ReadLine().Split(", ").Select(n=>int.Parse(n)).ToArray();
            for(int i=0;i<caff.Length;i++)
            {
                caffeine.Push(caff[i]);
            }
            for (int i = 0; i < drink.Length; i++)
            {
                drinks.Enqueue(drink[i]);
            }
            while(caffeine.Count>0)
            {
                if(caffeine.Count==0)
                {
                    break;
                }
                if(drinks.Count==0)
                {
                    break;
                }
                int c = caffeine.Peek();
                int d = drinks.Peek();
                if(c*d+dailyCaff>300)
                {
                    caffeine.Pop();
                    drinks.Enqueue(drinks.Dequeue());
                    if(dailyCaff<30)
                    {
                        dailyCaff = 0;
                    }
                    else
                    {
                        dailyCaff -= 30;
                    }
                }
                else
                {
                    dailyCaff += c * d;
                    caffeine.Pop();
                    drinks.Dequeue();
                }
            }
            if(drinks.Count>0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {dailyCaff} mg caffeine.");
        }
    }
}
