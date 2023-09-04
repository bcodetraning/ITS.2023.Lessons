using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.Composizione
{
    class Company
    {
        CEO _cEO;
        public Company(string CeoName, string stipendio)
        {
            _cEO = new CEO(CeoName, stipendio);

        }
        public void ChangeCeo(string name, string stipendio) // gestione del cambio dell'oggetto anidato 
        {
            _cEO = new CEO(name, stipendio);
        }
        class CEO
        {
            string _name;
            string _stipendio;
            public CEO(string name, string stipendio)
            {
                _name = name;
                _stipendio = stipendio;
            }
        }
    }
    class Paese
    {
        string _name;
        Regione _regione;
        public Paese(string NomePaese)
        {
            _name = NomePaese;
        }
        void AddRegione(Regione regione)
        {
            _regione = regione;
        }
        public void CreateRegione(string NomeRegione)
        {
            _regione = new Regione(NomeRegione);
        }
        public void ChangeRegione(Paese paese)
        {
            paese.AddRegione(_regione);
        }
        public void CreateProvincia(string Regione, string NomeProvincia)
        {
            _regione.ChangeProvincia(NomeProvincia);
        }
        public void ChangeProvincia(string Regione, string Provincia)
        {
            Regione regione = new Regione(Regione);
            regione.ChangeProvincia(Provincia);
        }
        public void CreateComune(string Regione, string Provincia, string Comune)
        {
            _regione.CreateComune(Comune, Provincia);
        }
        public void ChangeComune(string paeseDest, string RegioneDest, string Provincia, string Comune)
        {
            this._name = paeseDest;
            _regione = new Regione(RegioneDest);// Tirolo
            _regione.ChangeComune(Provincia, Comune);

        }
        public void ShowComune(string Comune)
        {
            Console.WriteLine($"Il comune di {Comune} in questo momento appartiente a: ");
            Console.WriteLine($"Paese: {this._name}");
            _regione.ShowComune(Comune);

        }
        class Regione
        {

            string _name;
            Provincia _provincia;
            public Regione(string Name)
            {
                _name = Name;
            }

            void AddProvincia(Provincia provincia)// Milano
            {

                _provincia = provincia;
            }
            public void CreateProvincia(string provincia)
            {
                _provincia = new Provincia(provincia);
            }
            public void ChangeProvincia(string Regione)
            {
                Regione regione = new Regione(Regione); // Nella 
                regione.AddProvincia(_provincia);
            }
            public void CreateComune(string NomeComune, string NomeProvincia)
            {
                _provincia = new Provincia(NomeProvincia);
                _provincia.CreateComune(NomeComune);// innsbruck
            }
            public void ChangeComune(string Provincia, string Comune)
            {
                _provincia = new Provincia(Provincia);
                _provincia.ChangeComune(Provincia, Comune);
            }
            public void ShowComune(string Comune)
            {
                Console.WriteLine($"Regione: {this._name}");
                _provincia.ShowComune(Comune);
            }
            class Provincia //Innsbruck
            {

                Comune _comune;
                public string _name;
                public Provincia(string ProvinciaName)
                {
                    _name = ProvinciaName;
                }

                //Medoto privato visto solo dalla classe provincia 
                void AddComune(Comune Comune)// Milano
                {
                    _comune = Comune;
                }
                public void CreateComune(string ComuneName)
                {
                    _comune = new Comune(ComuneName);
                }
                public void ChangeComune(string Provincia, string Milano)// Milano
                {
                    //Aggiungno alla provincia di Milano passato come argomento+

                    // AddComune viene chimato su Milano. 
                    this.AddComune(this._comune); // _comune è il comune di Torino


                    // a questo punto il comune è gia associato all'altra provincia,
                    // posso cancellarlo da questa provincia
                    _comune = null;

                }
                public void ShowComune(string Comune)
                {
                    Console.WriteLine($"Provincia: {this._name}");

                }
                class Comune
                {
                    string _name;
                    public Comune(string Name)
                    {
                        _name = Name;
                    }
                }
            }
        }
    }

}
