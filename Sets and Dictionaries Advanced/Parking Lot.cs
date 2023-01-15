using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp32
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            while(true)
            {
                string[] input = Console.ReadLine().Split(", ");
                string direction = input[0];
                if(direction=="END")
                {
                    break;
                }
                string carNumber = input[1];
                if(direction=="IN")
                {
                    cars.Add(carNumber);
                }
                if(direction=="OUT")
                {
                    cars.Remove(carNumber);
                }
            }
            if(cars.Count>0)
            {
                foreach(var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
