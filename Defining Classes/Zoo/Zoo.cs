using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;
        public List<Animal> Animals => this.animals;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Zoo(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.animals = new List<Animal>();
        }
        public string AddAnimal(Animal animal)
        {
            if(string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if(animal.Diet!= "herbivore" && animal.Diet!= "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if(this.animals.Count==Capacity)
            {
                return "The zoo is full.";
            }
            else
            {
                this.animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }
        public int RemoveAnimals(string species)
        {
            int removedCounter = 0;
            while(this.animals.FirstOrDefault(x=>x.Species==species)!=null)
            {
                var seachedAnimal = this.animals.FirstOrDefault(x => x.Species == species);
                this.animals.Remove(seachedAnimal);
                removedCounter++;
            }
            return removedCounter;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var searchedAnimals = this.animals.Where(x => x.Diet == diet).ToList();
            return searchedAnimals;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            var seachedAnimal = this.animals.FirstOrDefault(x => x.Weight == weight);
            return seachedAnimal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var seachedAnimals = this.animals.Where(x => x.Length >= minimumLength && x.Length <= maximumLength).ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append($"There are {seachedAnimals.Count} animals with a length between {minimumLength} and {maximumLength} meters.");
            return sb.ToString();
        }
    }
}
