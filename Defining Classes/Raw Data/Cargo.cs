using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Cargo
    {
        private string type;
        private int weight;
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
    }
}
