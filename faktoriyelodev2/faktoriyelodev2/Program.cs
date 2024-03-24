using System;

class Faktoriyel
{
    static int FaktoriyelHesapla(int n)
    {
        // Sonuç için bir değişken oluştur
        int sonuc = 1;

        // 1'den n'e kadar olan sayıları çarp
        for (int i = 2; i <= n; i++)
        {
            sonuc *= i;
        }

        return sonuc;
    }

    static void Main(string[] args)
    {
        // Kullanıcıdan faktoriyeli hesaplanacak sayıyı al
        Console.Write("Faktoriyeli hesaplanacak sayıyı girin: ");
        int sayi = Convert.ToInt32(Console.ReadLine());

        // Faktoriyeli hesapla ve ekrana yazdır
        int faktoriyel = FaktoriyelHesapla(sayi);
        Console.WriteLine($"{sayi}! = {faktoriyel}");
    }
}
