using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            for(int i=0;i<input.Length;i++)
            {
                char letter = input[i];
                if(symbols.ContainsKey(letter))
                {
                    symbols[letter]++;
                }
                else
                {
                    symbols.Add(letter, 1);
                }
            }
            var orderedSymbols = symbols.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach(var symbol in orderedSymbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
