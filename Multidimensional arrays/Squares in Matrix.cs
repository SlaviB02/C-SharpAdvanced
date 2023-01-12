using System;
using System.Linq;


namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            int []input= Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[input[0], input[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] numbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    char one = matrix[i, j];
                    char two = matrix[i + 1, j];
                    char three = matrix[i, j + 1];
                    char four = matrix[i + 1, j + 1];
                    if(one==two && one==three && one==four)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
