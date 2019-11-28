using P04_Telephony.Exeptions;
using P04_Telephony.Model;
using System;
using System.Linq;

namespace P04_Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(phoneNumber));
                }
                catch (InvalidPhoneNumberExeption ipne)
                {
                    Console.WriteLine(ipne.Message);
                }
            }

            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(site));

                }
                catch (InvalidUrlExeption iue)
                {
                    Console.WriteLine(iue.Message);
                }
            }
        }
    }
}
