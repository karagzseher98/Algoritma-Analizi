using System;

class Program
{
    static void Main()
    {
        Console.Write("Faktöriyelini almak istediğiniz sayıyı girin: ");
        int sayi = Convert.ToInt32(Console.ReadLine());

        long sonuc = Faktoriyel(sayi);

        Console.WriteLine($"Faktöriyel({sayi}) = {sonuc}");

        Console.ReadLine();
    }

    static long Faktoriyel(int n)
    {
        if (n == 0 || n == 1)
        {
            return 1;
        }
        else
        {
            return n * Faktoriyel(n - 1);
        }
    }
}
