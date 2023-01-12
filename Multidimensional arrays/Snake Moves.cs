using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows,cols];
            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char>();
            int capacity = rows * cols;
            int counter = 0;
           for(int i=0;i<snake.Length;i++)
            {
                queue.Enqueue(snake[i]);
                counter++;
                if(counter==capacity)
                {
                    break;
                }
                if(i==snake.Length-1)
                {
                    i = -1;
                }
            }
           for(int i=0;i<rows;i++)
            {
                if(i%2==0)
                {
                    for(int j=0;j<cols;j++)
                    {
                        matrix[i, j] = queue.Dequeue();
                    }
                }
                else
                {
                    for(int j=cols-1;j>=0;j--)
                    {
                        matrix[i, j] = queue.Dequeue();
                    }
                }
            }
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "");
                }
                Console.WriteLine();
            }



        }
    }
}
