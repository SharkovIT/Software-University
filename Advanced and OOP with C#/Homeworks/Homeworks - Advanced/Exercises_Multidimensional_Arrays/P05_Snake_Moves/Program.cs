using System;
using System.Linq;
using System.Text;

namespace P05_Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            char[,] matrix = new char[dimensions[0], dimensions[1]];

            string snake = Console.ReadLine();

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snake[counter++];

                    if (counter >= snake.Length)
                    {
                        counter = 0;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
