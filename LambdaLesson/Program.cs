using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace LambdaLesson
{
    internal class Program
    { 


       
        static List<Comune> comuni = new List<Comune>()
        {
            new() { Name = "Corsico", Provincia = "Milano", Regione = "Lombardia", abitanti = 10000 },
            new() { Name = "Sesto", Provincia = "Milano", Regione = "Lombardia", abitanti = 60000 },
            new() { Name = "Lodi", Provincia = "Lodi", Regione = "Lombardia", abitanti = 20000 },
            new() { Name = "Rho", Provincia = "Milano", Regione = "Lombardia", abitanti = 80000 }
        };
        static void Main(string[] args)
        {
             SelectByProvincia("Milano");

             Console.WriteLine(  "------------------------"  );

             SelectTupleByProvincia("Milano");
        }
        internal static void SelectByProvincia(string Provincia)
        {
            //Provincia == "Milano" 
            List<Comune> result = (from c in comuni
                          where c.Provincia == Provincia //  3 comuni
                          select c).ToList(); // result 3 record per il campo REGIONE                                    

            foreach (var c in result)
            {
                Console.WriteLine(c.Name) ;
            }         

        }
        internal static void SelectTupleByProvincia(string Provincia)
        {
            List<(string Regione, int abitanti)> result =
                (from c in comuni
                 where c.Provincia == Provincia //  3 comuni
                 select new { c.Regione, c.abitanti,c.Provincia })  // Crea un oggetto di tipo anonimo.  
                      .Select(r => (r.Regione, r.abitanti)  ).ToList();  // return una lista di tupla tipizzata List<string,Int>

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Regione} | {item.abitanti}");
            }
        }
        internal static void InlineQuery(string Provincia)
        {
            comuni
                 .Where(c => c.Provincia == Provincia)
                     .Select(i => new { i.Regione, i.Provincia })
                     .Distinct()
                     .OrderByDescending(i => i.Regione)
                     .ToList()
                     .ForEach(c =>
                     {
                         Console.Write(c.Provincia);
                         Console.Write("//");
                         Console.WriteLine(c.Regione);

                     });

        }
    } 

    internal class Comune
    {
        public string Name;
        public string Provincia;
        public string Regione;
        public int abitanti;
        public string paese;
    }
}
