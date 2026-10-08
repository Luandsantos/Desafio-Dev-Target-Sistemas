using System;

public class Desafio3
{
    public static void Main()
    {
        DateTime date1 = new DateTime(2026, 12, 31);
        DateTime dateOnly = date1.Date;
        Console.WriteLine(dateOnly.ToString("d"));
    }
}
