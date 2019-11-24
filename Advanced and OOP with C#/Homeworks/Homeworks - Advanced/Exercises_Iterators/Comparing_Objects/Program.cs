using System;
using System.Collections.Generic;

namespace Comparing_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] splittedInput = input.Split();

                string name = splittedInput[0];
                int age = int.Parse(splittedInput[1]);
                string town = splittedInput[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());
            Person targedPerson = null;

            int matchPeople = 0;
            int dismatchPeople = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (n - 1 == i)
                {
                    targedPerson = people[i];
                }
            }

            foreach (var currentPerson in people)
            {
                if (currentPerson.CompareTo(targedPerson) == 0)
                {
                    matchPeople++;
                }
                else
                {
                    dismatchPeople++;
                }
            }

            if (matchPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matchPeople} {dismatchPeople} {people.Count}");
            }
        }
    }
}
