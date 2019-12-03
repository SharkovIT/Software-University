using P04_Telephony.Contracts;
using P04_Telephony.Exeptions;
using System.Linq;

namespace P04_Telephony.Model
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidUrlExeption();
            }

            return "Browsing: " + url + "!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberExeption();
            }

            return "Calling... " + phoneNumber;
        }
    }
}
