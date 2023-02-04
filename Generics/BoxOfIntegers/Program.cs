using System;
using System.Linq;
using System.Text;
namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for(int i=0;i<n;i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.input = input;
               Console.WriteLine(box.ToString());
            }
        }
    }
}
