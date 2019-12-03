using P07_FoodShortage.Contracts;

namespace P07_FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Group { get; private set; }
        public int Food { get; private set; } = 0;

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int BuyFood()
        {
            return this.Food += 5;
        }
    }
}
