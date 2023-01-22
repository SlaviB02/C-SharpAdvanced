using System;
using System.Collections.Generic;

namespace DefiningClasses
{
   public class Trainer
    {
        private string name;
        private int numberOfBadges;
       
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int NumberOfBadges
        {
            get { return this.numberOfBadges; }
            set { this.numberOfBadges = value; }
        }
       
        public Trainer()
        {
            this.NumberOfBadges = 0;
        }
        public List<Pokemon> collectionPokemon = new List<Pokemon>();
    }
}
