namespace _01_typy_wyliczeniowe
{
    enum dzień_tygodnia
    {
        poniedziałek = 1,
        wtorek,
        środa,
        czwartek,
        piątek,
        sobota,
        niedziela
    }
    enum etap_prania
    {
        pranie_ubrań,
        płukanie,
        wirowanie
    }
    enum posiłek
    {
        śniadanie,
        drugie_sniadanie,
        obiad,
        podwieczorek,
        kolacja
    }
    enum bierki_szachowe
    {
        pion = 1,
        skoczek = 3,
        goniec = 3,
        wieża = 5,
        hetman = 9,
        król = 0 //nie ma określonej wartość punktowej
    }
    internal class Program
    {    
        static void Main(string[] args)
        {
            //przykładowe wypisanie
            Console.WriteLine(bierki_szachowe.hetman.ToString());
            dzień_tygodnia dzien = dzień_tygodnia.piątek;
            if((int)dzien == 5)
            Console.WriteLine(dzien.ToString());         
        }
    }
}