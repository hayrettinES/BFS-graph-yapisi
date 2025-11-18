using System;

class BFSProjesi
{
    static void Main()
    {
        Console.WriteLine("Düğüm sayısını giriniz: ");
        int dugumSayisi = int.Parse(Console.ReadLine());
        int[,] komsulukMatrisi = new int[dugumSayisi, dugumSayisi];

        Console.WriteLine("Bağlantı durumu girişini yapınız (1: bağlantı var, 0: bağlantı yok).");
        for (int i = 0; i < dugumSayisi; i++)
        {
            for (int j = i; j < dugumSayisi; j++)
            {
                if (i == j)
                {
                    komsulukMatrisi[i, j] = 0;
                }
                else
                {
                    Console.WriteLine("Bağlantı var mı? (Düğüm " + i + " ve Düğüm " + j + "): ");
                    int baglanti = int.Parse(Console.ReadLine());
                    if (baglanti == 1 || baglanti == 0)
                    {
                        komsulukMatrisi[i, j] = baglanti;
                        komsulukMatrisi[j, i] = baglanti;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş. Lütfen 1 (var) veya 0 (yok) giriniz.");
                        j--;
                    }
                }
            }
        }

        Console.WriteLine("\nKomşuluk Matrisi:");
        for (int i = 0; i < dugumSayisi; i++)
        {
            for (int j = 0; j < dugumSayisi; j++)
            {
                Console.Write(komsulukMatrisi[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Başlangıç düğümünü giriniz: ");
        int baslangic = int.Parse(Console.ReadLine());
        BFS(komsulukMatrisi, dugumSayisi, baslangic);
    }

    static void BFS(int[,] matris, int dugumSayisi, int baslangic)
    {
        bool[] ziyaretEdildi = new bool[dugumSayisi];
        int[] kuyruk = new int[dugumSayisi];
        int on = 0, arka = 0;

        ziyaretEdildi[baslangic] = true;
        kuyruk[arka++] = baslangic;

        Console.WriteLine("\nBFS Traversal:");
        while (on < arka)
        {
            int mevcut = kuyruk[on++];
            Console.Write(mevcut + " ");

            for (int i = 0; i < dugumSayisi; i++)
            {
                if (matris[mevcut, i] == 1 && !ziyaretEdildi[i])
                {
                    ziyaretEdildi[i] = true;
                    kuyruk[arka++] = i;
                }
            }
        }
    }
}
