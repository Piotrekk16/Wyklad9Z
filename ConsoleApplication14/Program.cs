using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class PobieraczPlikow
    {

        public PobieraczPlikow(int l)
        {
            liczbaDoPobraniaPlikow = l;
        }

        public void WystapilBlad()
        {
            if (PrzyBlendziePobierania != null)
                PrzyBlendziePobierania("Wystapił błąd");
        }

        public delegate void BladPobierniaDelegata(string wiadomosc);
        public event BladPobierniaDelegata PrzyBlendziePobierania;

        public delegate void SkonczonePobieranieDelegata();
        public event SkonczonePobieranieDelegata SkonczonePobieranie;

        private int liczbaPobranychPlikow;
        public int LiczbaPobranychPlikow
        {
            get { return liczbaPobranychPlikow; }
            set
            {
                if (value == liczbaDoPobraniaPlikow)
                {
                    if (SkonczonePobieranie != null)
                        SkonczonePobieranie();
                }
                liczbaPobranychPlikow = value;
            }
        }

        private int liczbaDoPobraniaPlikow;
        public int LiczbaDoPobraniaPlikow
        {
            get { return liczbaDoPobraniaPlikow; }
        }
    }
    
    class Program
    {
        static void pobi_ObsluStrum()
        {
            Console.WriteLine("\t Obsługuje teraz strumienie.");
        }

        static void pobi_Poinformuj()
        {
            Console.WriteLine("\t Skonczyłem pobieranie");
        }
        
        static void Main(string[] args)
        {
            PobieraczPlikow pobieracz = new PobieraczPlikow(3);
            pobieracz.SkonczonePobieranie += pobi_Poinformuj;
            pobieracz.SkonczonePobieranie += pobi_ObsluStrum;
            pobieracz.LiczbaPobranychPlikow = 3;//odpalenie zdarzenia
            Console.ReadKey();
        }
    }
}
