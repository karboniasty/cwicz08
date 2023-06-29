namespace _04_student
{
    enum plec
    {
        kobieta,
        mężczyzna
    }
    struct student
    {
        public string nazwisko;
        public int nr_albumu;
        public double ocena;
        public plec plec;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            student[] student = new student[5];
            wypelnijstudenta(ref student[0], "Kowalski", 1234, 3.5, plec.mężczyzna);
            wypelnijstudenta(ref student[1], "Nowak", 1235, 4.8, plec.kobieta);
            wypelnijstudenta(ref student[2], "Krawczyk", 1236, 1.8, plec.mężczyzna);
            wypelnijstudenta(ref student[3], "Jaworska", 1237, 12, plec.kobieta);
            wypelnijstudenta(ref student[4], "Gołąb", 1238, 4, plec.mężczyzna);            
            Console.WriteLine("Lista studentów: ");
            for(int i=0; i<student.Length; i++)
            {
                wyswietlstudenta(student[i]);
            }
            Console.WriteLine("\nŚrednia ocen tych studentów wynosi: " + liczsrednia(student));            
        }
        static void wypelnijstudenta (ref student student, string nazwisko, int nr_albumu, double ocena, plec plec)
        {
            student.nazwisko = nazwisko;
            if (ocena < 2)
                student.ocena = 2;
            else if (ocena > 5)
                student.ocena = 5;
            else
                student.ocena = ocena;
            student.nr_albumu = nr_albumu;
            student.plec = plec;
        }
        static double liczsrednia(student[] student)
        {
            double srednia=0;
            for(int i = 0; i < student.Length; i++)
            {
                srednia+= student[i].ocena;
            }
            return srednia/student.Length;
        }
        static void wyswietlstudenta(student student)
        {
            Console.WriteLine($"Nazwisko: {student.nazwisko}; Nr_albumu: {student.nr_albumu}; " +
                $"Ocena: {student.ocena}; Płeć: {student.plec}");
        }
    }
}