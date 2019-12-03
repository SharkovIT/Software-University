using System;

namespace P08_MilitaryElite.Exeptions
{
    public class InvalidMissionCompletionExeption : Exception
    {
        private const string EXC_MESSAGE = "Already finished the mission!";

        public InvalidMissionCompletionExeption()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidMissionCompletionExeption(string message) : base(message)
        {
        }
    }
}
