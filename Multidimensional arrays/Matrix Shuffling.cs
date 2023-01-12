using System;
using System.Linq;


namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            while(true)
            {
                string[] command = Console.ReadLine().Split();
                if(command[0]=="END")
                {
                    break;
                }
                if(command[0]=="swap")
                {
                    if(command.Length!=5)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    else
                    {
                        int row1 = int.Parse(command[1]);
                        int col1 = int.Parse(command[2]);
                        int row2 = int.Parse(command[3]);
                        int col2 = int.Parse(command[4]);
                        if(row1<0 || row1>=matrix.GetLength(0) || col1<0 || col1>=matrix.GetLength(1))
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                        if (row2 < 0 || row2 >= matrix.GetLength(0) || col2 < 0 || col2 >= matrix.GetLength(1))
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                        string swap = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = swap;
                        for(int i=0;i<matrix.GetLength(0);i++)
                        {
                            for(int j=0;j<matrix.GetLength(1);j++)
                            {
                                Console.Write(matrix[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
          
        }
    }
}
