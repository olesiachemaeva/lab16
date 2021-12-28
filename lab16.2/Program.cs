using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace lab16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using(StreamReader sr = new StreamReader("../../../Product.json"))
            {
                 jsonString = sr.ReadToEnd();
            }
            Product[] product = JsonSerializer.Deserialize<Product[]>(jsonString);
            Product maxproduct1 = product[0];
            foreach(Product e in product)
            {
                if (e.Price>maxproduct1.Price)
                {
                    maxproduct1 = e;
                }
            }
            Console.WriteLine($"{maxproduct1.Code}, {maxproduct1.Name}, {maxproduct1.Price}");
            Console.ReadKey();
        }
    }
    class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }
}
