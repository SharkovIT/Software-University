using System;

namespace P08_MilitaryElite.Exeptions
{
    public class InvalidStateExeption : Exception
    {
        private const string EXC_MESSAGE = "Invalid state!";
        public InvalidStateExeption()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidStateExeption(string message) : base(message)
        {
        }
    }
}
