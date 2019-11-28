using P08_MilitaryElite.Contracts;
using System.Collections.Generic;

namespace P08_MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<IPrivate> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => this.privates;
        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }
    }
}
