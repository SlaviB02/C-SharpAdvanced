using System;
using System.Linq;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rowSize][];
            for(int i=0;i<rowSize;i++)
            {
                int[] columns = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[i] = columns;
            }
            while(true)
            {
                string[] command = Console.ReadLine().Split();
                if(command[0]=="END")
                {
                  
                    break;
                }
                    int row = int.Parse(command[1]);
                    int column = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if(row<0 || row>=matrix.Length || column<0 ||column>=matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if(command[0]=="Add")
                    {
                        matrix[row][column] += value;
                    }
                    else
                    {
                        matrix[row][column] -= value;
                    }
                }
            }
            foreach(int[]element in matrix)
            {
                Console.WriteLine(string.Join(" ",element));
            }

        }
    }
}
