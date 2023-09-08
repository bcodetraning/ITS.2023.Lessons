using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;

namespace CsvLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            //List<Account> conti = new List<Account>();
            people.Add(new() { Name = "Bruno", Age = 40 });
            people.Add(new() { Name = "Marco", Age = 30 });
            people.Add(new() { Name = "Diego", Age = 20 });
            people.Add(new() { Name = "Mauro", Age = 10 });
            Console.WriteLine("Hello World!");
            var result = LoadFromTextFileCsvHelper<Person>(@"D:\logs\saveToFile.csv");

            foreach (var item in result.ToList())
            {
                //Console.Write($" Album: {item.Album}");
                //Console.Write($" -  ");
                //Console.Write($"Title: {item.Title}");
                //Console.WriteLine($"  ");
            }
        }
        public static List<T> LoadFromTextFileCsvHelper<T>(string filePath) where T : class, new()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8, // Our file uses UTF-8 encoding.
                Delimiter = "," // The delimiter is a comma.
            };
            List<T> records;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                records = csv.GetRecords<T>().ToList();
            }

            return records;
        }

    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
