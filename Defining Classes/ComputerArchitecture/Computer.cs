using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ComputerArchitecture
{
    public class Computer
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        private List<CPU> multiprocessor { get; set; }
        public Computer(string model,int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.multiprocessor = new List<CPU>();
        }
        public int Count => this.Multiprocessor.Count;
        public List<CPU> Multiprocessor => this.multiprocessor;
        public void Add(CPU cpu)
        {
            if(this.Count<this.Capacity)
            {
                multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            var cpuToRemove = this.multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if(cpuToRemove!=default)
            {
                multiprocessor.Remove(cpuToRemove);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public CPU MostPowerful()
        {
            return this.multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();
        }
        public CPU GetCPU(string brand)
        {
            var cpuToReturn=this.multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (cpuToReturn != default)
            {
                return cpuToReturn;
            }
            else return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {this.Model}:");
            foreach(var cpu in this.multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
