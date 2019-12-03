using System;

namespace P08_MilitaryElite.Exeptions
{
    public class IvalidCorpsExeption : Exception
    {
        private const string EXC_MESSAGE = "Invalid corps!";

        public IvalidCorpsExeption()
            : base(EXC_MESSAGE)
        {
        }

        public IvalidCorpsExeption(string message) : base(message)
        {
        }
    }
}
