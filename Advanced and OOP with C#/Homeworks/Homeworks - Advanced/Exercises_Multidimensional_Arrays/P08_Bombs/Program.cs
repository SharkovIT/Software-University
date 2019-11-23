using System;
using System.Linq;

namespace P08_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int dim = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dim, dim];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string[] coordinates = Console.ReadLine()
                .Split();

            foreach (var coordinate in coordinates)
            {
                int[] bombCord = coordinate
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = bombCord[0];
                int bombCol = bombCord[1];

                int bomb = matrix[bombRow, bombCol];

                if (IsInside(matrix, bombRow, bombCol) && matrix[bombRow, bombCol] > 0)
                {
                    if (IsInside(matrix, bombRow, bombCol - 1))
                    {
                        if (matrix[bombRow, bombCol - 1] > 0)
                        {
                            matrix[bombRow, bombCol - 1] -= bomb;
                        }
                    }
                    if (IsInside(matrix, bombRow - 1, bombCol - 1))
                    {
                        if (matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= bomb;
                        }
                    }
                    if (IsInside(matrix, bombRow - 1, bombCol))
                    {
                        if (matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= bomb;
                        }
                    }
                    if (IsInside(matrix, bombRow - 1, bombCol + 1))
                    {
                        if (matrix[bombRow - 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol + 1] -= bomb;
                        }
                    }
                    if (IsInside(matrix, bombRow, bombCol + 1))
                    {
                        if (matrix[bombRow, bombCol + 1] > 0)
                        {
                            matrix[bombRow, bombCol + 1] -= bomb;
                        }
                    }
                    if (IsInside(matrix, bombRow + 1, bombCol))
                    {
                        if (matrix[bombRow + 1, bombCol] > 0)
                        {
                            matrix[bombRow + 1, bombCol] -= bomb;
                        }
                    }
                    if (IsInside(matrix, bombRow + 1, bombCol - 1))
                    {
                        if (matrix[bombRow + 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol - 1] -= bomb;
                        }
                    }
                    if (IsInside(matrix, bombRow + 1, bombCol + 1))
                    {
                        if (matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol + 1] -= bomb;
                        }
                    }

                    matrix[bombRow, bombCol] = 0;
                }
            }

            int aliveCells = 0;
            int sum = 0;

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int[,] matrix, int bombRow, int bombCol)
        {
            return bombRow >= 0 && bombRow < matrix.GetLength(0) &&
                bombCol >= 0 && bombCol < matrix.GetLength(1);
        }
    }
}
