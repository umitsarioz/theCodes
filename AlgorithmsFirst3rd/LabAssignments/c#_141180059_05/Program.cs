using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoritmalar_lab5_141180059
{
    class Program
    {
        // Oluşturulacak dizinin eleman sayısının belirlenmesi
        // Eleman sayısından kücük olacak sekilde rastgele elemanlar üretilmesi
        // Rastgele üretilen dizinin ekrana yazdırılması
        // Dizinin Quicksort'da sıralanması için kopyalanması.
        // Dizinin counting sort algoritması ile sıralanması
        // Sıralanmış dizinin ekrana yazdırılması
        // Counting sort için çalışma zamanının belirlenmesi
        // Oluşturulan rastgele dizinin QuickSort ile sıralanması
        // QuickSort için çalışma zamanının hesaplanması ve ekrana yazdırılması.
        // Not : Dizinin elemanları dizinin boyutundan büyük olamaz.
          
        static void Main(string[] args)
        {
            // 20 elemanlı bir dizimiz olsun.
            int n = 5; 
            int[] rastgeleDizi = new int[n];
            RandomDiziUret(rastgeleDizi);
            Console.Write("Random üretilmiş "+n +" elemanlı dizi : ");
            DiziyiEkranaYazdir(rastgeleDizi);
            Console.WriteLine();
            int[] Dizi4QuickSort = DiziyiKopyala(rastgeleDizi);

            // Counting sort için sıralanmıs dizi ve sıralanacak elemanların tutulması için iki diziye ihtiyacı var.
            int[] siralanmisDizi = new int[n];
            int[] kopyalanacakYer = new int[n];
            TimeSpan Time4CountingSort = Time_CS(rastgeleDizi, kopyalanacakYer, n);
            Console.Write("\nKopyalancak yer olan dizi:");
            DiziyiEkranaYazdir(kopyalanacakYer);
            Console.Write("\nSıralı Dizi: ");
            siralanmisDizi = kopyalanacakYer;
            DiziyiEkranaYazdir(siralanmisDizi);
            Console.Write("\n\nCounting sort için çalışma zamanı: "+Time4CountingSort);

            TimeSpan Time4QuickSort = Time_QS(Dizi4QuickSort, 0, n - 1);
            Console.WriteLine("\nQuick sort için çalışma zamanı: "+Time4QuickSort);

            Console.ReadKey();
        }
        private static int[] RandomDiziUret(int[] dizi) {
            Random rastgele = new Random();
            for (int i = 0; i < dizi.Length; i++) // Dizi boyutu kadar döndür.
                dizi[i] = rastgele.Next(dizi.Length); // En büyük eleman dizinin son indeksi kadar büyük olabilir.Yani 19.
            return dizi;
        }

        private static void DiziyiEkranaYazdir (int[] dizi){
            foreach (int i in dizi)
                Console.Write(i.ToString()+" " );
            
}
        private static int[] DiziyiKopyala(int[] dizi)
        {
            int n = dizi.Length; // Dizinin eleman sayısını kopylanacak diziye atamak için tutuyorum.
            int[] copyDizi = new int[n];
           for(int i=0;i<n;i++)
                copyDizi[i] = dizi[i];
            return copyDizi;
        }

        private static int[] kantingsort(int[] siralanacakDizi, int[] kopyalanacakYer, int elemanSayisi)
        {
            int[] sayiTutacakDizi = new int[elemanSayisi];

            // Algoritma 1.adım 0 la doldur.
            for (int i = 0; i < elemanSayisi; i++)
                sayiTutacakDizi[i] = 0;
            for (int j = 0; j < elemanSayisi; j++)
            {
                int index = siralanacakDizi[j];
                sayiTutacakDizi[index]+=1;
            }
            for (int i = 1; i < elemanSayisi; i++)
                sayiTutacakDizi[i] = sayiTutacakDizi[i] + sayiTutacakDizi[i - 1];

            // kopyalama işlemini gerçekleştir
            for (int j = elemanSayisi-1; j>=0 ; j--)
            {
                int sayi = siralanacakDizi[j];
                int index = sayiTutacakDizi[sayi] - 1;
                kopyalanacakYer[index] = sayi;
                sayiTutacakDizi[sayi]-= 1;

            }
            Console.Write("\nSayı adetini sayan dizi: ");
            DiziyiEkranaYazdir(sayiTutacakDizi);
                return kopyalanacakYer;
        }
        private static TimeSpan Time_CS(int[] siralanacakDizi, int[] kopyalanacakYer, int elemanSayisi)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Stop();
            kantingsort(siralanacakDizi, kopyalanacakYer, elemanSayisi);
            var elapsedMs = watch.Elapsed;
            return elapsedMs;
        }

        private static void QuickSort_Recursive(int[] dizi, int baslangicIndeksi, int bitisIndeksi) // Dizi,Başlangıç indeksi,Bitiş indeksi
        {
            if (baslangicIndeksi < bitisIndeksi)
            {
                int pivot = Partition(dizi, baslangicIndeksi, bitisIndeksi); // pivot eleman seç 

                // Recursive olarak tekrar quicksort yap ve sırala.
                QuickSort_Recursive(dizi, baslangicIndeksi, pivot - 1);
                QuickSort_Recursive(dizi, pivot + 1, bitisIndeksi);
            }


        }
        private static int Partition(int[] dizi, int baslangicIndeksi, int bitisIndeksi)
        {
            // Pivot eleman seçip , pivottan kücükler solda büyükler sagda olacak sekilde sıralar.
            // Dizinin en son elemanı pivot olarak seçilir.
            int pivot = dizi[bitisIndeksi];
            int i = baslangicIndeksi - 1;

            for (int j = baslangicIndeksi; j < bitisIndeksi; j++)
            {
                if (dizi[j] <= pivot)  // Eğer eleman pivottan kücükse
                {
                    i = i + 1;
                    // swap yap.
                    int gecici = dizi[j];
                    dizi[j] = dizi[i];
                    dizi[i] = gecici;

                }

            }
            // son elemanla pivotu degistir.
            int temp = dizi[bitisIndeksi];
            dizi[bitisIndeksi] = dizi[i + 1];
            dizi[i + 1] = temp;
            return i + 1; // pivotun oldugu indeksi döndür.

        }

        private static TimeSpan Time_QS(int[] dizi, int begin, int end)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Stop();
            QuickSort_Recursive(dizi, begin, end);
            var elapsedMS = watch.Elapsed;
            return elapsedMS;
        }
    }
}
