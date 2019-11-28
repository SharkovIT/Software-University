using P05_BorderControl.Contracts;

namespace P05_BorderControl.Models
{
    public class Robot : IIdentifier
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
