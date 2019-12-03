using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Contracts
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
