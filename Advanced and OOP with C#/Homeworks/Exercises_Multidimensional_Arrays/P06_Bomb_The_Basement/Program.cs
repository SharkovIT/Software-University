using System;
using System.Linq;

namespace P06_Bomb_The_Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] basement = new int[rows][];

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int targetRow = input[0];
            int targetCol = input[1];
            int radius = input[2];

            for (int i = 0; i < basement.Length; i++)
            {
                basement[i] = new int[cols];
            }

            for (int row = 0; row < basement.Length; row++)
            {
                for (int col = 0; col < basement[row].Length; col++)
                {
                    bool IsInRadius = Math.Pow(row - targetRow, 2) + Math.Pow(col - targetCol, 2) <= Math.Pow(radius, 2);

                    if (IsInRadius)
                    {
                        basement[row][col] = 1;
                    }
                }
            }

            for (int col = 0; col < basement[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < basement.Length; row++)
                {
                    if (basement[row][col] == 1)
                    {
                        counter++;
                        basement[row][col] = 0;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    basement[row][col] = 1;
                }
            }
            foreach (var row in basement)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
