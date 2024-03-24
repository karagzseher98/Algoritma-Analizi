using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 3, 7, 2, 9, 4, 10, 5 }; // Örnek bir dizi

        int maxNumber = FindMax(numbers, 0, numbers.Length - 1); // En büyük sayıyı bul

        Console.WriteLine("Dizideki en büyük sayı: " + maxNumber);
    }

    static int FindMax(int[] arr, int start, int end)
    {
        if (start == end)
        {
            return arr[start];
        }
        else
        {
            int middle = (start + end) / 2;
            int maxLeft = FindMax(arr, start, middle);
            int maxRight = FindMax(arr, middle + 1, end);
            return Math.Max(maxLeft, maxRight);
        }
    }
}
