using System;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double traveledDistance;
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }
        }
        public double TraveledDistance
        {
            get { return this.traveledDistance; }
            set { this.traveledDistance = value; }
        }
        public Car(string model,double fuel,double perKm)
        {
            this.model = model;
            this.fuelAmount = fuel;
            this.fuelConsumptionPerKilometer = perKm;
            this.traveledDistance = 0;
        }
        public void CanDistance(double km)
        {
           if(this.fuelConsumptionPerKilometer*km>this.fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
           else
            {
                this.traveledDistance += km;
                this.fuelAmount -= this.fuelConsumptionPerKilometer * km;
            }
        }
    }
}
