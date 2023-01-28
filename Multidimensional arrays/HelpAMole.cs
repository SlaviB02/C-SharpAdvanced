using System;

namespace Help_A_Mole
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
            int moleRow = 0;
            int moleCol = 0;
            int points = 0;
            int firstSRow = 0;
            int secondSRow = 0;
            int firstSCol = 0;
            int secondSCol = 0;
            bool flag = true;
            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 'M')
                    {
                        moleRow = i;
                        moleCol = j;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 'S')
                    {
                        if (flag == true)
                        {
                            firstSRow = i;
                            firstSCol = j;
                            flag = false;
                        }
                        else
                        {
                            secondSRow = i;
                            secondSCol = j;
                        }
                    }
                }
            }

            while (true)
            {
                int row = 0;
                int col = 0;
                string command = Console.ReadLine();
                if (command == "End" || points >= 25)
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

                if (isInside(moleRow+row, moleCol+col, matrix) == true)
                {
                    if(matrix[moleRow+row, moleCol+col] == '-')
                    {
                        matrix[moleRow, moleCol] = '-';
                        moleRow += row;
                        moleCol += col;
                    }
                   else if (char.IsDigit(matrix[moleRow+row, moleCol+col])==true)
                    {
                        matrix[moleRow, moleCol] = '-';
                        points += int.Parse(matrix[moleRow+row, moleCol+col].ToString());
                        moleRow += row;
                        moleCol += col;
                        matrix[moleRow, moleCol] = 'M';
                    }
                    else if (matrix[moleRow+row, moleCol+col] == 'S')
                    {
                        matrix[moleRow, moleCol] = '-';
                        moleRow += row;
                        moleCol += col;
                        if (moleRow== firstSRow && moleCol== firstSCol)
                        {
                            moleRow = secondSRow;
                            moleCol = secondSCol;
                            matrix[firstSRow, firstSCol] = '-';
                        }
                        else if (moleRow == secondSRow && moleCol == secondSCol)
                        {
                            moleRow = firstSRow;
                            moleCol = firstSCol;
                            matrix[secondSRow, secondSCol] = '-';
                        }
                        points -= 3;
                    }
                    matrix[moleRow, moleCol] = 'M';
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                }
            }
            if (points < 25)
            {
                Console.WriteLine($"Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            else
            {
                Console.WriteLine($"Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
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
        public static bool isInside(int row, int col, char[,]matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col <matrix.GetLength(1);
        }

    }

}
