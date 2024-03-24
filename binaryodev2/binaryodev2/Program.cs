using System;

class Program
{
    // Onluk sayıyı ikilik sayıya çeviren fonksiyon (recursive)
    static string OnlukToIkilik(int onlukSayi)
    {
        if (onlukSayi == 0)
        {
            return "0";
        }
        else
        {
            return OnlukToIkilik(onlukSayi / 2) + (onlukSayi % 2).ToString();
        }
    }

    static void Main(string[] args)
    {
        try
        {
            // Onluk sayıyı kullanıcıdan al
            Console.Write("Lütfen bir onluk sayı giriniz: ");
            int onlukSayi = Convert.ToInt32(Console.ReadLine());

            if (onlukSayi < 0)
            {
                throw new Exception("Negatif sayılar dönüştürülemez.");
            }

            // İkilik sayıya dönüştür
            string ikilikSayi = OnlukToIkilik(onlukSayi);

            // Sonucu ekrana yazdır
            Console.WriteLine($"İkilik karşılığı: {ikilikSayi}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Geçersiz bir sayı girdiniz.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
