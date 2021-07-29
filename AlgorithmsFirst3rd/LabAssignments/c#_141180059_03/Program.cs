using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_odev3_141180059_last
{
    class Program
    {
        // Rastgele 20 elemanlı 0-100 arası dizi oluşturma
        // Diziyi Ekrana yazdırma
        // Diziyi Kopyalama
        // Insertion Sort ile çöz ve çalışma zamanını hesapla
        // En kück sayıyı bulma
        // Merge sort- Iterative  ile çöz ve çalışma zamanını hesapla
        /* Merge fonksiyonu ortak değil iterative ve recursive için farklı merge'ler oluştur yoksa aritmetik taşmaya yakalanıyorum, iterative olarak böl.*/
        // Merge sort - Recursive ile çöz ve çalışma zamanını hesapla
        /* Mergesort-> Mergesort parçalara ayır ve sonra merge et.*/

        static int adimsayisi_iterative = 0;
        static int adimsayisi_recursive = 1;
        static void Main(string[] args)
        {
            int[] randomDizi = RandomDiziUret(20);
            Console.Write("Rastgele Dizi: "); DiziyiYazdir(randomDizi); Console.WriteLine(); // Rastgele diziyi ekrana yazdırıyorum.
            int n = randomDizi.Length;
            int[] siraliDizi = new int[n]; // Iterative çözümde aritmetik taşma olmaması için başka bir dizide tutup sıralatıyorum.

            Console.WriteLine("\nINSERTION SORT\n--------------");
            int[] rd_InsertionSort = DiziKopyala(randomDizi);
            Console.WriteLine("\nInsertion Sort için Çalışma Zamanı: " + Time_IS(rd_InsertionSort));

            Console.WriteLine("\nMERGE SORT-ITERATIVE\n-----------------------");
            int[] rd_MergeSort_Iterative = DiziKopyala(randomDizi);
            Console.WriteLine("\nMerge Sort Iterative çözüm için Çalışma Zamanı: " + Time_MergeSort_Iterative(rd_MergeSort_Iterative, n, siraliDizi));

           
            Console.WriteLine("\nMERGE SORT-RECURSIVE\n----------------------");
            int[] rd_MergeSort_Recursive = DiziKopyala(randomDizi);
            //MergeSort_Recursive(rd_MergeSort_Recursive, 0, rd_MergeSort_Recursive.Length - 1); // İlk indeks = 0 , sonIndeks= dizi boyutundan 1 az.
            Console.WriteLine("\nMerge Sort Recursive çözüm için Çalışma Zamanı: " + Time_MS_Rc(rd_MergeSort_Recursive, 0, rd_MergeSort_Recursive.Length - 1));

            Console.Write("\nSıralanmış Dizi: ");
            DiziyiYazdir(rd_MergeSort_Iterative);
            Console.ReadKey();
        }
        private static int[] RandomDiziUret(int elemanSayisi)
        {
            int[] rDizi = new int[elemanSayisi]; 
            Random rastgele = new Random();
            for (int i = 0; i < elemanSayisi; i++)
                rDizi[i] = rastgele.Next(101);
            return rDizi;
        }
        private static void DiziyiYazdir(int[] dizi)
        {
            for (int i = 0; i < dizi.Length; i++)
                Console.Write(dizi[i] + " ");
        }
        private static int[] DiziKopyala(int[] dizi)
        {
            // İlk oluşturduğum random diziyi elimde tutmak için kullanıyorum.Ki performanslarını karşılaştırabileyim.
            int[] copyDizi = new int[dizi.Length];
            for (int i = 0; i < dizi.Length; i++)
                copyDizi[i] = dizi[i];
            return copyDizi;
        }
        private static void InsertionSort(int[] dizi)
        {
            for (int i = 0; i < dizi.Length - 1; i++)
            {
                int gecerliIndex = i + 1; // Dizinin ikinci elemanı sabit alınrak solunakiyle karsılastırılır.Ve bu böyle devam eder.
                while (gecerliIndex > 0 && dizi[gecerliIndex - 1] > dizi[gecerliIndex]) // While içerisinde swap işlemi gerçekleştiriyorum.
                {
                    int geciciIndex = dizi[gecerliIndex - 1];
                    dizi[gecerliIndex - 1] = dizi[gecerliIndex];
                    dizi[gecerliIndex] = geciciIndex;
                    gecerliIndex--;
                }
                Console.Write("{0}.adım: ", i + 1);
                DiziyiYazdir(dizi);
                Console.WriteLine(); // Bir satır boşluk.
            }
        }
        private static TimeSpan Time_IS(int[] dizi)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            InsertionSort(dizi);
            watch.Stop();
            var elapsedMs = watch.Elapsed;
            return elapsedMs;

        }

        private static void DiziyiTasi(int[] siraliDizi, int[] asilDizi, int n){
            // Iterative çözüm de aritmetik overflow'a takılmamak için tanımladım.
            for (int i = 0; i < n; i++)
                asilDizi[i] = siraliDizi[i];
        }
        private static void MergeSort_Iterative(int[]asilDizi,int n,int[]siraliDizi) { // Asıl dizimizi,dizi boyutunu,sıralanaacak dizinin tutulacağı dizi
            int mevcutBoyut; // 1.2.4.8.16...
            int i; // soldan başlangıç indeksi
            Console.WriteLine("<!--- ilk "+n/2+" adımda diziyi  ikili gruplar ile alıp doldurur sonra sıralar ---!>\n");
            for (mevcutBoyut = 1; mevcutBoyut < n; mevcutBoyut = 2 * mevcutBoyut)
            {
                for (i = 0; i < n; i = i + 2 * mevcutBoyut)
                {
                    Merge_Iterative(asilDizi, i, Math.Min(i + mevcutBoyut, n), Math.Min(i + 2 * mevcutBoyut, n), siraliDizi);
                    Console.Write(adimsayisi_iterative + ".adım: ");
                    DiziyiYazdir(siraliDizi);
                    Console.WriteLine();
                    adimsayisi_iterative++;
                }
                DiziyiTasi(siraliDizi,asilDizi, n);

            }
            Console.Write(adimsayisi_iterative+".adim:");
            DiziyiYazdir(asilDizi);
            Console.WriteLine();
        }
        private static TimeSpan Time_MergeSort_Iterative(int[] asilDizi, int n, int[] siraliDizi)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Stop();
            MergeSort_Iterative(asilDizi, n, siraliDizi);
            var elapsedMs = watch.Elapsed;
            return elapsedMs;
        }
        static void Merge_Iterative(int[] asilDizi, int solIndeks, int sagIndeks, int sonIndeks, int[] siraliDizi)
        {
            int i = solIndeks; // 
            int j = sagIndeks; // 
            int k; // gecici indeks.
            for (k = solIndeks; k < sonIndeks; k++)
            {
                if (i < sagIndeks && (j >= sonIndeks || asilDizi[i] <= asilDizi[j]))
                {
                    siraliDizi[k] = asilDizi[i];
                    i++;
                }
                else
                {
                    siraliDizi[k] = asilDizi[j];
                    j++;
                }
            }
        }

        private static void MergeSort_Recursive(int[] dizi, int p, int r) //p ilk indeks , r son indeks
        {
         
            if (p < r) // ilk indeks kücükse sondan calıstır.
            {

                int q = (p + r) / 2; // orta elemanı bulunur.
                MergeSort_Recursive(dizi, p, q);
                MergeSort_Recursive(dizi, q + 1, r);
                Merge_Recursive(dizi, p, q, r);
            }
        }
        private static TimeSpan Time_MS_Rc(int[] dizi, int p, int r)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Stop();
            MergeSort_Recursive(dizi, p, r);
            var elapsedMS = watch.Elapsed;
            return elapsedMS;
        }
        private static void Merge_Recursive(int[] dizi, int p, int q, int r)
        {
            //p: ilk ideks , q:orta indeks , r:son/sağ indeks 
            // dersin slaytını ref. aldım.i,j=1 de arraybound exception'a takıldım 0 la tanımladım.
            int n1 = q - p + 1; // Sol alt dizinin eleman sayısı
            int n2 = r - q; //sağ alt dizinin eleman sayısı

            int[] sol = new int[n1];
            int[] sag = new int[n2];

            int i, j, k; // Alt dizileri doldur. i:sol altdizi, j:sag alt dizi, k:gecici indis.
            for (i = 0; i < n1; i++)
                sol[i] = dizi[p + i];
            for (j = 0; j < n2; j++)
                sag[j] = dizi[q + j + 1];

            i = 0;
            j = 0;
            k = p; // gecici olarak indis belirlenir.İlk indeksimiz k=p yani 0 olarak verilir.
            // Sol alt dizinin elman sayısı indisinden büyükse ve aynı sekilde sag içinde varsa yerleştirmeye başla.
            while (i < n1 && j < n2)
            {
                // Sol altdizideki deger sag'dakinden kücük veya eşitse sola yerleştir.Değilse sağa yerleştir.Sonra her sefernde gecici dizimizin indisini de bir arttır.
                if (sol[i] <= sag[j])
                {
                    dizi[k] = sol[i];
                    i++;
                }
                else
                {
                    dizi[k] = sag[j];
                    j++;
                }
                k++;
            }
            // Eğer hala dışarıda eleman varsa onları yerleştir.Önce sol alt dizi sonra sağ.
            while (i < n1)
            {
                dizi[k] = sol[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                dizi[k] = sag[j];
                j++;
                k++;
            }
            Console.Write(adimsayisi_recursive + ".adım: ");
            DiziyiYazdir(dizi);
            Console.WriteLine();
            adimsayisi_recursive++;
        }
    }
}
