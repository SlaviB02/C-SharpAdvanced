using System;

namespace WallDestoyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];
            PutMatrix(wall);
            int VRow = 0;
            int VCol = 0;
            int wallCounter = 1;
            int rodCounter = 0;
            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    if (wall[i, j] == 'V')
                    {
                        VRow = i;
                        VCol = j;
                    }
                }
            }
            while (true)
            {
                int row = 0;
                int col = 0;
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                if (command == "up")
                {
                    row = -1;
                }
                else if (command == "down")
                {
                    row = 1;
                }
                else if (command == "left")
                {
                    col = -1;
                }
                else if (command == "right")
                {
                    col = 1;
                }

                if (Inside(VRow+ row,VCol + col, wall) == true)
                {
                    if (wall[VRow + row, VCol + col] == 'C')
                    {
                        wall[VRow, VCol] = '*';
                        wallCounter++;
                        VRow += row;
                        VCol += col;
                        wall[VRow, VCol] = 'E';
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {wallCounter} hole(s).");
                        Print(wall);
                        return;

                    } 
                    else if (wall[VRow + row, VCol + col] == 'R')
                    {
                        rodCounter++;
                       Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (wall[VRow + row, VCol + col] == '-')
                    {
                        wall[VRow, VCol] = '*';
                        VRow += row;
                        VCol += col;
                        wallCounter++;
                        wall[VRow, VCol] = 'V';
                    }
                    else if (wall[VRow + row, VCol + col] == '*')
                    {
                        wall[VRow, VCol] = '*';
                        VRow += row;
                        VCol += col;
                        Console.WriteLine($"The wall is already destroyed at position [{VRow}, {VCol}]!");
                        wall[VRow, VCol] = 'V';
                    }
                   
                    
                    
                   
                    
                }
                
               
            }
            Console.WriteLine($"Vanko managed to make {wallCounter} hole(s) and he hit only {rodCounter} rod(s).");
            Print(wall);

        }
        public static void PutMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
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
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static bool Inside(int row, int col, char[,] track)
        {
            return row >= 0 && row < track.GetLength(0) && col >= 0 && col < track.GetLength(1);
        }
    }
}
