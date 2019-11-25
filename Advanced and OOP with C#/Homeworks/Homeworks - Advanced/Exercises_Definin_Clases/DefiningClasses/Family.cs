using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family : Person
    {
        List<Person> listOfPeople = new List<Person>();

        public void AddMember(Person member)
        {
            listOfPeople.Add(new Person(member.Age, member.Name));
        }

        public Person GetOldestMember()
        {
            int getOldest = int.MinValue;
            string name = string.Empty;

            foreach (var person in listOfPeople)
            {
                if (person.Age > getOldest)
                {
                    getOldest = person.Age;
                    name = person.Name;
                }
            }

            return new Person(getOldest, name);
        }

        public void PrintPeople()
        {
            foreach (var people in listOfPeople.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{people.Name} - {people.Age}");
            }
        }
    }
}
