public class Main {

    private static int[] nMergeAndSort(int[][] diziler) {
        // k array size , n array count.
        int n = diziler.length;
        int k = diziler[0].length;
        int[] mergedArray = new int[k * n]; // bütün sayıları tutacak olan birleştirilmiş dizi.
        int index = 0; // birleştirilmiş arrayin index değerini bu değişkende tutucaz.
        System.out.print("Merged Array: ");
        for (int j = 0; j < n; j++)
            for (int i = 0; i < k; i++) {
                System.out.print(diziler[j][i] + " ");
                mergedArray[index++] = diziler[j][i]; // birleştir ve indeksi arttır .
                //index++;
            }
        System.out.print(" | Time complexity = O(k*n)");
        radixSort(mergedArray,n*k);
        System.out.print("\nMerged And Sorted: ");
        for(int x:mergedArray)
            System.out.print(x+" ");
        System.out.print("| Time Complexity = O(k*n) + O(k*n) ");
        return mergedArray;
    }

    private static void countingSort(int[] A,int n,int exp) // A = Merged dizi
    {
        // Klasik counting sort algoritması kümülatif versiyon.
        int[] output = new int[n];
        int[] count = new int[10]; // 10 tane hane olduğu için 0,1,2,3,4,5,6,7,8,9
        int i;
        // countingSort
        for(i=0;i<10;i++)
            count[i]=0;
        for(i=0;i<n;i++)
            count[(A[i]/exp)%10]++;

        for(i=1;i<10;i++)
            count[i]+=count[i-1];
        for(i=n-1;i>=0;i--)
        {
            output[count[(A[i]/exp)%10]-1]=A[i];
            count[(A[i]/exp)%10]--;
        }
        for(i=0;i<n;i++)
            A[i]=output[i];
    }
    private static void radixSort(int[]A,int n)
    {        // radixSort func.
        // exp = basamak sayisi birler basamağı=1,onlar basamağı=2 ...
        int max = findMax(A,n); // en büyük sayıyı buluyoruz ki basamak sayısı kaca kadar gidicek bilelim.
        for(int exp=1;max/exp>0;exp*=10)
            countingSort(A,n,exp);
    }
    private static int findMax(int []A,int n)
    {
        // maximum degeri bulan fonksiyon.
        int max=A[0];
        for(int i=0;i<n;i++)
            if(A[i]>max)
                max=A[i];
        return max;
    }
    public static void main (String[]args)
    {
        // Eleman sayısını ve dizi sayısını ben belirledim.Kritik nokta şu ki: Her dizi kendi içrisinde sıralı olmalı.
        int[][] randomDizi = {{3,5,12,54},{15,24,32,76},{11,36,40,79},{2,13,48,139}};
        nMergeAndSort(randomDizi);
    }
}
// Time Complexity = O(k*n)+O(n) n'de k*n olduguna göre : O(2*k*n) = O(k*n) diyebiliriz. 
