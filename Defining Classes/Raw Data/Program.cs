using System;

namespace DefiningClasses
{
   public class Car
    {
        private string model;
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        private Tires[] tires;
        public Tires[]Tires
        {
            get { return this.tires; }
            set { 
                if(value.Length==4)
                {
                    this.tires = value;
                }
            }
        }
        private Engine engine;
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        private Cargo cargo;
        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }
        public Car(string model,Tires[]tires,Engine engine,Cargo cargo)
        {
            this.Model = model;
            this.Tires = tires;
            this.Engine = engine;
            this.Cargo = cargo;
        }
    }
}
