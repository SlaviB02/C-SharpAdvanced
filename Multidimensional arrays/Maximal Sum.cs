using System;
using System.Linq;


namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
            int bestRow = 0;
            int bestSum = 0;
            int bestColumn = 0;
            for (int i = 0; i < matrix.GetLength(0)-2; i++)
            {
               
                for (int j = 0; j < matrix.GetLength(1)-2; j++)
                {
                    int a = matrix[i, j];
                    int b = matrix[i + 1, j];
                    int c = matrix[i + 2, j];
                    int d = matrix[i, j + 1];
                    int e = matrix[i, j + 2];
                    int f = matrix[i + 1, j + 1];
                    int g = matrix[i + 1, j + 2];
                    int h = matrix[i + 2, j + 1];
                    int q = matrix[i + 2, j + 2];
                    int sum = a + b + c + d + e + f + g + h + q;
                    if(sum>bestSum)
                    {
                        bestSum = sum;
                        bestRow = i;
                        bestColumn = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");
            Console.WriteLine($"{matrix[bestRow, bestColumn]} {matrix[bestRow, bestColumn + 1]} {matrix[bestRow, bestColumn + 2]}");
            Console.WriteLine($"{matrix[bestRow+1, bestColumn]} {matrix[bestRow+1, bestColumn + 1]} {matrix[bestRow+1, bestColumn + 2]}");
            Console.WriteLine($"{matrix[bestRow+2, bestColumn]} {matrix[bestRow+2, bestColumn + 1]} {matrix[bestRow+2, bestColumn + 2]}");
        }
    }
}
