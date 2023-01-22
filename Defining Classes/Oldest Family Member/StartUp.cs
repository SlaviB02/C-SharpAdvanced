using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                var member = new Person(int.Parse(input[1]), input[0]);

                family.AddMember(member);
            } 

            if (family.People.Count > 0)
            {
              var oldest=family.GetOldestMember();
                Console.WriteLine($"{oldest.Name} {oldest.Age}");
            }
            
        }
    }
}
