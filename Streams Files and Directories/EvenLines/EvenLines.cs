namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
            
        }

        public static string ProcessLines(string inputFilePath)
        {
            string sb ="";
            Queue<string> queue = new Queue<string>();
            var reader = new StreamReader(inputFilePath);
            using(reader)
            {
                List<string> word = new List<string>();
                string line = reader.ReadLine();
                int counter = 0;
                while(line!=null)
                {
                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == '-' || line[i] == ',' || line[i] == '.' || line[i] == '!' || line[i] == '?')
                            {
                                sb += '@';
                            }
                            else
                            {
                                sb += line[i];
                            }
                        }
                        string[] words = sb.Split();
                        for (int i =words.Length-1;i>=0; i--)
                        {
                            queue.Enqueue(words[i]);
                        }
                        word.Add(string.Join(" ", queue));
                        sb = string.Empty;
                        queue.Clear();
                    }
                    counter++;
                    line = reader.ReadLine();
                   
                }
                return string.Join(Environment.NewLine, word);

            }
            
            
        }
    }
}
