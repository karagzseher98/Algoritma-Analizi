using System;

class Program
{
    static int N = 4; // Şehir sayısı

    // Verilen şehirler arasındaki mesafeleri tutan matris
    static int[,] distanceMatrix = new int[N, N];

    // Bellman-Held-Karp algoritması kullanılarak en kısa turu bulan fonksiyon
    static int TSP(int[,] graph)
    {
        int n = graph.GetLength(0);
        int[,] dp = new int[1 << n, n];
        const int INF = int.MaxValue / 2;

        for (int i = 0; i < (1 << n); i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i, j] = INF;
            }
        }

        dp[1, 0] = 0;

        for (int mask = 1; mask < (1 << n); mask += 2)
        {
            for (int u = 1; u < n; u++)
            {
                if ((mask & (1 << u)) > 0)
                {
                    for (int v = 0; v < n; v++)
                    {
                        if ((mask & (1 << v)) > 0)
                        {
                            dp[mask, u] = Math.Min(dp[mask, u], dp[mask ^ (1 << u), v] + graph[v, u]);
                        }
                    }
                }
            }
        }

        int minTourCost = INF;
        for (int i = 1; i < n; i++)
        {
            minTourCost = Math.Min(minTourCost, dp[(1 << n) - 1, i] + graph[i, 0]);
        }

        return minTourCost;
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

        // Gezgin satıcı problemi çözülüyor
        int minCost = TSP(distanceMatrix);

        // En kısa tur ve toplam maliyet ekrana yazdırılır
        Console.WriteLine($"En kısa tur maliyeti: {minCost}");
    }
}
