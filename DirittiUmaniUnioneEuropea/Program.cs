using System;
using Polimorfismo.Interfaces;

namespace Polimorfismo
{
    internal class Program
    {
        static void Main(string[] args)
        {



            // NOTA: Se si necessita di specifici overriding dei metodi, è necessario avere una classe per ogni paese specifico.
            // In questo caso stiamo solo classificano i paesi per categoria 


            // upcasting 
            IONU USA = new CapitalPunishmentCountry("USA", "democratico", "Federale", "1789");
            IONU italy = new EuroZoneCountry("Italy", "democratico", "Parlamentare", "1947");
            IONU Argentina = new ONUCountry("Argentina", "democratico", "Parlamentare", "1922");


            EuroZoneCountry EuroItaly = (EuroZoneCountry)  italy; // Downcasting


            EuroCentralBank.CalcSpread(EuroItaly);
            StrasbourgCourt.HumanRightsInvestigation(USA);
            StrasbourgCourt.HumanRightsInvestigation(italy);
            StrasbourgCourt.HumanRightsInvestigation(Argentina);


        }


    }
}

