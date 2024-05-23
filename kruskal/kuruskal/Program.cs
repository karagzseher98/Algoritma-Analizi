using System;
using System.Collections.Generic;

namespace KruskalAlgorithm
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

            int V = graph.GetLength(0); // Düğüm sayısını al
            List<Edge> edges = new List<Edge>();

            // Grafın tüm kenarlarını edge listesine ekle
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (graph[i, j] != 0)
                    {
                        edges.Add(new Edge(i, j, graph[i, j]));
                    }
                }
            }

            // Kenarları ağırlıklarına göre sırala
            edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));

            // Union-Find yapısını başlat
            UnionFind uf = new UnionFind(V);
            List<Edge> mst = new List<Edge>();

            // Kenarları sırayla kontrol et
            foreach (Edge edge in edges)
            {
                int x = uf.Find(edge.X);
                int y = uf.Find(edge.Y);

                // Döngü oluşturmayacaksa kenarı minimum çevrimli ağa ekle
                if (x != y)
                {
                    mst.Add(edge);
                    uf.Union(x, y);
                }
            }

            // Minimum çevrimli ağdaki kenarları yazdır
            Console.WriteLine("Minimum Çevrimli Ağ:");
            foreach (Edge edge in mst)
            {
                Console.WriteLine(edge.X + " - " + edge.Y + ": " + edge.Weight);
            }
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

    // Union-Find (Disjoint Set) sınıfı
    class UnionFind
    {
        private int[] parent;
        private int[] rank;

        // Union-Find yapısını başlat
        public UnionFind(int size)
        {
            parent = new int[size];
            rank = new int[size];

            // Her düğümü kendi ebeveyni olarak ayarla ve rank'ı 1 yap
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
        }

        // Bir düğümün kökünü bul
        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]); // Path compression
            }

            return parent[x];
        }

        // İki kümenin birleştirilmesi
        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                // Rank'a göre birleşim yap
                if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                    rank[rootY] += rank[rootX];
                }
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX] += rank[rootY];
                }
            }
        }
    }
}
