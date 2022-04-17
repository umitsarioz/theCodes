public class Main {

    public static void main(String[] args) {
        int ikiBin[] = {12, 10, 18, 15};
        int ikiBinYirmi[] = {39, 13, 47, 45};
        int kar[] = new int[4];

        for (int i = 0; i < kar.length; i++)
        {
            kar[i] = ikiBinYirmi[i] - ikiBin[i];
        }
        int cuzdan=30;
        int max = Integer.MIN_VALUE;
        int costIndex= 0;
        for (int i = 0; i < kar.length; i++) {
            if (kar[i] > max) {
                max = kar[i];
                costIndex =i;
            }
        }
        int cost = ikiBin[costIndex];
        int kazanc;
        int hisseSayisi = 0;
        int mevcutPara;
        for(mevcutPara = cuzdan;mevcutPara>=cost;mevcutPara-=cost)
            hisseSayisi+=1;
        kazanc = max * (hisseSayisi)+mevcutPara;

        System.out.println("Bir hisseden edilebilecek Max kâr:"+max+"\nAlınan hisse sayisi:"+hisseSayisi+"\nKazancımız: "+kazanc);
        // Time Complexity'si O(n).
    }
}
