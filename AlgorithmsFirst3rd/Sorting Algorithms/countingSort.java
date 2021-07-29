    /*
    *Coded by Ümit Sarıöz
    *Question: Counting sort.
     */
    public static void main(String[] args) {
            int elemanSayisi = 10; // define array size.
            int[] dizi = rastgeleDiziUret(elemanSayisi);
            System.out.print("Array is created randomly ");
            diziyiYazdir(dizi);
            int []siralanmisDizi = CountingSort(dizi);
            System.out.print("\nSorted Array: ");
            diziyiYazdir(siralanmisDizi);
     }
    // basic functions we need
    private static int [] rastgeleDiziUret(int elemanSayisi) {
            // create array randomly
            // we have to a limit is our elements are smaller than array size.It's the rule of counting sort.
            int[]rastgeleDizi = new int[elemanSayisi];
            Random qwe = new Random();
            for(int index=0;index<elemanSayisi;index++){
            rastgeleDizi[index]= qwe.nextInt(elemanSayisi-1);
            }
            return rastgeleDizi;
     }
    private static void diziyiYazdir(int dizi[]){ // Print array function.
            int index;
            for(index=0;index<dizi.length;index++)
            {
            System.out.print(dizi[index]+" ");
            }
     }

    // Time complexity O(n)
    private static int[] CountingSort(int[] dizi) {
            // we need at least extra two array.One of them is holding counts of elements and the other one is sorted array.
            int n = dizi.length; // array size.
            int []siraliDizi = new int[n]; // sorted array
            int []sayiAdeti = new int[n+1]; // array is holding counts of elements

            for(int i=0;i<sayiAdeti.length;i++) //fill 0 to counts of elements array.
            sayiAdeti[i]=0;
            for(int i=0;i<n;i++) //calculate the counts of elements.
            sayiAdeti[dizi[i]]+=1;

            for(int i=1;i<sayiAdeti.length;i++) // calculate the sum of count that is the element at current index and how many elements exist is smaller than current element.
            sayiAdeti[i]=sayiAdeti[i]+sayiAdeti[i-1];

            for(int i=n-1;i>=0;i--) // fill the elements to sorted array using with counts array.
            {
            siraliDizi[sayiAdeti[dizi[i]]-1]=dizi[i];
            sayiAdeti[dizi[i]]-=1;
            }
            return siraliDizi;
     }
