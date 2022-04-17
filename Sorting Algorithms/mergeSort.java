import java.util.Random;

/*Coded by Ümit SARIÖZ
 *Question: MergeSort as Recursively
 * */
public class Main {

    public static void main(String[] args) {
        int []array=randomUret(10); // create random an array.
        System.out.print("Created array randomly:");yazdir(array);
        mergesort(array,0,array.length-1); // sorting function
        System.out.print("\nSorted array:");yazdir(array);
    }
    private static void yazdir(int[]dizi){  // print array
        for(int i: dizi)
            System.out.print(i+" ");
    }
    private static int[] randomUret(int n){
        // n is array size .
        int []randomArray=new int[n];
        Random rnd = new Random();
        for (int i=0;i<n;i++)
            randomArray[i]=rnd.nextInt(100);
        return randomArray;

    }
    // Logic of merge sort: Array is divided 2 parts until there is exist 1 element . And sort these arrays and then merge them.
    private static void mergesort(int[] dizi, int p, int r) { // p is first or left index and r is last or right index
        if (p < r) // if left smaller than right
        {
            int q = (p + r) / 2; // find the middle value
            mergesort(dizi, p, q);
            mergesort(dizi, q + 1, r);
            merge(dizi, p, q, r); // Merge these arrays.
        }
    }
    private static void merge(int[] dizi, int p, int q, int r) {
        // p-> left/first index , q-> middle index , r:right/last index
        int n1 = q - p + 1; // size of left subarray
        int n2 = r - q; // size of right subarray

        //create subarrays.
        int[] sol = new int[n1];
        int[] sag = new int[n2];


        int i, j, k; //Fill the subarrays.i refer to left sub array,j->right sub-array,k:temp index

        for (i = 0; i < n1; i++)
            sol[i] = dizi[p + i];
        for (j = 0; j < n2; j++)
            sag[j] = dizi[q + j + 1];

        // initialization
        i = 0;
        j = 0;
        k = p;
        // Sol alt dizinin elman sayısı indisinden büyükse ve aynı sekilde sag içinde varsa yerleştirmeye başla.
        // if size of left sub-array is smaller than current index and also size of right sub-array is smaller than the current index, Then do it .
        while (i < n1 && j < n2)
        {
            // if the element is at left subarray is smaller than right one.Fill to left otherwise fill to right.And then increment suitable index.
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
        // If still there is exist elements outside . Fill these in our array.
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


}
