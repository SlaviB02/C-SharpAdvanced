using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }
        public Family()
        {
            this.People = new List<Person>();
        }
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            var oldestPerson = people.OrderByDescending(x=> x.Age).FirstOrDefault();

            return oldestPerson;
        }
    }
}
