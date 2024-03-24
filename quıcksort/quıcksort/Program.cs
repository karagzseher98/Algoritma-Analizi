using System;

class QuickSort
{
    // Dizi içindeki elemanları parçalamak için yardımcı bir yöntem.
    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high]; // Pivot, dizinin son elemanı olarak seçilir.
        int i = low - 1; // Index'i belirlemek için bir değişken tanımlanır.

        // Diziyi tarar.
        for (int j = low; j < high; j++)
        {
            // Eğer mevcut eleman pivot'tan küçükse:
            if (array[j] < pivot)
            {
                i++; // Index'i arttırır.
                // Elemanları swap etmek için geçici bir değişken kullanır.
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Pivot'ı doğru konuma yerleştirir.
        int temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;

        return i + 1; // Pivot'ın son konumunu döndürür.
    }

    // Diziyi sıralamak için ana yöntem.
    static void Sort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(array, low, high); // Pivot'ın konumunu alır.

            // Her iki tarafı da sıralamak için rekürsif olarak çağrılır.
            Sort(array, low, pi - 1);
            Sort(array, pi + 1, high);
        }
    }

    // Diziyi ekrana yazdırmak için yöntem.
    static void PrintArray(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(array[i] + " ");
        Console.WriteLine();
    }

    public static void Main()
    {
        int[] array = { 23, 398, 34, 100, 57, 67, 55, 320 }; // Test için örnek dizi.
        int n = array.Length;

        Console.WriteLine("Veri dizisi:");
        PrintArray(array);

        Sort(array, 0, n - 1); // Quick sort algoritmasını uygular.

        Console.WriteLine("Sıralanmış dizi:");
        PrintArray(array);
    }
}
