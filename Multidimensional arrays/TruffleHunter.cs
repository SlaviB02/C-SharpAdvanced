using System;
using System.Linq;
namespace Truffle
{
    class Program
    {
        public static int countWhite = 0;
        public static int countBlack = 0;
        public static int countSummer = 0;
        public static int eatenCount = 0;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forest = new char[size, size];
            PutMatrix(forest);
            
            while(true)
            {
                string[] command = Console.ReadLine().Split();
                if(command[0]=="Stop")
                {
                    break;
                }
                if(command[0]=="Collect")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    CheckTruffels(row, col, forest);
                }
                if(command[0]=="Wild_Boar")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    string direction = command[3];
                    if(direction=="up")
                    {
                        for(int i=row;i>=0;i=i-2)
                        {
                            CheckEaten(i, col, forest);
                        }
                    }
                    else if(direction=="down")
                    {
                        for(int i=row;i<size;i=i+2)
                        {
                            CheckEaten(i, col, forest);
                        }
                    }
                    else if(direction=="left")
                    {
                        for(int j=col;j>=0;j=j-2)
                        {
                            CheckEaten(row, j, forest);
                        }
                    }
                    else if(direction=="right")
                    {
                        for(int j=col;j<size;j=j+2)
                        {
                            CheckEaten(row, j, forest);
                        }
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {countBlack} black, {countSummer} summer, and {countWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenCount} truffles.");
            Print(forest);
        }
        public static void PutMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char []input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
        public static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        public static void CheckTruffels(int row,int col,char[,]forest)
        {
            if (forest[row, col] == 'S')
            {
                countSummer++;
                forest[row, col] = '-';
            }
            else if (forest[row, col] == 'W')
            {
                countWhite++;
                forest[row, col] = '-';
            }
            else if (forest[row, col] == 'B')
            {
                countBlack++;
                forest[row, col] = '-';
            }
        }
        public static void CheckEaten(int row, int col, char[,] forest)
        {
            if (forest[row, col] == 'S' || forest[row, col] == 'W' || forest[row, col] == 'B')
            {
                eatenCount++;
                forest[row, col] = '-';
            }   
        }
    }
}
