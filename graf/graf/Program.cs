using System;

class Program
{
    // Maksimum düğüm sayısı için sabit tanımlama
    const int MAX = 10;

    // Bitişiklik matrisini oluşturan fonksiyon
    static void BuildAdjacencyMatrix(int[,] adj, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // Kullanıcıdan giriş alınması
                Console.Write($"{i} ile {j} arasında kenar var ise 1 yoksa 0 giriniz: ");
                adj[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    // Outdegree hesaplayan fonksiyon
    static int OutDegree(int[,] adj, int x, int n)
    {
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (adj[x, i] == 1)
            {
                count++;
            }
        }
        return count;
    }

    // Indegree hesaplayan fonksiyon
    static int InDegree(int[,] adj, int x, int n)
    {
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (adj[i, x] == 1)
            {
                count++;
            }
        }
        return count;
    }

    // Ana program
    static void Main()
    {
        int[,] adj = new int[MAX, MAX];
        int node, n;

        // Kullanıcıdan maksimum düğüm sayısını alma
        Console.Write($"Graph için maksimum düğüm sayısını giriniz (Max= {MAX}): ");
        n = int.Parse(Console.ReadLine());

        // Bitişiklik matrisini oluşturma
        BuildAdjacencyMatrix(adj, n);

        // Her bir düğüm için Indegree ve Outdegree'yi hesaplayıp ekrana yazdırma
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{i} Indegree düğüm sayısı {InDegree(adj, i, n)} dır");
            Console.WriteLine($"{i} Outdegree düğüm sayısı {OutDegree(adj, i, n)} dır");
        }
    }
}
