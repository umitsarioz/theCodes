using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoritmalar_lab_4_141180059
{
    class Program
    {/*
       1) Aşağıda verilen sayı dizilerini quick sort ve merge sort algoritmalarına göre sıralayan kodu yazınız. 
       2 ayrı fonksiyon olarak yazın.  Çalışma zamanını hesaplayınız.
      a) Sıralanmamış dizi: 10,12,25,13,14,99,34,7,6,17,56
      İpucu: Bu dizide ortadaki sayı en büyük sayıdır bunun quicksort’un çalışma zamanına etkisini araştırınız.
      (Bu araştırmayı ödev olarak teslim etmeyeceksiniz.Sadece kodları göndermeniz yeterlidir.)

      // Ekran çıktısı: //
      Sıralanmamış dizi:
      Sıralanmış dizi:
      Quicksort çalışma zamanı:
      Merge sort çalışma zamanı:

      2) Elemanları(0 ile 100 arasında olmak üzere) rastgele üretilen diziler oluşturun.Program aşağıdaki adımları yapmalıdır.
      a) Eleman sayısı 30 olan 100 adet rastgele oluşturulan dizi için; quick sort, merge sort ve 
      insertion sort algoritmaları uygulanıp çalışma sürelerinin ortalaması hesaplanacaktır.
      Quicksort zaman karmaşıklığı: nlogn (n eleman sayısı)
      Mergesort zaman karmaşıklığı: nlogn
      İnsertion sort zaman karmaşıklığı: n^2
      Dolayısıyla ortalama çalışma süreleri bu değerlere yakın çıkması gerekmektedir.
      30 eleman için;
      Ortalama insertion sort çalışma süresi / Ortalama Quick sort çalışma süresi  = n^2/nlogn=44 çıkması beklenmektedir.
      Not: Bu değer çıkmıyorsa kodunuz yanlış anlamına gelmemektedir.Sayılar rastgele üretilmektedir ve 
      zaman karmaşıklığının en kötü en iyi durumları mevcuttur. İnsertion sort için en iyi çalışma zamanı n’dir(dizi sıralı ise). 
      Quick sort için en kötü çalışma zamanı n^2’dir.

      // Ekran çıktısı: //
      Ortalama merge sort çalışma süresi:
      Ortalama quick sort çalışma süresi:
      Ortalama insertion sort çalışma süresi:
      Ortalama insertion sort çalışma süresi / Ortalama Quick sort çalışma süresi: 
      
         */

        /*
         * İlk Soru:
         1- Merge Sort algoritması yazılacak
         2- Quick sort algoritması yazılacak
         3- Algoritmaların çalışma zamanları hesaplanacak
         4- Soruda verilen diziyi ve sayıların yerlerini değiştirerek çalışma zamanlarını tekrar hesaplayarak çalışma zamanlarını karşılaştır.
         
         * İkinci Soru:
         1- Rastgele dizi oluştur.Elemanlar 0-100 arasında ve 30 elemanlı.
         2- Diziyi ekrana yazdır.
         3- Dizileri insertion sort,merge sort ve quick sort için kopyala.
         4- Dizileri gerekli algoritmalara göre sırala.
         5- Ortalama çalışma zamanlarını hesapla
         6- Kontrolleri gerçekleştir.

             */
        static void Main(string[] args)
        {
            //1.soru 
            /*
            int[] unorderedArray = { 10, 12, 25, 13, 14, 99, 34, 7, 6, 17, 56 };
            int[] cp1 = DiziKopyala(unorderedArray);
            int[] unorderedArray_sonda = { 10, 12, 25, 13, 14, 56, 34, 7, 6, 17, 99 };
            int[] cp2 = DiziKopyala(unorderedArray_sonda);
            int[] unorderedArray_basta = { 99, 12, 25, 13, 14, 10, 34, 7, 6, 17, 56 };
            int[] cp3 = DiziKopyala(unorderedArray_basta);
            int c = unorderedArray.Length; // dzi boyutu
            Console.WriteLine("En büyük eleman ORTADA olursa:\n");
            Console.Write("Sıralanmamış Dizi:"); DiziyiYazdir(unorderedArray); Console.WriteLine();
            Console.Write("Sıralanmış Dizi:"); QuickSort_Recursive(unorderedArray, 0, c - 1); DiziyiYazdir(unorderedArray); Console.WriteLine();
            Console.Write("QuickSort Çalışma Zamanı:"); Console.WriteLine(Time_QS(unorderedArray, 0, c - 1));
            Console.Write("MergeSort Çalışma Zamanı:"); Console.WriteLine(Time_MS(cp1, 0, c - 1));

            Console.WriteLine("\nEn büyük eleman SONDA olursa:\n");
            Console.Write("Sıralanmamış Dizi:"); DiziyiYazdir(unorderedArray_sonda); Console.WriteLine();
            Console.Write("Sıralanmış Dizi:"); QuickSort_Recursive(unorderedArray_sonda, 0, c - 1); DiziyiYazdir(unorderedArray_sonda); Console.WriteLine();
            Console.Write("QuickSort Çalışma Zamanı:"); Console.WriteLine(Time_QS(unorderedArray_sonda, 0, c - 1));
            Console.Write("MergeSort Çalışma Zamanı:"); Console.WriteLine(Time_MS(cp2, 0, c - 1));

            Console.WriteLine("\nEn büyük eleman BAŞTA olursa:\n");
            Console.Write("Sıralanmamış Dizi:"); DiziyiYazdir(unorderedArray_basta); Console.WriteLine();
            Console.Write("Sıralanmış Dizi:"); QuickSort_Recursive(unorderedArray_basta, 0, c - 1); DiziyiYazdir(unorderedArray_basta); Console.WriteLine();
            Console.Write("QuickSort Çalışma Zamanı:"); Console.WriteLine(Time_QS(unorderedArray_basta, 0, c - 1));
            Console.Write("MergeSort Çalışma Zamanı:"); Console.WriteLine(Time_MS(cp3, 0, c - 1));
            */

            //2.Soru
       
            int[] randomDizi = RandomDiziUret(30);
            Console.Write("Rastgele Dizi: "); DiziyiYazdir(randomDizi); Console.WriteLine(); // Rastgele diziyi ekrana yazdırıyorum.
            int n = randomDizi.Length; // son indeksi yollamak için dizi boyutu tutuyorum.
            int []sirali = DiziKopyala(randomDizi);
            Console.Write("Sıralanmış Dizi: "); QuickSort_Recursive(sirali, 0, n - 1); DiziyiYazdir(sirali); Console.WriteLine();



            // Quick Sort için dizi kopyalanır ve quick sort algoritmasna göre sıralama yapılıp çalışma zamanı hesaplanır.
            int[] dizi4_QS = DiziKopyala(randomDizi);
            TimeSpan QuickSortZamani = Time_QS(dizi4_QS, 0, n - 1);
            Console.Write("\nOrtalama quick sort çalışma süresi: " + QuickSortZamani);


            // Merge Sort için dizi kopyalanır ve Merge Sort algoritmasıyla sıralanarak çalışma zamanı hesaplanır.
            int[] dizi4_MS = DiziKopyala(randomDizi);
            TimeSpan MergeSortZamani = Time_MS(dizi4_MS, 0, n - 1);
            Console.Write("\nOrtalama merge sort çalışma süresi: " + MergeSortZamani);
            //Mergesort algoritması parametre olarak (sıralanacak dizi,ilk indeks,son indeks) olarak alır.


            // Insertion Sort için dizi kopyalanır ve Insertion Sort algoritmasıyla sıralanarak çalışma zamanı hesaplanır.
            int[] dizi4_IS = DiziKopyala(randomDizi);
            TimeSpan InsertionSortZamani = Time_IS(dizi4_IS);
            Console.Write("\nOrtalama insertion sort çalışma süresi: " +InsertionSortZamani ); // 

            double division = (InsertionSortZamani.Ticks) / (QuickSortZamani.Ticks);  // Bir alt satırdaki  komut için gerekli hesaplama.
            Console.Write("\nOrtalama insertion sort çalışma süresi / Ortalama Quick sort çalışma süresi: "+division);

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
        private static TimeSpan Time_MS(int[] dizi, int p, int r)
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
        }

        private static void QuickSort_Recursive(int[] dizi, int baslangicIndeksi, int bitisIndeksi) // Dizi,Başlangıç indeksi,Bitiş indeksi
        {
            if (baslangicIndeksi < bitisIndeksi) {
                int pivot = Partition(dizi, baslangicIndeksi, bitisIndeksi); // pivot eleman seç 

                // Recursive olarak tekrar quicksort yap ve sırala.
                QuickSort_Recursive(dizi, baslangicIndeksi, pivot - 1);
                QuickSort_Recursive(dizi, pivot + 1, bitisIndeksi);
            }
            
            
        }
        private static int Partition(int[] dizi,int baslangicIndeksi,int bitisIndeksi) {
            // Pivot eleman seçip , pivottan kücükler solda büyükler sagda olacak sekilde sıralar.
            // Dizinin en son elemanı pivot olarak seçilir.
            int pivot = dizi[bitisIndeksi];
            int i = baslangicIndeksi-1 ; 

            for (int j = baslangicIndeksi; j < bitisIndeksi ; j++)
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
            dizi[bitisIndeksi] = dizi[i+1];
            dizi[i+1] = temp;
            return i + 1; // pivotun oldugu indeksi döndür.

        }
      
        private static TimeSpan Time_QS(int []dizi,int begin,int end) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Stop();
            QuickSort_Recursive(dizi, begin, end);
            var elapsedMS = watch.Elapsed;
            return elapsedMS;
        }

   
    }
}
