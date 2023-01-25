using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new Queue<int>();
            Stack<int> milk = new Stack<int>();
            Dictionary<string, int> resultDrinks = new Dictionary<string, int>();
            Dictionary<string, int> drinks = new Dictionary<string, int>()
            {
                {"Cortado", 50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 },
            };
            int[] coff = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] milkInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            for(int i=0;i<coff.Length;i++)
            {
                coffee.Enqueue(coff[i]);
            }
            for(int i=0;i<milkInput.Length;i++)
            {
                milk.Push(milkInput[i]);
            }
            while(coffee.Count>0)
            {
                if(coffee.Count==0)
                {
                    break;
                }
                if(milk.Count==0)
                {
                    break;
                }
                int c = coffee.Peek();
                int m = milk.Peek();
                int drink = c + m;
                if(drinks.ContainsValue(drink)==true)
                {
                    string endItem = "";
                    foreach(var item in drinks)
                    {
                        if(item.Value==drink)
                        {
                            endItem = item.Key;
                        }
                    }
                    if(resultDrinks.ContainsKey(endItem)==true)
                    {
                        resultDrinks[endItem]++;
                    }
                    else
                    {
                        resultDrinks.Add(endItem, 1);
                    }
                    coffee.Dequeue();
                    milk.Pop();
                }
                else
                {
                    coffee.Dequeue();
                    m -= 5;
                    milk.Pop();
                    milk.Push(m);
                }
            }
            if(milk.Count==0 && coffee.Count==0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            if(coffee.Count==0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ",coffee)}");
            }
            if(milk.Count==0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }

            if(resultDrinks.Count>0)
            {
                var result = resultDrinks.OrderBy(n => n.Value).ThenByDescending(n => n.Key);
                foreach (var drink in result)
                {
                    Console.WriteLine($"{drink.Key}: {drink.Value}");
                }

            }
        }
    }
}
