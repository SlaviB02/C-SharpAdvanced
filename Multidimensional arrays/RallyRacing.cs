using System;
using System.Linq;
namespace RallyRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string car = Console.ReadLine();
            char[,] track = new char[size, size];
            PutMatrix(track);
            int carRow = 0;
            int carCol = 0;
            bool flag = true;
            int firstTRow = 0;
            int secondTRow = 0;
            int firstTCol = 0;
            int secondTCol = 0;
            int finalRow = 0;
            int finalCol = 0;
            int km = 0;
            for (int i = 0; i < track.GetLength(0); i++)
            {
                for (int j = 0; j < track.GetLength(1); j++)
                {
                    if(track[i,j]=='T')
                    {
                        if(flag==true)
                        {
                            firstTRow = i;
                            firstTCol = j;
                            flag = false;
                        }
                        else
                        {
                            secondTRow = i;
                            secondTCol = j;
                        }
                    }
                    if(track[i,j]=='F')
                    {
                        finalRow = i;
                        finalCol = j;
                    }
                }
                
            }
           
            while (true)
            {
                string command = Console.ReadLine();
                if(command=="End")
                {
                    track[carRow, carCol] = 'C';
                    break;
                }
                if(command=="left")
                {
                    carCol--;
                }
                if(command=="right")
                {
                    carCol++;
                }
                if(command=="up")
                {
                    carRow--;
                }
                if(command=="down")
                {
                    carRow++;
                }

                if(Inside(carRow,carCol,track)==true)
                {
                    if(track[carRow,carCol]=='.')
                    {
                        km += 10;
                    }
                   if(track[carRow,carCol] == 'T')
                    {
                        if (carRow == firstTRow && carCol == firstTCol)
                            {
                                carRow = secondTRow;
                                carCol = secondTCol;
                                track[firstTRow, firstTCol] = '.';
                                track[secondTRow, secondTCol] = '.';
                            }
                            else
                            {
                                carRow = firstTRow;
                                carCol = firstTCol;
                                track[firstTRow, firstTCol] = '.';
                                track[secondTRow, secondTCol] = '.';
                            }
                            km += 30;
                        
                        
                    }
                    if(track[carRow,carCol] == 'F')
                    {
                        km += 10;
                        track[finalRow, finalCol] = 'C';
                        Console.WriteLine($"Racing car {car} finished the stage!");
                        Console.WriteLine($"Distance covered {km} km.");
                        Print(track);
                        return;
                    }

                   
                }
               
                
            }
            Console.WriteLine($"Racing car {car} DNF.");
            Console.WriteLine($"Distance covered {km} km.");
            Print(track);

        }
        public static void PutMatrix(char[,]matrix)
        {
            for(int i=0;i<matrix.GetLength(0);i++)
            {
                char[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for(int j=0;j<matrix.GetLength(1);j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
        public static void Print(char[,]matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static bool Inside(int row,int col,char[,]track)
        {
            return row >= 0 && row < track.GetLength(0) && col >= 0 && col < track.GetLength(1);
        }
    }
}
