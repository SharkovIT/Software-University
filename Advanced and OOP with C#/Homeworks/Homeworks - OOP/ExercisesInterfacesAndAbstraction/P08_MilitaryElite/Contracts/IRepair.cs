﻿namespace P08_MilitaryElite.Contracts
{
    public interface IRepair
    {
        string PartName { get; }

        int WorkedHours { get; }
    }
}
