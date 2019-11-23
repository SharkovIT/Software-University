using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggersAndFollowers = new Dictionary<string, List<string>>();
            Dictionary<string, int[]> vloggersStats = new Dictionary<string, int[]>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] splittedInput = input.Split();

                if (input.Contains("joined"))
                {
                    string vloggerName = splittedInput[0];

                    if (!vloggersAndFollowers.ContainsKey(vloggerName))
                    {
                        vloggersAndFollowers.Add(vloggerName, new List<string>());
                        vloggersStats.Add(vloggerName, new int[2]);
                    }
                }
                else if (input.Contains("followed"))
                {
                    string follower = splittedInput[0];
                    string following = splittedInput[2];

                    if (vloggersAndFollowers.ContainsKey(following) && vloggersAndFollowers.ContainsKey(follower) &&
                        follower != following && !vloggersAndFollowers[following].Contains(follower))
                    {
                        vloggersAndFollowers[following].Add(follower);
                        vloggersStats[following][0]++;
                        vloggersStats[follower][1]++;
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggersAndFollowers.Count} vloggers in its logs.");

            int count = 1;

            foreach (var (vlogger, value) in vloggersStats.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Value[1]))
            {
                //1. VenomTheDoctor : 2 followers, 0 following
                Console.WriteLine($"{count}. {vlogger} : {value[0]} followers, {value[1]} following");

                if (count == 1)
                {
                    var mostFollowed = vloggersAndFollowers.First(x => x.Key == vlogger);

                    foreach (var follower in mostFollowed.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                count++;
            }
        }
    }
}
