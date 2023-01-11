using System;
using System.Linq;
namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
            int bestSum = 0;
            int bestRow = 0;
            int bestColumn = 0;
            for (int i = 0; i < rows-1; i++)
            {
               
                for (int j = 0; j < columns-1; j++)
                {
                    var newSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if(newSum>bestSum)
                    {
                        bestSum = newSum;
                        bestRow = i;
                        bestColumn = j;
                    }
                }
            }
            Console.WriteLine(matrix[bestRow, bestColumn] + " " + matrix[bestRow , bestColumn+1]);
            Console.WriteLine(matrix[bestRow+1, bestColumn] + " " + matrix[bestRow + 1, bestColumn+1]);
            Console.WriteLine(bestSum);


        }
    }
}
