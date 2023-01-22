using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for(int i=0;i<n;i++)
            {
                string[] input = Console.ReadLine().Split(' ',6);
                var engine = new Engine();
                var cargo = new Cargo();
                var tires = new List<Tires>();
                string model = input[0];
                engine.Speed = int.Parse(input[1]);
                engine.Power = int.Parse(input[2]);
                cargo.Weight = int.Parse(input[3]);
                cargo.Type = input[4];
                var splitTires = input[5].Split();
                for (int j = 0; j < splitTires.Length; j += 2)
                {
                    var tire = new Tires();
                    tire.Pressure = double.Parse(splitTires[j]);
                    tire.Age = int.Parse(splitTires[j + 1]);
                    tires.Add(tire);
                }
                var car = new Car(model, tires.ToArray(), engine, cargo);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            if(command=="fragile")
            {
                foreach (var car in cars)
                {
                    string temp = string.Empty;
                    foreach (var tire in car.Tires)
                    {

                        if (tire.Pressure < 1 && car.Model != temp)
                        {
                            temp = car.Model;
                            Console.WriteLine($"{car.Model}");
                        }
                    }

                }
            }
            else
            {
                foreach (var car in cars)
                {
                    if(car.Engine.Power>250)
                    {
                        Console.WriteLine($"{car.Model}");
                    }

                }
            }
        }
    }
}
