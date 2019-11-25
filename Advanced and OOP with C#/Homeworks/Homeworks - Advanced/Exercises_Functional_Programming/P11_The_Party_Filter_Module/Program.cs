using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_The_Party_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine()
                .Split();

            string input = Console.ReadLine();

            List<string> filterList = new List<string>();

            while (input != "Print")
            {
                string[] filters = input.Split(";");

                string command = filters[0];
                string filter = $"{filters[1]};{filters[2]}";

                if (command == "Add filter")
                {
                    filterList.Add(filter);
                }
                else
                {
                    filterList.Remove(filter);
                }

                input = Console.ReadLine();
            }

            Func<string, string, bool> startsWithFilter = (name, charName) => name.StartsWith(charName);
            Func<string, string, bool> endsWithFilter = (name, charName) => name.EndsWith(charName);
            Func<string, int, bool> lengthFilter = (name, length) => name.Length == length;
            Func<string, string, bool> containsFilter = (name, containsName) => name.Contains(containsName);

            foreach (var filter in filterList)
            {
                string[] filterInfo = filter.Split(";");

                string action = filterInfo[0];
                string param = filterInfo[1];

                if (action == "Starts with")
                {
                    inputNames = inputNames.Where(x => !startsWithFilter(x, param)).ToArray();
                }
                else if (action == "Ends with")
                {
                    inputNames = inputNames.Where(x => !endsWithFilter(x, param)).ToArray();
                }
                else if (action == "Length")
                {
                    int length = int.Parse(param);

                    inputNames = inputNames.Where(x => !lengthFilter(x, length)).ToArray();
                }
                else if (action == "Contains")
                {
                    inputNames = inputNames.Where(x => !containsFilter(x, param)).ToArray();
                }
            }
            Console.WriteLine(string.Join(" ", inputNames));
        }
    }
}
