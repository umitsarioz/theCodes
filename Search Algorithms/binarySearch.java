/*
*Coded by Ümit Sarıöz
*Question : we want to find a element is to get input from user.
 */


public static void main(String[] args) {
        int elemanSayisi = 10; // define array size.
        int[] dizi = rastgeleDiziUret(elemanSayisi);
        System.out.print("Array is created randomly ");
        diziyiYazdir(dizi);
        int []siralanmisDizi = CountingSort(dizi);
        System.out.print("\nSorted Array: ");
        diziyiYazdir(siralanmisDizi); // Print sorted array using with counting sort.

        Scanner scanner = new Scanner(System.in);
        System.out.print("\nNumber you want to search: ");
        int aranacakSayi = scanner.nextInt(); // get input from user
        // for binary search,the array have to be ordered.
        int sonuc = iterativeBSA(siralanmisDizi,aranacakSayi); // call binary search function is given below .That's iterative solution.
        if(sonuc == -1 )
        System.out.print("Iterative: the element is no exist in array .");
        else
        System.out.print("Iterative:the elements is exist at "+sonuc+". index.");

        int sonuc_rec = recursiveBSA(siralanmisDizi,0,dizi.length-1,aranacakSayi);
        if(sonuc_rec==-1)
        System.out.print("\nRecursive: the elements is no exist in array.");
        else
        System.out.print("\nRecursive: the element is exist at "+sonuc_rec+". index.");
        System.out.print("\nBinary Search Algorithm's running finished.***");

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

    // Binary Search ( İkili Arama )
    private static int iterativeBSA(int[]dizi,int arananEleman) { // binary search algoritmasıyla searching,arama,işlemi.
            int altSinir = 0; // left
            int ustSinir = dizi.length-1; // right

            while(ustSinir>=altSinir) // if right is bigger than left or is equal then do .
            {
            int orta = (ustSinir+altSinir)/2; // calculate the middle value of the array.
            if(dizi[orta]==arananEleman) // if the element in middle index is equal.You found what you search !
            return orta;
            if(dizi[orta]>arananEleman) // else if the element is bigger than  you want to find . Then delete the right side of this array from beginning middle value-1.
            ustSinir=orta-1;
            else            // else delete the left side of this array from beginning middle value+1.
            altSinir=orta+1;

            }
            return -1;
            }
    private static int recursiveBSA(int[]dizi,int altSinir,int ustSinir,int arananEleman) {
        // same things iterative bsa.The difference is we dont have while loop.Instead of that if our conditions is okay,we call the function again with changing left or right value.
            if(ustSinir>=altSinir){
            int orta = (ustSinir+altSinir)/2;
            if(dizi[orta]==arananEleman)
            return orta;
            if (dizi[orta] > arananEleman)
            return recursiveBSA(dizi,altSinir,orta-1,arananEleman);
            else
            return recursiveBSA(dizi,orta+1,ustSinir,arananEleman);
            }
            return -1;
            }

