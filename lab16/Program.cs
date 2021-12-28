using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;


/*1.Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».

2.    Необходимо разработать программу для получения информации о товаре из json-файла.
Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/

namespace lab16
{
    class Program
    {
        public static object JavaScriptEncoder { get; private set; }

        static void Main(string[] args)
        {
            const int n = 5;
            Product[] prodcts = new Product[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
            int code = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите название товара");
            string name = Console.ReadLine();
            Console.WriteLine("Введите ценe товара");
            int price = Convert.ToInt32(Console.ReadLine());

            prodcts[i] = new Product() { Code=code, Name=name,Price=price};

            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(prodcts, options);


            using (StreamWriter sw = new StreamWriter("../../../Product.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
    class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }
}
