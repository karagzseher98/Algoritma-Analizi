using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 3, 7, 2, 9, 4, 10, 5 }; // Örnek bir dizi

        int maxNumber = FindMax(numbers); // En büyük sayıyı bul

        Console.WriteLine("Dizideki en büyük sayı: " + maxNumber);
    }

    static int FindMax(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("Dizi boş olamaz veya null olamaz.");
        }

        int max = arr[0]; // Başlangıçta ilk elemanı en büyük olarak kabul et

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i]; // Eğer şu anki eleman mevcut maksimumdan büyükse, onu yeni maksimum yap
            }
        }

        return max;
    }
}
