using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        
            private int count;
            public int Count { get { return this.count; } }
            private List<T> list;
            public Box()
            {
                list = new List<T>();
            }
            public void Add(T element)
            {
                count++;
                list.Add(element);
            }
            public T Remove()
            {
                count--;
                T elementToRemove = list[list.Count - 1];
                list.Remove(elementToRemove);
                return elementToRemove;
            }
        
    }
}
