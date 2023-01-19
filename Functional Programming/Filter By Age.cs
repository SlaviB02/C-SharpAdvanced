using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp38
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();
            for(int i=0;i<N;i++)
            {
                string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                people.Add(name, age);
            }
            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<int, bool> filter = CreateFilter(condition, ageThreshold);
            Action<KeyValuePair<string,int>> printer = CreatePrinter(format);
            PrintFilteredPeople(people, filter, printer);
        }
        public static Func<int, bool> CreateFilter(string condition, int ageThreshold)
        {
            switch (condition)
            {
                case "younger": return x => x < ageThreshold;
                case "older": return x => x >= ageThreshold;
                default: throw new ArgumentException(condition);
            }
        }
        public static Action<KeyValuePair<string,int>>CreatePrinter(string format)
        {
            switch(format)
            {
                case "name age":
                    return kvp => Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                case "name":
                    return kvp => Console.WriteLine($"{kvp.Key}");
                case "age":
                    return kvp => Console.WriteLine($"{kvp.Value}");
                default:
                    return null;
            }
        }
        private static void PrintFilteredPeople(
           Dictionary<string, int> people,
           Func<int, bool> tester,
           Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }
    }
    

}
