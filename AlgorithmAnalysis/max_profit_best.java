import java.util.Arrays;
import java.util.Collections;

public class Main {

    /*
    * Elde edilebilecek kârlar hesaplanır.
    * Bu kârlar kendi içerisinde büyükten kücüge siralanir.
    * Aynı zamanda cost degerleri de indeksleriyle eşleştirilerek sıralanır.
    * ** İndeks degeri yedeklenir ve diger sayıyla swap yaptırılır.
    * Elindeki paranın kârdan büyük olup olmadıgına bakarsın .
    * Büyükse true diyip satın alım döngüsüne sokarsın.
    * Satın alamadığında sonraki indeksi alıp alamadıgına bakarsın.
    * Bu işlem sona kadar devam eder.
    * En son bool döngülerinin çıkışında kalan para kazanca eklenir.
    * */
    public static void main(String[] args) {
        int n=4;
        int ikiBin[] = {11, 10, 18, 15};
        int ikiBinYirmi[] = {39, 13, 47, 45};
        float kar_orani[] = new float[n];
        boolean [] alinabilir = new boolean[n];
        int kar_miktar[] = new int[n];
        for (int i = 0; i < n; i++) // Kârlar hesaplandı...
        {
            kar_orani[i] = ikiBinYirmi[i] / ikiBin[i];
        }
        for (int i=0;i<n;i++)
        {
            kar_miktar[i]=ikiBinYirmi[i]-ikiBin[i];
        }

        sortAsMax(kar_orani,ikiBin,kar_miktar,n); // Cost ve Kârlar büyükten kücüge siralandi.

        for(int i=0;i<n;i++)  // Yatırım yapmaya değer mi ?
        {
            if (kar_orani[i] > 0)
                alinabilir[i] = true;
            else
                alinabilir[i] = false;
        }

        int cuzdan=30;
        int sayac=0;
        int kazanc=0;
        int cost;
        while(sayac<n)
        {
            if(alinabilir[sayac]) {
                for (int i = 0; i < n; i++) {
                    int edilenKar = kar_miktar[i]; // best solution'da burası kar_best olacak.
                    cost = ikiBin[i];
                    int hisseSayisi = 0;
                    while(cuzdan>=cost){
                        hisseSayisi += 1;
                        cuzdan -= cost;
                    }
                    kazanc += hisseSayisi*edilenKar ;
                }
            }
            sayac++;
        }
        kazanc += cuzdan;
        System.out.println("Kazancımız: "+kazanc);
        // Time Complexity'si O(n).
    }
    private static void sortAsMax(float[]dizi,int cost[],int []kar_miktari,int n){
        float temp;
        int tempCost;
        int tempMiktar;
        int max;
        //O(n^2)
        for(int i=0;i<n-1;i++){
            max = i;
            for(int j=i;j<n;j++){ // traverse array begin from min index.
                if(dizi[j]>dizi[max])
                    max=j;
            }
            temp=dizi[i];
            dizi[i]=dizi[max];
            dizi[max]=temp;

            tempCost = cost[i];
            cost[i] = cost[max];
            cost[max]=tempCost;

            tempMiktar = kar_miktari[i];
            kar_miktari[i]=kar_miktari[max];
            kar_miktari[max]=tempMiktar;
        }
    }

}
