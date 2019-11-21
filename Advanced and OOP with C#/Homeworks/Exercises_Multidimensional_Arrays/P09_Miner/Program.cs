using System;
using System.Linq;

namespace P09_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fildSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fildSize, fildSize];

            string[] commands = Console.ReadLine()
                .Split();

            int startRow = -1;
            int startCol = -1;
            int coalCount = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    if (field[row, col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "up":
                        if (startRow - 1 >= 0)
                        {
                            startRow -= 1;
                        }
                        break;
                    case "right":
                        if (startCol + 1 < field.GetLength(1))
                        {
                            startCol += 1;
                        }
                        break;
                    case "left":
                        if (startCol - 1 >= 0)
                        {
                            startCol -= 1;
                        }
                        break;
                    case "down":
                        if (startRow + 1 < field.GetLength(0))
                        {
                            startRow += 1;
                        }
                        break;
                    default:
                        break;
                }

                if (field[startRow, startCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                    return;
                }
                if (field[startRow, startCol] == 'c')
                {
                    coalCount--;
                    field[startRow, startCol] = '*';
                }
                if (coalCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return;
                }
            }
            Console.WriteLine($"{coalCount} coals left. ({startRow}, {startCol})");
        }
    }
}
