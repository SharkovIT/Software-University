using P08_MilitaryElite.Contracts;
using P08_MilitaryElite.Enums;
using P08_MilitaryElite.Exeptions;
using System;

namespace P08_MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new IvalidCorpsExeption();
            }

            this.Corps = corps;
        }
    }
}
