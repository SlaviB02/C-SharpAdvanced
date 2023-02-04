using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> box = new List<string>();
            for(int i=0;i<n;i++)
            {
                string input =Console.ReadLine();
                box.Add(input);  
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(box, indexes[0], indexes[1]);
            foreach(var thing in box)
            {
                Type type = thing.GetType();
                Console.WriteLine($"{type}: {thing}");
            }

        }
        public static void Swap<T>(List<T>list,int a,int b)
        {
            T swap = list[a];
            list[a] = list[b];
            list[b] = swap;
        }
    }
}
