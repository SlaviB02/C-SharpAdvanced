using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                var car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }
            while(true)
            {
                string[] input = Console.ReadLine().Split();
                if(input[0]=="End")
                {
                    break;
                }
                string model = input[1];
                double km = double.Parse(input[2]);
                var car = cars.Where(c => c.Model ==model).ToList().First();
                car.CanDistance(km);
            }
            foreach(var car in cars)
            {
                Console.WriteLine($"{ car.Model} { car.FuelAmount:F2} {car.TraveledDistance}");
            }
        }
    }
}
