using System.Globalization;

namespace _03_struktura_rpg
{
    enum klasarzadkosci
    {
        Powszechny,
        Rzadki,
        Unikalny,
        Epicki
    }
    enum typprzedmiotu
    {
        Bron,
        Zbroja,
        Amulet,
        Pierscien,
        Helm,
        Tarcza,
        Buty
    }
    struct przedmiot
    {
        public string nazwa;
        public double waga;
        public int wartosc;
        public klasarzadkosci rzadkosc;
        public typprzedmiotu typ;
    }

    class Program
    {              
        static void Main(string[] args)
        {
            przedmiot[] przyklad = new przedmiot[4];
            wypelnijprzedmiot(ref przyklad[0], "Miecz Przeznaczenia", 10, 5000, klasarzadkosci.Epicki, typprzedmiotu.Bron);
            wypelnijprzedmiot(ref przyklad[1], "Slomkowy Kapelusz", 0.2 , 2, klasarzadkosci.Powszechny, typprzedmiotu.Helm);
            wypelnijprzedmiot(ref przyklad[2], "Mroczne Okrycie", 32, 920, klasarzadkosci.Unikalny, typprzedmiotu.Zbroja);
            wypelnijprzedmiot(ref przyklad[3], "Krasnali Sygnet", 0.3, 250, klasarzadkosci.Unikalny, typprzedmiotu.Pierscien);
            Console.WriteLine("Wszystkie dostępne przedmioty:");
            foreach(przedmiot p in przyklad)
                wyswietlprzedmiot(p);
            Console.WriteLine("Wylosowany przedmiot to:");
            przedmiot wylosowany = losujprzedmiot(przyklad);
            wyswietlprzedmiot(wylosowany);
        }

        static void wypelnijprzedmiot (ref przedmiot przedmiot, string nazwa, double waga, 
            int wartosc, klasarzadkosci rzadkosc, typprzedmiotu typ)
        {
            przedmiot.nazwa = nazwa;
            if (waga >= 0)
                przedmiot.waga = waga;
            else
                przedmiot.waga = 0;
            if (wartosc >= 0)
                przedmiot.wartosc = wartosc;
            else
                przedmiot.wartosc = 0;
            przedmiot.rzadkosc = rzadkosc;
            przedmiot.typ = typ;
        }

        static void wyswietlprzedmiot (przedmiot przedmiot)
        {
            Console.WriteLine("Nazwa: " + przedmiot.nazwa);
            Console.WriteLine("Rzadkosc: " + przedmiot.rzadkosc);
            Console.WriteLine("Wartosc: {0}\n", przedmiot.wartosc);
        }

        static przedmiot losujprzedmiot(przedmiot[] skrzynka)
        {
            Random random = new Random();
            int prawdopodobienstwo = random.Next(10);            
            Array.Sort(skrzynka, porownajprzedmioty);
            int[] ilerzadkosci = liczrzadkosci(skrzynka);
            //jesli nie ma przedmiotu o wylosowanej rzadkosci, to losuje przedmiot o nastepnej rzadkosci,
            //chyba ze jest to rzadkosc powszechna, wtedy losuje przedmiot o dowolnej rzadkosci
            if(prawdopodobienstwo==0 && ilerzadkosci[3]!=0)  
            {                
                return skrzynka[random.Next(skrzynka.Length - ilerzadkosci[3], skrzynka.Length)];
            }
            else if(prawdopodobienstwo<=2 && ilerzadkosci[2] != 0)
            {
                return skrzynka[random.Next(skrzynka.Length - ilerzadkosci[3] - ilerzadkosci[2], skrzynka.Length - ilerzadkosci[3])];
            }
            else if(prawdopodobienstwo<=5 && ilerzadkosci[1] != 0)
            {
                return skrzynka[random.Next(ilerzadkosci[0], ilerzadkosci[0] + ilerzadkosci[1])];
            }
            else if (ilerzadkosci[0]!=0)
            {                
                return skrzynka[random.Next(ilerzadkosci[0])];
            }
            else
                return skrzynka[random.Next(skrzynka.Length)];
        }

        static int porownajprzedmioty (przedmiot p1, przedmiot p2)
        {
            if (p1.rzadkosc < p2.rzadkosc)
                return -1;
            else if (p1.rzadkosc == p2.rzadkosc)
                return 0;
            else
                return 1;
        }
        
        static int[] liczrzadkosci(przedmiot[] skrzynka)
        {
            int[] ilerzadkosci = new int[4];
            int ile = 0, j = 0, i=0;
            klasarzadkosci rzadkosc = 0;
            while(i<skrzynka.Length)
            {
                if (skrzynka[i].rzadkosc == rzadkosc)
                {
                    ile++;
                    i++;
                }
                else
                {
                    ilerzadkosci[j] = ile;
                    rzadkosc++;
                    j++;
                    ile = 0;
                }
            }
            ilerzadkosci[j] = ile;
            return ilerzadkosci;
        }
    }
}