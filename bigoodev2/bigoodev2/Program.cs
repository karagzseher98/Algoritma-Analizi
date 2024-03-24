using System;

class MatrisCarpimi
{
    static int[,] MatrisleriCarp(int[,] mat1, int[,] mat2)
    {
        int satirSayisi1 = mat1.GetLength(0);
        int sutunSayisi1 = mat1.GetLength(1);
        int satirSayisi2 = mat2.GetLength(0);
        int sutunSayisi2 = mat2.GetLength(1);

        // İki matrisin iç boyutları eşleşmiyorsa çarpılamaz.
        if (sutunSayisi1 != satirSayisi2)
            throw new ArgumentException("Matrisler çarpılamaz. İç boyutlar eşleşmelidir.");

        // Sonuç matrisi için bellekte yer ayarla.
        int[,] sonuc = new int[satirSayisi1, sutunSayisi2];

        // Recursive çarpma fonksiyonunu çağır.
        RecursiveCarp(mat1, mat2, sonuc, 0, 0, 0, 0, 0);

        return sonuc;
    }

    static void RecursiveCarp(int[,] mat1, int[,] mat2, int[,] sonuc, int mat1Satir, int mat1Sutun, int mat2Satir, int mat2Sutun, int toplam)
    {
        // Matrisin sonuna gelindiğinde işlemi bitir.
        if (mat1Satir >= mat1.GetLength(0))
            return;

        // İkinci matrisin son sütununa ulaştığında toplamı sonuç matrisine ekle ve sıfırla, sonra bir sonraki hücreye geç.
        if (mat2Sutun >= mat2.GetLength(1))
        {
            sonuc[mat1Satir, mat1Sutun] = toplam;
            toplam = 0;
            mat2Sutun = 0;
            mat2Satir++;
            RecursiveCarp(mat1, mat2, sonuc, mat1Satir, mat1Sutun + 1, mat2Satir, mat2Sutun, toplam);
            return;
        }

        // İkinci matrisin son satırına ulaştığında bir sonraki satıra geç.
        if (mat2Satir >= mat2.GetLength(0))
        {
            mat2Satir = 0;
            mat1Sutun++;
            RecursiveCarp(mat1, mat2, sonuc, mat1Satir + 1, mat1Sutun, mat2Satir, mat2Sutun, toplam);
            return;
        }

        // Toplamı güncelle.
        toplam += mat1[mat1Satir, mat2Satir] * mat2[mat2Satir, mat2Sutun];
        RecursiveCarp(mat1, mat2, sonuc, mat1Satir, mat1Sutun, mat2Satir + 1, mat2Sutun, toplam);
    }

    static void Main(string[] args)
    {
        int[,] matris1 = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] matris2 = { { 7, 8 }, { 9, 10 }, { 11, 12 } };

        int[,] sonuc = MatrisleriCarp(matris1, matris2);

        Console.WriteLine("Sonuç Matrisi:");

        for (int i = 0; i < sonuc.GetLength(0); i++)
        {
            for (int j = 0; j < sonuc.GetLength(1); j++)
            {
                Console.Write(sonuc[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
