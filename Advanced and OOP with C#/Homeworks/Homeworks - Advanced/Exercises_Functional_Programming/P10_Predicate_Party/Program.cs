using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestNames = Console.ReadLine()
                .Split()
                .ToList();

            string input = Console.ReadLine();

            Func<string, string, bool> startsWithFilter = (name, param) => name.StartsWith(param);
            Func<string, string, bool> endsWithFilter = (name, param) => name.EndsWith(param);
            Func<string, int, bool> lengthFilter = (name, param) => name.Length == param;

            while (input != "Party!")
            {
                string[] guestInfo = input.Split();

                string command = guestInfo[0];
                string filterInfo = $"{guestInfo[1]} {guestInfo[2]}";

                string[] splittedFilterInfo = filterInfo.Split();
                string filter = splittedFilterInfo[0];
                string criteria = splittedFilterInfo[1];

                if (command == "Remove")
                {
                    if (filter == "StartsWith")
                    {
                        guestNames = guestNames.Where(x => !startsWithFilter(x, criteria)).ToList();
                    }
                    else if (filter == "EndsWith")
                    {
                        guestNames = guestNames.Where(x => !endsWithFilter(x, criteria)).ToList();
                    }
                    else if (filter == "Length")
                    {
                        int length = int.Parse(criteria);

                        guestNames = guestNames.Where(x => !lengthFilter(x, length)).ToList();
                    }
                }
                else
                {
                    if (filter == "StartsWith")
                    {
                        var name = guestNames.Where(x => startsWithFilter(x, criteria)).ToList();
                        guestNames.InsertRange(0, name);
                    }
                    else if (filter == "EndsWith")
                    {
                        var name = guestNames.Where(x => endsWithFilter(x, criteria)).ToList();
                        guestNames.InsertRange(0, name);
                    }
                    else if (filter == "Length")
                    {
                        int length = int.Parse(criteria);

                       var name = guestNames.Where(x => lengthFilter(x, length)).ToList();
                        guestNames.InsertRange(0, name);
                    }
                }

                input = Console.ReadLine();
            }
            if (guestNames.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            { 
            Console.WriteLine($"{string.Join(", ", guestNames)} are going to the party!");
        }}
    }
}
