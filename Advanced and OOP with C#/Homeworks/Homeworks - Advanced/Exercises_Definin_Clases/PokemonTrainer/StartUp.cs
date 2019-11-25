using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var trainers = new List<Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] splittedInput = input.Split();

                AddTrainerWithPokemon(trainers, splittedInput);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                CheckElement(input, trainers);

                input = Console.ReadLine();
            }

            Print(trainers);
        }

        private static void Print(List<Trainer> trainers)
        {
            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }

        private static void CheckElement(string element, List<Trainer> trainers)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == element))
                {
                    trainer.NumberOfBadges += 1;
                }
                else
                {
                    foreach (var trainerPokemon in trainer.Pokemons)
                    {
                        trainerPokemon.Health -= 10;
                    }
                }
            }

            foreach (var trainer in trainers)
            {
                trainer.Pokemons.RemoveAll(x => x.Health <= 0);
            }
        }

        private static void AddTrainerWithPokemon(List<Trainer> trainers, string[] splittedInput)
        {
            string trainerName = splittedInput[0];
            string pokemonName = splittedInput[1];
            string pokemonElement = splittedInput[2];
            int pokemonHealth = int.Parse(splittedInput[3]);

            Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

            if (trainer == null)
            {
                trainer = new Trainer(trainerName);
                trainers.Add(trainer); 
            }

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            trainer.Pokemons.Add(pokemon);
        }
    }
}
