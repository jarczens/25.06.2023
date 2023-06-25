using System;

namespace Ćw_8_zajecia
{
    enum KlasaRzadkosci
    {
        Powrzechny = 1,
        Rzadki,
        Unikalny,
        Epicki
    }
    enum TypPrzedmiotu
    {
        Bron,
        Zbroja,
        Amulet,
        Pierscien,
        Helm,
        Tarcza,
        Buty
    }
    struct Przedmiot
    {
        public float Waga;
        public int Wartosc;
        public string Nazwa;
        public KlasaRzadkosci Rzadkosc;
        public TypPrzedmiotu Typ;
    }
    class Program
    {
        static void Wypelnij(ref Przedmiot PrzedmiotDoWypelnienia,  
            float Waga, 
            int Wartosc, 
            string Nazwa, 
            KlasaRzadkosci Rzadkosc,
            TypPrzedmiotu Typ)
        {
            if (Waga>=0)
            {
                PrzedmiotDoWypelnienia.Waga = Waga;
            }
            else
            {
                PrzedmiotDoWypelnienia.Waga = 0;
            }

            if (Wartosc >= 0)
            {
                PrzedmiotDoWypelnienia.Wartosc = Wartosc;
            }
            else
            {
                PrzedmiotDoWypelnienia.Wartosc = 0;
            }

            PrzedmiotDoWypelnienia.Nazwa = Nazwa;
            PrzedmiotDoWypelnienia.Rzadkosc = Rzadkosc;
            PrzedmiotDoWypelnienia.Typ = Typ;

        }
        static void Wyswietl(Przedmiot Przedmiot)
        {
            Console.WriteLine($"Przedmiot: {Przedmiot.Nazwa}");
            Console.WriteLine($"Wartosc: {Przedmiot.Wartosc}");
            Console.WriteLine();
        }

        static Przedmiot LosujPrzedmiot(Przedmiot[] Skrzynka)
        {
            Random random = new Random();

            Array.Sort(Skrzynka, PorownajPrzedmioty);

            int sumaRzadkosci = 0;
            foreach (Przedmiot przedmiot in Skrzynka)
            {
                sumaRzadkosci += (int)przedmiot.Rzadkosc;
            }

            int losowanaRzadkosc = random.Next(1, sumaRzadkosci + 1);
            int aktualnaSuma = 0;

            foreach (var przedmiot in Skrzynka)
            {
                aktualnaSuma += (int)przedmiot.Rzadkosc;
                if (aktualnaSuma>=losowanaRzadkosc)
                {
                    return przedmiot;
                }
            }
            return Skrzynka[0];
        }

        static int PorownajPrzedmioty(Przedmiot p1, Przedmiot p2)
        {
            if (p1.Rzadkosc < p2.Rzadkosc)
                return -1;
            else if (p1.Rzadkosc == p2.Rzadkosc)
                return 0;
            else
                return 1;
        }
        static void Main(string[] args)
        {
            Przedmiot[] przedmioty = new Przedmiot[3];

            Wypelnij(ref przedmioty[0], 1.5f, 10, "Miecz", KlasaRzadkosci.Powrzechny, TypPrzedmiotu.Bron);
            Wypelnij(ref przedmioty[1], 2.5f, 1000, "Naszyjnik ochrony", KlasaRzadkosci.Unikalny, TypPrzedmiotu.Amulet);
            Wypelnij(ref przedmioty[2], 3.5f, 100000, "Zbroja smoka", KlasaRzadkosci.Epicki, TypPrzedmiotu.Zbroja);

            Przedmiot wylosowany = LosujPrzedmiot(przedmioty);

            Wyswietl(wylosowany);
        }
    }
}
