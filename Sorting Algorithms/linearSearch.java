import java.util.Random;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        int []array=randomUret(10);
        System.out.print("Array created randomly: ");yazdir(array);

        Scanner scan = new Scanner(System.in);
        System.out.print("\nSearch st: ");
        int searching = scan.nextInt();
        int res = linearSearch(array,searching);
        if(res!=-1)
            System.out.print("The element is at index "+res);
        else
            System.out.print("The element does not exist. :(");
    }
    private static void yazdir(int []dizi){
        for(int i:dizi)
            System.out.print(i+" ");
    }
    private static int linearSearch(int[]dizi,int k){
        int i;
        for(i=0;i<dizi.length;i++)
        {
            if(dizi[i]==k)
                return i;
        }
        return -1 ;
    }
    private static int[] randomUret(int n){
        // n is array size
        int []randomArray= new int[n];
        Random rnd = new Random();
        for(int i=0;i<n;i++)
            randomArray[i]=rnd.nextInt(20);
        return randomArray;
    }

}
