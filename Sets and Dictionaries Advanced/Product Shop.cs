using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            while(true)
            {
                string[] input = Console.ReadLine().Split(", ");
                string shopName = input[0];
                if (shopName == "Revision")
                {
                    break;
                }
                string product = input[1];
                double price = Convert.ToDouble(input[2]);
                if(shops.ContainsKey(shopName)==false)
                {
                    shops.Add(shopName, new Dictionary<string, double>() { { product, price } });
                }
                else
                {
                    shops[shopName].Add(product, price);
                }
            }
            var orderedShops = shops.OrderBy(s => s.Key).ToDictionary(x=> x.Key,x=>x.Value);
           foreach(var shop in orderedShops)
            {
               Console.WriteLine($"{shop.Key}->");
                foreach(var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
