using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var listOfPeople = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                var member = new Person(int.Parse(input[1]), input[0]);

                listOfPeople.Add(member);
            } 

            if (listOfPeople.Count > 0)
            {
                Func<Person, bool> filter = c => c.Age > 30;
                var olderPeople = listOfPeople.OrderBy(n=>n.Name).Where(filter).ToList();
                if(olderPeople.Count>0)
                {
                    foreach(var person in olderPeople)
                    {
                        Console.WriteLine($"{person.Name} - {person.Age}");
                    }
                }
            }
            
        }
    }
}
