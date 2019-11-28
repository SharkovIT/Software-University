using P03_WildFarm.Factories;
using System;
using System.Collections.Generic;

namespace P03_WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                Animal animal = AnimalFactory.Create(command.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                animals.Add(animal);
                Console.WriteLine(animal.ProduceSound());
                Food.Food food = FoodFactory.Create(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

                try
                {
                    animal.EatFood(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}
