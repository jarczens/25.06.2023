using System;

struct Student
{
    public string nazwisko;
    public int nrAlbumu;
    public double ocena;
    public Plec plec;
}

enum Plec
{
    Kobieta,
    Mezczyzna
}

class Program
{
    static void WypelnijStudenta(ref Student student, string nazwisko, int nrAlbumu, double ocena, Plec plec)
    {
        student.nazwisko = nazwisko;
        student.nrAlbumu = nrAlbumu;

        if (ocena < 2.0)
            student.ocena = 2.0;
        else if (ocena > 5.0)
            student.ocena = 5.0;
        else
            student.ocena = ocena;

        student.plec = plec;
    }

    static void WyswietlStudenta(Student student)
    {
        Console.WriteLine($"Nazwisko: {student.nazwisko}, Nr albumu: {student.nrAlbumu}, Ocena: {student.ocena:F1}, Płeć: {student.plec}");
    }

    static double ObliczSrednia(Student[] grupa)
    {
        if (grupa.Length == 0)
            return 0.0;

        double sumaOcen = 0.0;
        foreach (var student in grupa)
        {
            sumaOcen += student.ocena;
        }

        return sumaOcen / grupa.Length;
    }

    static void Main(string[] args)
    {
        Student[] grupa = new Student[5];

        WypelnijStudenta(ref grupa[0], "Franciszek", 1234, 4.5, Plec.Mezczyzna);
        WypelnijStudenta(ref grupa[1], "Dębicka", 5678, 3.5, Plec.Kobieta);
        WypelnijStudenta(ref grupa[2], "Kaczyński", 9123, 2.0, Plec.Mezczyzna);
        WypelnijStudenta(ref grupa[3], "Dąbrowska", 4567, 3.0, Plec.Kobieta);
        WypelnijStudenta(ref grupa[4], "Bukszpan", 7890, 5.5, Plec.Kobieta);

        foreach (var student in grupa)
        {
            WyswietlStudenta(student);
        }

        double srednia = ObliczSrednia(grupa);

        Console.WriteLine($"Średnia ocen w grupie: {srednia:F1}");
    }
}