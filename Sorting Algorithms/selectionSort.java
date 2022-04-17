import java.util.Random;

public class Main {

    public static void main(String[] args) {

        int n=5 ; // Eleman sayısı , // size of array
        int []arr = new int[n];
        randomUret(arr,n);
        System.out.print("Random arr: ");printArr(arr);
        sortAsMin(arr);
        System.out.print("\nAsc: ");
        printArr(arr);
        sortAsMax(arr);
        System.out.print("\nDesc: ");
        printArr(arr);
    }
    private static void sortAsMin(int[]dizi)
    {
        int n= dizi.length;
        int temp;
        int min;
        // O(n^2)
        for(int i=0;i<n-1;i++){
            min = i;
            for(int j=i;j<n;j++){ // traverse array begin from min index.
                if(dizi[j]<dizi[min])
                    min=j;
            }
            temp=dizi[i];
            dizi[i]=dizi[min];
            dizi[min]=temp;
        }
    }
    private static void sortAsMax(int[]dizi){
        int n= dizi.length;
        int temp;
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
        }
    }
    private static void randomUret(int[] dizi,int n)
    {
        Random rnd = new Random();
        for(int i=0;i<n;i++)
            dizi[i]=rnd.nextInt(15);
    }
    private static void printArr(int[] dizi)
    {
        for (int i:dizi)
            System.out.print(i+" ");
    }
}
