using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scales = new EqualityScale<int>(7, 4);
            Console.WriteLine(scales.AreEqual());
        }
    }
}
