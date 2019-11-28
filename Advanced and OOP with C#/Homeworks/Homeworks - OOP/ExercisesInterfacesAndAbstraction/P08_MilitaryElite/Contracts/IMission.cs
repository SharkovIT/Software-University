using P08_MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
