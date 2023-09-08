using System;
using System.Collections.Generic;

namespace DictionaryExercise
{
    internal class Program
    {
        public enum Corsi
        {
            INFORMATICA,
            LETTERE,
            FISICA
        }
        public enum Esami
        {
            PROGRAMMAZIONE,
            INGLESE,
            STORIA,
            MATEMATICA
        }
        static void Main(string[] args)
        {

            //CREATE UNIVERSITA'
            Dictionary<Corsi, Dictionary<string, Dictionary<Esami, List<int>>>> universitaNetuno =
                new Dictionary<Corsi, Dictionary<string, Dictionary<Esami, List<int>>>>();

            //Add CORSI
            universitaNetuno.Add(Corsi.FISICA, new Dictionary<string, Dictionary<Esami, List<int>>>());
            universitaNetuno.Add(Corsi.LETTERE, new Dictionary<string, Dictionary<Esami, List<int>>>());
            universitaNetuno.Add(Corsi.INFORMATICA, new Dictionary<string, Dictionary<Esami, List<int>>>());

            // ADD nuova matricola 
            universitaNetuno[Corsi.LETTERE].Add("1911584888", new Dictionary<Esami, List<int>>());

            // Add ESAMI alla MATRICOLA
            universitaNetuno[Corsi.LETTERE]["1911584888"].Add(Esami.STORIA, new List<int>());
            universitaNetuno[Corsi.LETTERE]["1911584888"].Add(Esami.PROGRAMMAZIONE, new List<int>());



            // Add VOTI agli esami 
            universitaNetuno[Corsi.LETTERE]["1911584888"][Esami.STORIA].Add(16);
            universitaNetuno[Corsi.LETTERE]["1911584888"][Esami.STORIA].Add(20);

            universitaNetuno[Corsi.LETTERE]["1911584888"][Esami.PROGRAMMAZIONE].Add(10);
            universitaNetuno[Corsi.LETTERE]["1911584888"][Esami.PROGRAMMAZIONE].Add(15);
            universitaNetuno[Corsi.LETTERE]["1911584888"][Esami.PROGRAMMAZIONE].Add(25);


            foreach (var studenti in universitaNetuno[Corsi.LETTERE])
            {
                Console.WriteLine($"STUDENTE MATRICOLA: {studenti.Key} ");
                foreach (var esame in studenti.Value)
                {
                    Console.WriteLine($"            Esame: {esame.Key}");
                    esame.Value.ForEach(x => Console.WriteLine($"" +
                        $"             " +
                        $"             " +
                        $"Voto: {x}"));

                }
            }
            Console.ReadLine();
        }
    }
}
