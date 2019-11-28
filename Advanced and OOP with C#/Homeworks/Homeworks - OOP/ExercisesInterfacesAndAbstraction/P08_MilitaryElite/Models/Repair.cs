using P08_MilitaryElite.Contracts;
using P08_MilitaryElite.Enums;

namespace P08_MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int workedHours)
        {
            this.PartName = partName;
            this.WorkedHours = workedHours;
        }
        public string PartName { get; private set; }

        public int WorkedHours { get; private set; }
    }
}
