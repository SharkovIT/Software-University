using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private const int DefaultBadges = 0;

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = DefaultBadges;
            this.Pokemons = new List<Pokemon>();
        }
    }
}
