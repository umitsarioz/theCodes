public class Main {

    public static void main (String[]args)
    {

        int[][] arr = {{ 5, 7, 15, 18 },
                { 1, 8, 9, 17 },
                { 1, 4, 7, 7 }};

        int h[] = merge(arr);
        System.out.print("Merged Array: ");
        for(int i:h)
            System.out.print(i+" ");
    }
    private static int[] merge(int[][] arr)
    {
        int n = arr.length; // 3
        int k = arr[0].length; // 4

        /** array to keep track of non considered positions in subarrays **/
        int[] curPos = new int[n]; // 3 elemanlı max indeksi 2

        /** final merged array **/
        int[] mergedArray = new int[n * k];
        int p = 0;

      for(int j=0;j<n;j++) // n times 
      {
          for (int i = 0; i < k; i++) // k times 
          {
              int min = Integer.MAX_VALUE;
              int minPos = -1;
              for (int idx = 0; idx < n; idx++) // n times : : Total Time Complexity : O(n*k*n) =  O (k*n^2)
              /** search for least element **/ {
                  if (curPos[idx] < k) //
                  {
                      if (arr[idx][curPos[idx]] < min) {
                          min = arr[idx][curPos[idx]];
                          minPos = idx;
                      }
                  }
              }
              curPos[minPos]++;
              mergedArray[p++] = min;
          }
      }
        return mergedArray;
    }
}
