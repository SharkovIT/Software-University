namespace P03_Ferrari
{
    public class Ferrari : ICar
    {
        private const string model = "488-Spider";
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }
        public string Driver { get;private set; }

        public string PushTheGas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{model}/{this.UseBreaks()}/{this.PushTheGas()}/{this.Driver}";
        }

        public string UseBreaks()
        {
            return "Brakes!";
        }
    }
}
