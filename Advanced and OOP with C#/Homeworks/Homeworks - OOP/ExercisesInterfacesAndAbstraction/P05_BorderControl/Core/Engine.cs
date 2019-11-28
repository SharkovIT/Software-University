using P05_BorderControl.Contracts;
using P05_BorderControl.Models;
using System;
using System.Collections.Generic;

namespace P05_BorderControl.Core
{
    public class Engine
    {
        private readonly List<IBirthdate> allBirthdates;

        public Engine()
        {
            this.allBirthdates = new List<IBirthdate>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splittedInput = input.Split();


                if (splittedInput[0] == "Citizen")
                {
                    string name = splittedInput[1];
                    int age = int.Parse(splittedInput[2]);
                    string id = splittedInput[3];
                    string birthdate = splittedInput[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    this.allBirthdates.Add(citizen);
                }
                else if (splittedInput[0] == "Pet")
                {
                    string name = splittedInput[1];
                    string birthdate = splittedInput[2];

                    Pet pet = new Pet(name, birthdate);
                    this.allBirthdates.Add(pet);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            foreach (var birthdate in this.allBirthdates)
            {
                bool endsWith = birthdate.Birthdate.EndsWith(input);

                if (endsWith)
                {
                    Console.WriteLine(birthdate.Birthdate);
                }
            }
        }
    }
}
