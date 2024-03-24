using System;

class Program
{
    static int N = 4; // Şehir sayısı
    static int[,] distanceMatrix = new int[N, N]; // Şehirler arasındaki mesafeleri tutan matris

    // Verilen şehirler arasındaki mesafeleri kullanarak tüm permütasyonları deneyen rekürsif fonksiyon
    static int TSP(int[] path, int position, int visited, int currentCost)
    {
        // Tüm şehirleri ziyaret ettik mi?
        if (visited == (1 << N) - 1)
            return currentCost + distanceMatrix[position, 0]; // Dönüş yolunu ekleyip maliyeti döndür

        // En iyi tur maliyetini başlangıçta sonsuz olarak ayarla
        int minCost = int.MaxValue;

        // Diğer şehirleri ziyaret et
        for (int nextCity = 0; nextCity < N; nextCity++)
        {
            // Eğer henüz ziyaret edilmediyse
            if ((visited & (1 << nextCity)) == 0)
            {
                // Yeni tur maliyetini hesapla
                int newCost = currentCost + distanceMatrix[position, nextCity];

                // Rekürsif olarak diğer şehirleri ziyaret et
                int updatedVisited = visited | (1 << nextCity);
                int[] newPath = (int[])path.Clone();
                newPath[position] = nextCity;

                minCost = Math.Min(minCost, TSP(newPath, nextCity, updatedVisited, newCost));
            }
        }

        return minCost;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Lütfen şehirler arasındaki mesafeleri girin:");

        // Şehirler arasındaki mesafeleri kullanıcıdan alın
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"Şehir {i} ile {j} arasındaki mesafe: ");
                distanceMatrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Yolculuğun başlangıç noktası
        int[] path = new int[N];
        int initialCity = 0;
        int initialVisited = 1 << initialCity;
        int initialCost = 0;
        path[0] = initialCity;

        // Gezgin satıcı problemi çözülüyor
        int minCost = TSP(path, initialCity, initialVisited, initialCost);

        // En kısa tur ve toplam maliyet ekrana yazdırılır
        Console.WriteLine($"En kısa tur maliyeti: {minCost}");
    }
}
