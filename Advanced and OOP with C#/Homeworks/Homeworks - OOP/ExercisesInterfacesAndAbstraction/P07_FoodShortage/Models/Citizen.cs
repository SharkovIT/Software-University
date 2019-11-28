using P07_FoodShortage.Contracts;

namespace P07_FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public int Food { get; private set; } = 0;

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }
        public string Birthdate { get; private set; }

        public int BuyFood()
        {
            return this.Food += 10;
        }
    }
}
