using System;
using System.Collections.Generic;

class Program
{
    // Bu fonksiyon grafikteki en kısa yolları bulmak için Dijkstra algoritmasını kullanır.
    static int[] Dijkstra(int[,] graph, int source)
    {
        int verticesCount = graph.GetLength(0); // Grafikteki düğüm sayısı
        int[] distances = new int[verticesCount]; // Kaynak düğümden diğer düğümlere olan mesafeleri saklar
        bool[] shortestPathTreeSet = new bool[verticesCount]; // En kısa yol ağacında olup olmadığını saklar

        // Tüm mesafeleri sonsuz olarak başlat
        for (int i = 0; i < verticesCount; i++)
        {
            distances[i] = int.MaxValue;
            shortestPathTreeSet[i] = false;
        }

        // Kaynak düğümün mesafesi sıfır olarak başlatılır
        distances[source] = 0;

        // Tüm düğümler için hesaplama yapılır
        for (int count = 0; count < verticesCount - 1; count++)
        {
            // Henüz işlenmemiş düğümler arasından minimum mesafeye sahip olanı seç
            int u = MinimumDistance(distances, shortestPathTreeSet, verticesCount);

            // Seçilen düğümün işlenmiş olduğunu işaretle
            shortestPathTreeSet[u] = true;

            // Seçilen düğümün komşuları için mesafeleri güncelle
            for (int v = 0; v < verticesCount; v++)
            {
                // Eğer düğüm v işlenmemişse, u'dan v'ye bir kenar varsa ve u'dan v'ye olan
                // toplam mesafe, bilinen mesafeden daha kısaysa, mesafeyi güncelle
                if (!shortestPathTreeSet[v] && graph[u, v] != 0 && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                }
            }
        }

        return distances; // Kaynak düğümden tüm düğümlere olan en kısa mesafeleri döndür
    }

    // Henüz işlenmemiş düğümler arasından minimum mesafeye sahip olan düğümü seçen yardımcı fonksiyon
    static int MinimumDistance(int[] distances, bool[] shortestPathTreeSet, int verticesCount)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < verticesCount; v++)
        {
            if (shortestPathTreeSet[v] == false && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    static void Main(string[] args)
    {
        int[,] graph = {
            { 0, 10, 0, 0, 0, 0 },
            { 10, 0, 5, 0, 0, 0 },
            { 0, 5, 0, 20, 1, 0 },
            { 0, 0, 20, 0, 2, 1 },
            { 0, 0, 1, 2, 0, 3 },
            { 0, 0, 0, 1, 3, 0 }
        };

        int source = 0; // Başlangıç düğümü

        // Dijkstra algoritmasını kullanarak en kısa yolları hesapla
        int[] distances = Dijkstra(graph, source);

        // Sonuçları yazdır
        Console.WriteLine("Düğüm {0} için en kısa yollar:", source);
        for (int i = 0; i < distances.Length; i++)
        {
            Console.WriteLine("Düğüm {0} -> Düğüm {1} = {2}", source, i, distances[i]);
        }
    }
}
