using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;
        public List<Renovator> Renovators => this.renovators;
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public Catalog(string name,int neededRenovators,string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }
        public int Count => this.renovators.Count;
        public string AddRenovator (Renovator renovator)
        {
            if(renovator.Name==null || renovator.Type==null)
            {
                return "Invalid renovator's information.";
            }
            else if(this.Count==this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if(renovator.Rate>350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }
        public bool RemoveRenovator(string name)
        {
            var seachedRenovator = this.renovators.FirstOrDefault(x => x.Name == name);
            if(seachedRenovator!=null)
            {
                this.renovators.Remove(seachedRenovator);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int countRemoved = 0;
            while(this.renovators.FirstOrDefault(x=>x.Type==type)!=null)
            {
                var seachedRenovator = this.renovators.FirstOrDefault(x => x.Type == type);
                countRemoved++;
                this.renovators.Remove(seachedRenovator);
            }
            return countRemoved;
        }
        public Renovator HireRenovator(string name)
        {
            var seachedRenovator = this.renovators.FirstOrDefault(x => x.Name == name);
            if(seachedRenovator!=null)
            {
                seachedRenovator.Hired = true;
                return seachedRenovator;
            }
            else
            {
                return null;
            }
        }
        public List<Renovator> PayRenovators(int days)
        {
            var payedRenovators = this.renovators.Where(x => x.Days >= days).ToList();
            return payedRenovators;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach(var renovator in this.renovators.Where(x=>x.Hired!=true))
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
