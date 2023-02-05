using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        public List<Fish> Fish { get; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public Net(string material,int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }
        public int Count 
        {
            get { return this.Fish.Count; }
        }
        public string AddFish(Fish fish)
        {
            if(fish.FishType==null || fish.Weight<=0 || fish.Length<=0)
            {
                return "Invalid fish.";
            }
            else if(Capacity==Count)
            {
                return "Fishing net is full.";
            }
            else
            {
                this.Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }
        public bool ReleaseFish(double weight)
        {
            var seachedFish = this.Fish.FirstOrDefault(x => x.Weight == weight);
            if(seachedFish!=null)
            {
                this.Fish.Remove(seachedFish);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Fish GetFish(string fishType)
        {
            var seachedFish = this.Fish.FirstOrDefault(x => x.FishType==fishType);
            return seachedFish;
        }
        public Fish GetBiggestFish()
        {
            var LongestFishes = this.Fish.OrderByDescending(x => x.Length).ToList();
            return LongestFishes[0];
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            foreach(var fish in this.Fish.OrderByDescending(x=>x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
