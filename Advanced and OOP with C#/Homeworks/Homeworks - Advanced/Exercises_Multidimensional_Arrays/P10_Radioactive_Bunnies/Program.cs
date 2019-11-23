using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_Radioactive_Bunnies
{
    class Program
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rows = matrixSize[0];
            var cols = matrixSize[1];

            var matrix = new char[rows, cols];

            var currentRow = -1;
            var currentCol = -1;

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'P')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            matrix[currentRow, currentCol] = '.';

            var commands = Console.ReadLine().ToCharArray();

            var queue = new Queue<char>(commands);

            var newPlayerRow = currentRow;
            var newPlayerCol = currentCol;

            while (queue.Count > 0)
            {
                switch (queue.Dequeue())
                {
                    case 'U': newPlayerRow -= 1; break;
                    case 'D': newPlayerRow += 1; break;
                    case 'L': newPlayerCol -= 1; break;
                    case 'R': newPlayerCol += 1; break;
                }

                matrix = MultyplyBunnies(matrix, rows, cols);

                if (newPlayerRow >= 0 && newPlayerRow < matrix.GetLength(0)
                    && newPlayerCol >= 0 && newPlayerCol < matrix.GetLength(1))
                {
                    currentRow = newPlayerRow;
                    currentCol = newPlayerCol;

                    if (matrix[currentRow, currentCol] == 'B')
                    {
                        PrintMatrix(matrix, rows, cols);
                        Console.WriteLine($"dead: {currentRow} {currentCol}");
                        return;
                    }
                }
                else
                {
                    PrintMatrix(matrix, rows, cols);
                    Console.WriteLine($"won: {currentRow} {currentCol}");
                    return;
                }

            }
        }
        public static char[,] MultyplyBunnies(char[,] matrix, int rows, int cols)
        {
            var newMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            newMatrix[row, col - 1] = 'B';
                        }
                        if (col + 1 < cols)
                        {
                            newMatrix[row, col + 1] = 'B';
                        }
                        if (row + 1 < rows)
                        {
                            newMatrix[row + 1, col] = 'B';
                        }
                    }
                }
            }
            return newMatrix;
        }
        public static void PrintMatrix(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
