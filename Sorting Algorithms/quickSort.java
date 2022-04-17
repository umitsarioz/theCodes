import java.util.Random;

public class Main {

    public static void main(String[] args) {
        int []array = randomUret(10); // hold the array is created randomly
        System.out.print("Created array randomly: ");yazdir(array);
        quickSort(array,0,array.length-1); // sorting function.
        System.out.print("\nSorted array: ");yazdir(array);
    }
    private static void yazdir(int []dizi) {
        for(int i:dizi)
            System.out.print(i+" ");
    }
    private static int[] randomUret(int n){
        // n is array size
        int []randomArray = new int[n];
        Random rnd = new Random();
        for(int i=0;i<n;i++)
            randomArray[i]=rnd.nextInt(100);
        return randomArray;
    }
    private static void quickSort(int[] dizi, int baslangicIndeksi, int bitisIndeksi) // Array,Starting index, End index
    {
        if (baslangicIndeksi < bitisIndeksi) // if left smaller than right
        {
            int pivot = Partition(dizi, baslangicIndeksi, bitisIndeksi); // calculate the pivot element
            // run the quicksort function recursively
            // care the indexes we send
            quickSort(dizi, baslangicIndeksi, pivot - 1);
            quickSort(dizi, pivot + 1, bitisIndeksi);
        }
    }
    private static int Partition(int[] dizi, int baslangicIndeksi, int bitisIndeksi)
    {
        // There are some algorithms for choosing pivot. In this code i choose the last element of array for pivot.
        // And then i look which elements are bigger than pivot and smaller ? If the elements is smaller than pivot then write left side.
        // Otherwise write the right side of pivot.
        int pivot = dizi[bitisIndeksi]; // define pivot.
        int i = baslangicIndeksi - 1; //starting index

        for (int j = baslangicIndeksi; j < bitisIndeksi; j++)
        {
            if (dizi[j] <= pivot)  // if the element is at current index smaller than pivot.
            {
                i = i + 1;
                // swap .
                int gecici = dizi[j];
                dizi[j] = dizi[i];
                dizi[i] = gecici;
            }
        }
        // and in the end swap between pivot element and the last element.
        int temp = dizi[bitisIndeksi];
        dizi[bitisIndeksi] = dizi[i + 1];
        dizi[i + 1] = temp;
        return i + 1; // return pivot index.
    }

}
