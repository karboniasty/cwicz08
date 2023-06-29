namespace _02_struktury
{
    enum plec
    {
        kobieta,
        mezczyzna
    }
    struct student
    {
        public string imie;
        public string nazwisko;
        public plec plec_studenta;
        public DateTime data_urodzenia;
        public string miejsce_urodzenia;
        public string adres_zameldowania;
        public int nr_telefonu;
        public string adres_email;
        public int nr_albumu;
        public string kierunek;
        public string specjalnosc;
        public string specjalizacja;
    }
    struct przedmiot
    {
        public string nazwa_przedmiotu;
        public string nazwa_wydzialu;
        public string nazwa_kierunku;
        public string wykladowca;
        public string forma_zajec;
        public int liczba_godzin;
        public string forma_zaliczenia;
    }
    struct nauczyciel_akademicki
    {
        public string imie;
        public string nazwisko;
        public string tytul;
        public string dziedzina;
        public int rok_uzyskania_tytulu;
        public string[] wykaz_zajec;
        public string adres_email;
    }
    internal class Program
    {        
        static void Main(string[] args)
        {
            
        }
    }
}