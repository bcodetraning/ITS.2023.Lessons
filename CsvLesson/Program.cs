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
          



            saveToFile(people,@"D:\logs\saveToFile.csv"); 
            var result = LoadFromTextFileCsvHelper<Person>(@"D:\logs\saveToFile.csv");

            foreach (var p in result.ToList())
            {
                Console.Write($" Album: {p.Name}");
                Console.Write($" -  ");
                Console.Write($"Title: {p.Age}");
                Console.WriteLine($"  ");
            }
        }
        public static void saveToFile<T>(List<T> data, string filePath) where T : class
        {
            List<string> lines = new List<string>(); // 
            StringBuilder line = new StringBuilder();

            if (data == null || data.Count == 0)
            {
                throw new ArgumentException("data", "La lista è vuota!");
            }

            var cols = data[0].GetType().GetProperties();

            foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
            {
                line.Append(col.Name);
                line.Append(",");
            }

            lines.Add(line.ToString().Substring(0, line.Length - 1));

            foreach (var row in data)
            {

                line = new StringBuilder();
                foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
                {
                    line.Append(col.GetValue(row));
                    line.Append(",");
                }
                lines.Add(line.ToString().Substring(0, line.Length - 1));
            }

            System.IO.File.WriteAllLines(filePath, lines);

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
