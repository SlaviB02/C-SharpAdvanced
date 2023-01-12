using System;
using System.Linq;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rowSize][];
            for (int i = 0; i < rowSize; i++)
            {
                int[] columns = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[i] = columns;
            }
            for(int i=0;i<rowSize-1;i++)
            {
                if(matrix[i].Length==matrix[i+1].Length)
                {
                    for(int j=0;j<matrix[i].Length;j++)
                    {
                        matrix[i][j] *= 2;
                    }
                    for (int j = 0; j < matrix[i+1].Length; j++)
                    {
                        matrix[i+1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j]/= 2;
                    }
                    for (int j = 0; j < matrix[i + 1].Length; j++)
                    {
                        matrix[i+1][j] /= 2;
                    }
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "End")
                {

                    break;
                }
                int row = int.Parse(command[1]);
                int column = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (row < 0 || row >= matrix.Length || column < 0 || column >= matrix[row].Length)
                {
                    
                }
                else
                {
                    if (command[0] == "Add")
                    {
                        matrix[row][column] += value;
                    }
                    else
                    {
                        matrix[row][column] -= value;
                    }
                }
            }
            foreach (int[] element in matrix)
            {
                Console.WriteLine(string.Join(" ", element));
            }
        }
    }
}
