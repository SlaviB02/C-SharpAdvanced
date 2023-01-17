namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
          int countPuncMarks = 0;
            int countLetters = 0;
            string[]lines= File.ReadAllLines(inputFilePath);
            List<string> text = new List<string>();
            int counter = 0;
            for (int i=0;i<lines.Length;i++)
            {
                
                for(int j=0;j<lines[i].Length;j++)
                {
                    if (lines[i][j] == '!' || lines[i][j] == ',' || lines[i][j] == ';' || lines[i][j] == '.' || lines[i][j] == '?' || lines[i][j] == '-' ||
                  lines[i][j] == '\'' || lines[i][j] == '\"' || lines[i][j] == ':')
                    {
                        countPuncMarks++;
                    }
                    else if(char.IsLetter(lines[i][j])==true)
                    {
                        countLetters++;
                    }
                }
                string input= $"Line {++counter}: " + lines[i] + $" ({countLetters})({countPuncMarks})";
                text.Add(input);
                File.WriteAllLines(outputFilePath, text);
                countLetters = 0;
                countPuncMarks = 0;
                
            }
        }
    }
}
