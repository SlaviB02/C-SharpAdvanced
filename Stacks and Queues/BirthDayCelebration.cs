using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(" ").Select(n => int.Parse(n)));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(" ").Select(n => int.Parse(n)));
            
            int wastedFood = 0;
            while (plates.Count > 0)
            
   {
                if (plates.Count == 0 || guests.Count == 0)
                {
                    break;
                }
                int plate = plates.Peek();
                int guest = guests.Peek();
                if(guest-plate<=0)
                {
                    guests.Dequeue();
                    plates.Pop();
                    wastedFood +=plate-guest;
                }
                else if(guest-plate>0)
                {
                    int value = guest - plate;
                    while (value>0)
                    {      
                        plates.Pop();
                        plate = plates.Peek();
                        value -= plate;
                    }
                    guests.Dequeue();
                    wastedFood -= value;
                    plates.Pop();
                }
               

            }
            if(plates.Count==0)
            {
                Console.Write($"Guests: ");
                Console.WriteLine(string.Join(" ",guests));
            }
            else if(guests.Count==0)
            {
                Console.Write("Plates: ");
                Console.WriteLine(string.Join(" ", plates));
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
