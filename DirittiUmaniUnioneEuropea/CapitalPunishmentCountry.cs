using System;



namespace Polimorfismo.Interfaces
{
    class CapitalPunishmentCountry : Country, IONU, ICapitalPunishment
    {
        public CapitalPunishmentCountry(string Name, string State, string Government, string Constitution) :
            base(Name, State, Government, Constitution)
        {

        }
        public void Death()
        {
            Console.WriteLine("Apply death Punishment");
        }

        public virtual void PopulationControl()
        {
            Console.WriteLine("");

        }

        public void TerritoryControl()
        {
            Console.WriteLine("");

        }
    }


}

