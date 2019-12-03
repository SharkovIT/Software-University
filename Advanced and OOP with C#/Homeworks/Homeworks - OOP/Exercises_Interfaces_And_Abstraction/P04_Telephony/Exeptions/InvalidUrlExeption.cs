using System;

namespace P04_Telephony.Exeptions
{
    public class InvalidUrlExeption : Exception
    {
        private const string EXC_MESSAGE = "Invalid URL!";
        public InvalidUrlExeption()
            : base(EXC_MESSAGE)
        {
        }
    }
}
