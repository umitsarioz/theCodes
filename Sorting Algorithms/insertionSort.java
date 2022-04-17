/*
 *Coded by Ümit SARIÖZ
 * Question: Insertion sort
 */
public class Main {

    public static void main(String[] args) {
        int []array = {17,9,25,34,50,14,37,43};
        System.out.print("Given Array: ");yazdir(array);
        insertionSort(array); // Sorting function
        System.out.print("\nSorted Array: ");yazdir(array);
    }
    private static int []insertionSort(int []dizi){
        for (int i = 0; i < dizi.length - 1; i++)
        {
            int gecerliIndex = i + 1; // in the beginning , i choosed 2nd element of array is constant and compare the others.And same thing is applied other elements
            while (gecerliIndex > 0 && dizi[gecerliIndex - 1] > dizi[gecerliIndex]) // if conditions are done ,then do swap .
            {
                int geciciIndex = dizi[gecerliIndex - 1];
                dizi[gecerliIndex - 1] = dizi[gecerliIndex];
                dizi[gecerliIndex] = geciciIndex;
                gecerliIndex--;
            }
        }
        return dizi;
    }
    private static void yazdir(int[]dizi){
        for(int i:dizi)
            System.out.print(i+" ");
    }
}
