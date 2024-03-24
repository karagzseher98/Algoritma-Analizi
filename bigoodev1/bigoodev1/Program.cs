using System;

class Program
{
    static void Main(string[] args)
    {
        // Matris boyutunu belirle
        int satir = 3;
        int sutun = 3;

        // İki matris tanımla
        int[,] matris1 = new int[satir, sutun];
        int[,] matris2 = new int[satir, sutun];
        int[,] sonucMatrisi = new int[satir, sutun];

        // Matrisleri rastgele değerlerle doldur
        Random rastgele = new Random();
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                matris1[i, j] = rastgele.Next(10);
                matris2[i, j] = rastgele.Next(10);
            }
        }

        // Matrisleri çarp
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                for (int k = 0; k < sutun; k++)
                {
                    sonucMatrisi[i, j] += matris1[i, k] * matris2[k, j];
                }
            }
        }

        // Sonuçları yazdır
        Console.WriteLine("Matris 1:");
        MatrisiYazdir(matris1);
        Console.WriteLine("Matris 2:");
        MatrisiYazdir(matris2);
        Console.WriteLine("Çarpım Matrisi:");
        MatrisiYazdir(sonucMatrisi);

        Console.ReadLine();
    }

    // Matrisi ekrana yazdırmak için yardımcı fonksiyon
    static void MatrisiYazdir(int[,] matris)
    {
        int satir = matris.GetLength(0);
        int sutun = matris.GetLength(1);

        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                Console.Write(matris[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
