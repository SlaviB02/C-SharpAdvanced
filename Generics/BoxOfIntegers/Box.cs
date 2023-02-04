using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box<T>
    {
        public T input { get; set; }
        public override string ToString()
        {
            Type type = input.GetType();
            return $"{type}: {this.input}";
        }
    }
}
