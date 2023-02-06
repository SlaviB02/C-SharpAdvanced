using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        public List<Drone> Drones => this.drones;
        public int Count => this.drones.Count;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public Airfield(string name,int capacity,double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }
        public string AddDrone(Drone drone)
        {
            if(drone.Name==null || drone.Brand==null || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if(this.Capacity==Count)
            {
                return "Airfield is full.";
            }
            else
            {
                this.Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }
        public bool RemoveDrone(string name)
        {
            var seachedDrone = this.drones.FirstOrDefault(x => x.Name == name);
            if(seachedDrone!=null)
            {
                this.drones.Remove(seachedDrone);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RemoveDroneByBrand(string brand)
        {
            int removedDrones = 0;
            while(this.drones.FirstOrDefault(x=>x.Brand==brand)!=null)
            {
                var droneToRemove = this.drones.FirstOrDefault(x => x.Brand == brand);
                this.drones.Remove(droneToRemove);
                removedDrones++;
            }
            return removedDrones;
        }
        public Drone FlyDrone(string name)
        {
            var seachedDrone = this.drones.FirstOrDefault(x => x.Name == name);
            if(seachedDrone!=null)
            {
                seachedDrone.Available = false;
                return seachedDrone;
            }
            else
            {
                return null;
            }
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flownDrones = this.drones.Where(x => x.Range >= range).ToList();
            foreach(var drone in flownDrones)
            {
                drone.Available = false;
            }
            return flownDrones;
           
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach(var drone in this.drones.Where(x=>x.Available==true))
            {
                sb.AppendLine(drone.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
