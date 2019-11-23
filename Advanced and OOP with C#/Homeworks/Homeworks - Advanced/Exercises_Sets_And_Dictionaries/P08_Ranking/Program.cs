using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestAndPasswords = new Dictionary<string, string>();
            var contestInfo = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(":");

                if (input[0] == "end of contests")
                {
                    break;
                }

                string contest = input[0];
                string password = input[1];

                if (!contestAndPasswords.ContainsKey(contest))
                {
                    contestAndPasswords.Add(contest, password);
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split("=>");

                if (input[0] == "end of submissions")
                {
                    break;
                }

                string contest = input[0];
                string password = input[1];
                string name = input[2];
                int points = int.Parse(input[3]);

                if (contestAndPasswords.ContainsKey(contest) && contestAndPasswords[contest] == password)
                {
                    if (!contestInfo.ContainsKey(name))
                    {
                        contestInfo.Add(name, new Dictionary<string, int>());
                        contestInfo[name].Add(contest, points);
                    }
                    else
                    {
                        if (!contestInfo[name].ContainsKey(contest))
                        {
                            contestInfo[name].Add(contest, points);
                        }
                        if (contestInfo[name][contest] < points)
                        {
                            contestInfo[name][contest] = points;
                        }
                    }
                }
            }

            string bestCandidate = string.Empty;
            int maxPoints = 0;

            foreach (var (user, value) in contestInfo)
            {
                int sum = value.Values.Sum();

                if (maxPoints < sum)
                {
                    maxPoints = sum;
                    bestCandidate = user;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var kvp in contestInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var item in  contestInfo[kvp.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
