using System;
using System.Collections.Generic;

namespace PrimAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Graf matrisini tanımla (8 düğüm ve aralarındaki ağırlıklar)
            int[,] graph = new int[,]
            {
                { 0, 4, 0, 0, 0, 0, 0, 8 },
                { 4, 0, 8, 0, 0, 0, 0, 11 },
                { 0, 8, 0, 7, 0, 4, 0, 0 },
                { 0, 0, 7, 0, 9, 14, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1 },
                { 8, 11, 0, 0, 0, 0, 1, 0 }
            };

            int source = 0; // Başlangıç düğümünü tanımla
            List<Edge> mst = Prim(graph, source); // Prim algoritmasını kullanarak Minimum Spanning Tree'yi hesapla

            // Minimum Spanning Tree'yi yazdır
            Console.WriteLine("Minimum Çevrimli Ağ:");
            foreach (Edge edge in mst)
            {
                Console.WriteLine(edge.X + " - " + edge.Y + ": " + edge.Weight);
            }
        }

        // Prim algoritması
        static List<Edge> Prim(int[,] graph, int source)
        {
            int V = graph.GetLength(0); // Düğüm sayısı
            bool[] visited = new bool[V]; // Ziyaret edilen düğümleri tutar
            int[] key = new int[V]; // Minimum ağırlıkları tutar
            List<Edge> mst = new List<Edge>(); // Minimum Spanning Tree'yi tutar

            // Başlangıçta tüm düğümleri ziyaret edilmemiş ve ağırlıkları sonsuz olarak ayarla
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                visited[i] = false;
            }

            key[source] = 0; // Başlangıç düğümünün ağırlığını 0 yap

            // V - 1 kez döngü, çünkü MST'nin V - 1 kenarı vardır
            for (int i = 0; i < V - 1; i++)
            {
                int minKey = int.MaxValue;
                int u = -1;

                // Ziyaret edilmemiş düğümler arasından minimum ağırlıklı olanı seç
                for (int j = 0; j < V; j++)
                {
                    if (!visited[j] && key[j] < minKey)
                    {
                        minKey = key[j];
                        u = j;
                    }
                }

                visited[u] = true; // Seçilen düğümü ziyaret edilmiş olarak işaretle

                // Seçilen düğümün komşularını güncelle
                for (int j = 0; j < V; j++)
                {
                    if (graph[u, j] != 0 && !visited[j] && graph[u, j] < key[j])
                    {
                        key[j] = graph[u, j];
                        mst.Add(new Edge(u, j, graph[u, j])); // MST'ye kenarı ekle
                    }
                }
            }

            return mst; // Hesaplanan Minimum Spanning Tree'yi döndür
        }
    }

    // Kenar sınıfı
    class Edge
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Weight { get; set; }

        public Edge(int x, int y, int weight)
        {
            X = x;
            Y = y;
            Weight = weight;
        }
    }
}
