namespace P07_FoodShortage.Contracts
{
    public interface IBuyer
    {
        string Name { get; }
        int Food { get; }

        int BuyFood();
    }
}
