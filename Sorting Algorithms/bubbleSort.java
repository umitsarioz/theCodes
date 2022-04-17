import java.util.Random;

public class Main {

    private static void yaz(int [] arr){ // print the array
    for(int i:arr)
        System.out.print(i+" ");
    }
    private static void randomla(int []arr){ // create values randomfly to fill array
        Random rnd = new Random();
        for(int i=0;i<arr.length;i++)
            arr[i]=rnd.nextInt(20);
    }
    private static void swap(int[] arr,int i,int j){ // swapping
        int tmp;
        tmp = arr[i];
        arr[i]=arr[j];
        arr[j]=tmp;
    }
    private static void sort(int []arr){
        int tmp;
        int n=arr.length; // length of array
        // O(n^2)
        for(int i=0;i<n;i++)
        {
            boolean ordered = true; // if array is ordered just print .So that best case (n). Otherwise bestcase (n^2).
            for(int j=n-1;j>i;j--)
            {
                if(arr[j-1]>arr[j])
                {
                    ordered=false;
                    swap(arr,j-1,j); // swap the elements
                }
            }
            if(ordered) // lucky man.. Array is ordered . bestcase ! 
                break;
        }
    }
    public static void main(String[] args) {
	// time complexity: O(n^2)
        int n= 8; // size of array.
        int [] arr = new int[n]; // create empty array
        randomla(arr); // fill array with random numbers.
        System.out.print("arr: ");yaz(arr);
        sort(arr); // sort arr
        System.out.print("\nSorted arr: ");
        yaz(arr); // print array .
    }
}
