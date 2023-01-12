using System;
using System.Linq;


namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[,] matrix = new int[N, N];
            for(int i=0;i<N;i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for(int j=0;j<N;j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
            int primary = 0;
            for(int i=0;i<N;i++)
            {
                primary += matrix[i, i];
            }
           
            int secondary = 0;
            for (int i = 0; i < N; i++)
            {
                    secondary += matrix[i,N-i-1];
                
            }
           
            Console.WriteLine(Math.Abs(primary - secondary));
        }
    }
}
