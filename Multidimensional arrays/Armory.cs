using System;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int officerRow = 0;
            int officerCol = 0;
            int goldCoins = 0;
            int firstMRow = 0;
            int secondMRow = 0;
            int firstMCol = 0;
            int secondMCol = 0;
            bool flag = true;
            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 'A')
                    {
                        officerRow = i;
                        officerCol = j;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 'M')
                    {
                        if (flag == true)
                        {
                            firstMRow = i;
                            firstMCol = j;
                            flag = false;
                        }
                        else
                        {
                            secondMRow = i;
                            secondMCol = j;
                        }
                    }
                }
            }
            while (true)
            {
                int row = 0;
                int col = 0;
                string command = Console.ReadLine();
                if (goldCoins >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
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

                if (isInside(officerRow + row,officerCol + col, matrix) == true)
                {
                    if (matrix[officerRow + row, officerCol + col] == '-')
                    {
                        matrix[officerRow, officerCol] = '-';
                       officerRow += row;
                        officerCol += col;
                        matrix[officerRow, officerCol] = 'A';
                    }
                    else if (char.IsDigit(matrix[officerRow + row, officerCol + col]) == true)
                    {
                        matrix[officerRow, officerCol] = '-';
                        goldCoins += int.Parse(matrix[officerRow + row, officerCol + col].ToString());
                        officerRow += row;
                        officerCol += col;
                        matrix[officerRow, officerCol] = 'A';
                    }
                    else if (matrix[officerRow + row, officerCol + col] == 'M')
                    {
                        matrix[officerRow, officerCol] = '-';
                        officerRow += row;
                        officerCol += col;
                        if (officerRow == firstMRow && officerCol == firstMCol)
                        {
                            officerRow = secondMRow;
                            officerCol = secondMCol;
                            matrix[firstMRow, firstMCol] = '-';
                            matrix[officerRow, officerCol] = 'A';
                        }
                        else if (officerRow == secondMRow && officerCol == secondMCol)
                        {
                            officerRow = firstMRow;
                            officerCol = firstMCol;
                            matrix[secondMRow, secondMCol] = '-';
                            matrix[officerRow, officerCol] = 'A';
                        }
                       
                    }
                    
                }
                else
                {
                    matrix[officerRow, officerCol] = '-';
                    Console.WriteLine($"I do not need more swords!");
                    break;
                }
            }
            Console.WriteLine($"The king paid {goldCoins} gold coins.");
            Print(size, matrix);

        }
        public static void Print(int size, char[,] matrix)
        {
            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static bool isInside(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
