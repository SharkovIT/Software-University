using System;

namespace P04_Telephony.Exeptions
{
    public class InvalidPhoneNumberExeption : Exception
    {
        private const string EXC_MESSAGE = "Invalid number!";
        public InvalidPhoneNumberExeption()
            : base(EXC_MESSAGE)
        {
        }
    }
}
