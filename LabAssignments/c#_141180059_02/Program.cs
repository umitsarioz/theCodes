using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algoritmalar_lab2_141180059
{
    class Program
    {

        static void Main(string[] args)
        {

          
            int[] rndmDizi = randomDiziUret(20); // 20 elemanlı rastgele elemanlardan oluşan bir dizi oluşturan fonksiyon.
            // int[] rndmDizi = { 12, 11, 13, 5, 6 }; // örneği denedim.

            int [] rndmDizi_soru2 = DiziyiTut(rndmDizi); //2.soru için diziyi kopyaladım.

            // 1.soru için çalışma zamanı hesaplanıyor.
            var watch_soru1 = System.Diagnostics.Stopwatch.StartNew();
            watch_soru1.Stop();
            Console.WriteLine("--------\n SORU 1\n--------");
            ilkSoru(rndmDizi);
            var elapsedMs_soru1 = watch_soru1.Elapsed;
            Console.WriteLine("\n\n1.SORU:Toplam çalışma Zamanı(Elapsed MS): " + elapsedMs_soru1);

            // 2.soru için çalışma zamanı hesaplanıyor.
            var watch_soru2 = System.Diagnostics.Stopwatch.StartNew();
            watch_soru2.Stop();
            Console.WriteLine("\n--------\nSORU 2\n--------");
            ikinciSoru(rndmDizi_soru2);
            var elapsedMs_soru2 = watch_soru2.Elapsed;          
            Console.WriteLine("\n\n2.SORU:Toplam çalışma Zamanı(Elapsed MS): "+elapsedMs_soru2);

            Console.ReadKey();
        }

        private static int[] DiziyiTut(int[] rndmDizi) {
            int[] dizi=new int[rndmDizi.Length];
            for (int i = 0; i < rndmDizi.Length; i++)
            {
                dizi[i] = rndmDizi[i];
            }
            return dizi;
        }
        public static int[] ilkSoru(int[]rndmDizi) {

         
            Console.Write("Üretilen random dizi : ");
            diziyiYazdır(rndmDizi); 
            Console.WriteLine("\n---------------------\n");
            //
            Console.Write("1.adım : "); 
            diziyiYazdır(rndmDizi);
            Console.WriteLine(); 
            // İlk adım için diziyi oku.
            InsertionSort(rndmDizi); // Adım adım insertion sort gerçekleyip ekrana yazdıran fonksiyon.
            return rndmDizi;

     
            
        }

        public static void ikinciSoru(int[]dizi) {
            // 4 Dizi oluşturuyorum..
            int[] dizi1= new int[(dizi.Length/4)];
            int[] dizi2 = new int[(dizi.Length / 4)];
            int[] dizi3 = new int[(dizi.Length / 4)];
            int[] dizi4 = new int[(dizi.Length / 4)];
            // Asıl diziden elemanları çekmek için bir index degiskeni tanımlıyorum.
            int index=0;
            int diziBoyutu = (dizi.Length / 4);
            // Dizileri asıl diziden dolduruyorum.
            for(int i=0;i< diziBoyutu;i++)
            {
                dizi1[i] = dizi[index];
                index = index + 1;
            }

            for (int i = 0; i < diziBoyutu; i++)
            {
                dizi2[i] = dizi[index];
                index = index + 1;
            }
            for (int i = 0; i < diziBoyutu; i++)
            {
                dizi3[i] = dizi[index];
                index = index + 1;
            }
            for (int i = 0; i < diziBoyutu; i++)
            {
                dizi4[i] = dizi[index];
                index = index + 1;
            }

            // Dizileri kendi içlerinde sıralatıyorum ve çalışma zamanını hesaplatıp ekrana yazdırıyorum.
            // 1.Dizi
            Console.Write("Dizi 1 : ");
            diziyiYazdır(dizi1);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dizi 1 için Sıralama: " + "\n-------------");
            Console.Write("1.Adım : ");
            diziyiYazdır(dizi1);
            Console.WriteLine();
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            watch1.Stop();
            InsertionSort(dizi1);
            var elapsedMs1 = watch1.Elapsed;
            Console.WriteLine("Çalışma Zamanı:"+elapsedMs1);
            Console.WriteLine();

            //2.Dizi
            Console.Write("Dizi 2 : ");
            diziyiYazdır(dizi2);
            Console.WriteLine();
            Console.WriteLine("\nDizi 2 için Sıralama: "+"\n-------------");
            Console.Write("1.Adım : ");
            diziyiYazdır(dizi2);
            Console.WriteLine();
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            watch2.Stop();
            InsertionSort(dizi2);
            var elapsedMs2 = watch2.Elapsed;
            Console.WriteLine("Çalışma Zamanı:" + elapsedMs2);
            Console.WriteLine();

            //3.Dizi
            Console.Write("Dizi 3 : ");
            diziyiYazdır(dizi3);
            Console.WriteLine();
            Console.WriteLine("\nDizi 3 için Sıralama: " + "\n-------------");
            Console.Write("1.Adım : ");
            diziyiYazdır(dizi3);
            Console.WriteLine();
            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            watch3.Stop();
            InsertionSort(dizi3);
            var elapsedMs3 = watch3.Elapsed;
            Console.WriteLine("Çalışma Zamanı:" + elapsedMs3);
            Console.WriteLine();

            //4.Dizi
            Console.Write("Dizi 4 : ");
            diziyiYazdır(dizi4);
            Console.WriteLine();
            Console.WriteLine("\nDizi 4 için Sıralama: " + "\n-------------");
            Console.Write("1.Adım : ");
            diziyiYazdır(dizi4);
            Console.WriteLine();
            var watch4 = System.Diagnostics.Stopwatch.StartNew();
            watch4.Stop();
            InsertionSort(dizi4);
            var elapsedMs4 = watch4.Elapsed;
            Console.WriteLine("Çalışma Zamanı:" + elapsedMs4);
            Console.WriteLine();

            // Her bölme işlemi için zamanları topluyorum ki ayırma işlemi için yaklaşık zamanı hesaplıyorum.
            TimeSpan totalSortingTime = elapsedMs1 + elapsedMs2 + elapsedMs3 + elapsedMs4;
            Console.WriteLine("Bölme işlemi için Toplam Çalışma Zamanı: "+totalSortingTime);


            var watch5 = System.Diagnostics.Stopwatch.StartNew(); // Birleştirme işlemi için gecen zaman
            watch5.Stop();

            int[] birlestirilmisDizi= birlestir(dizi.Length,dizi1,dizi2,dizi3,dizi4); //20 elemanlı bir dizi olacak ve 4 tane dizi yolluyorum.

            var elapsedMs5 = watch5.Elapsed;
            Console.WriteLine("Birleştirme işlemi için Toplam Çalışma Zamanı: "+elapsedMs5+"\n\n");
            // Birlestirilmiş diziyi ekrana yazdırıyorum.
            Console.Write("Birlestirilmiş dizi: ");
            diziyiYazdır(birlestirilmisDizi);
            Console.WriteLine("\n--------------------\n"); 

            // Birleştirilmiş diziyi sıralama
            Console.WriteLine("Birlestirilmiş dizinin Sıralanması: ");
            Console.Write("1.adım: ");  
            diziyiYazdır(birlestirilmisDizi);
            Console.WriteLine();
            var watch6 = System.Diagnostics.Stopwatch.StartNew(); // Birleştirme işlemi için gecen zaman
            watch6.Stop();
            InsertionSort(birlestirilmisDizi);
            var ElapsedMs6 = watch6.Elapsed;
            Console.WriteLine();
            Console.Write("Sıralanmış son durum:");
            diziyiYazdır(birlestirilmisDizi);
            Console.WriteLine("\n");
            Console.Write("Birleştirilen dizinin Sıralanması için Çalışma Zamanı: " + ElapsedMs6);
        }
       
        private static int [] randomDiziUret(int elemanSayisi)
        { // Istenilen eleman sayısında random sayılarla dizi olusturan fonksiyon.
            int[] dizi = new int[elemanSayisi];
            Random rastgele = new Random(); // random nesnesi olusturur

            for (int i = 0; i < elemanSayisi; i++)
            {
                dizi[i] = rastgele.Next(0,101); //0-101 arasında sayı üretir.101 dahil degildir.
            }
            return dizi;
        }

        private static void diziyiYazdır(int [] dizi) {

            foreach (int eleman in dizi)
                Console.Write(eleman.ToString() + " ");
        }

        private static int[] InsertionSort(int[] dizi) {
            int adimsayisi = 2; // Adım adım ekrana yazdırmak için adım sayisini tutacak degisken tanımladım.İlk adım zaten dizinin kendisini yazdırmak oldugundan 2'den basladım.
            for (int i = 0; i < dizi.Length - 1; i++)
            {
                int gecerliIndex = i + 1; //dizinin sağındaki sayı alınıyor.
              
                while (gecerliIndex > 0 && dizi[gecerliIndex - 1] > dizi[gecerliIndex])
                {
                    // İlk alınan değeri elimizde tutuyoruz.
                    int geciciDeger = dizi[gecerliIndex - 1];

                    // Kucuk olan degeri bir sola kaydırıyoruz ve peşine büyük deger yerine elimizde tuttugumuz degeri yerleştiriyoruz.
                    dizi[gecerliIndex - 1] = dizi[gecerliIndex];
                    dizi[gecerliIndex] = geciciDeger;
                    gecerliIndex--;

                    // Adım adım ekrana yazdırma. 
                    Console.Write(adimsayisi+".adım: ");
                    diziyiYazdır(dizi);
                    Console.WriteLine();
                    adimsayisi++;
                }
            }
            return dizi;
        }

        private static int[] birlestir(int elemanSayisi,int[] d1, int[] d2, int[] d3, int[] d4) {

            int sinir = elemanSayisi / 4;
            int index = 0; // Yeni olusturulacak dizinni indexi için değişken tanımladım.
            int[] yeniDizi = new int[elemanSayisi];
           
            {
               
                {
                    for (int j = 0; j < d1.Length; j++)
                    {
                        yeniDizi[index] = d1[j];
                        index++;
                    }
                    for (int j = 0; j < d2.Length; j++)
                    {
                        yeniDizi[index] = d2[j];
                        index++;
                    }
                    for (int j = 0; j < d3.Length; j++)
                    {
                        yeniDizi[index] = d3[j];
                        index++;
                    }
                    for (int j = 0; j < d4.Length; j++)
                    {
                        yeniDizi[index] = d4[j];
                        index++;
                    }
                }
            }
            return yeniDizi;
        }

    }
}


