using System;

class Program
{
    // Onluk sayıyı ikilik sayıya çeviren fonksiyon
    static string DecimalToBinary(int decimalNumber)
    {
        if (decimalNumber == 0)
        {
            return "0";
        }

        string binary = "";
        while (decimalNumber > 0)
        {
            int remainder = decimalNumber % 2;
            binary = remainder + binary;
            decimalNumber = decimalNumber / 2;
        }

        return binary;
    }

    static void Main(string[] args)
    {
        // Onluk sayıyı kullanıcıdan al
        Console.Write("Lütfen bir onluk sayı girin: ");
        int decimalNumber = Convert.ToInt32(Console.ReadLine());

        // İkilik sayıya dönüştür
        string binaryNumber = DecimalToBinary(decimalNumber);

        // Sonucu ekrana yazdır
        Console.WriteLine($"İkilik karşılığı: {binaryNumber}");
    }
}
