using P07_FoodShortage.Contracts;
using P07_FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            HashSet<IBuyer> persons = new HashSet<IBuyer>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    Rebel rebel = rebel = new Rebel(name, age, group);

                    persons.Add(rebel);
                }
                else if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    Citizen citizen = citizen = new Citizen(name, age, id, birthdate);

                    persons.Add(citizen);
                }
            }

            string names = Console.ReadLine();

            while (names != "End")
            {
                var targetPerson = persons.FirstOrDefault(x => x.Name == names);

                if (targetPerson != null)
                {
                    targetPerson.BuyFood();
                }

                names = Console.ReadLine();
            }

            var result = persons.Select(x => x.Food).Sum();

            Console.WriteLine(result);
        }
    }
}
