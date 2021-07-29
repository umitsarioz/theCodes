// coded by Ümit Sarıöz
/*
 *Eng*
 *Question 1: we have a min heap tree and we want to delete "7".And then the tree should be sorted as heap sort algorithm.
 * min_heap=[3,7,8,11,13,10,17,19,23]
 * Question 2: convert min heap is given  to max_heap
 * Min_heap = [5 7 11 8 10 22 12 14 20 11]
 * Tr*
 * 1.soru: Verilen heap yapısından 7 elemanını silip diziyi tekrar heap sort kullanarak sırala.
 * 2.soru: Verilen min  heap yapısı max heap'e dönüştür.
*/
class HeapSort{
    public static void soru1(){ // define a function for calling in main
        int [] min_heap = {3,7,8,11,13,10,17,19,23};
        int silinecekIndeks=1; // index we want to remove
        System.out.print("Min Heap başlangıç: ");
        Main.diziyiYazdir(min_heap);  // print the array.
        System.out.print("\nMin heap son durum: ");
        sil(min_heap,silinecekIndeks); // call remove function.
        System.out.print("\nHeapsort ile sıralı: ");
        min_sort(min_heap); // call minimum heap sort function.
    }
    // Minimum heap fonksiyonları.
    // functions about minimum heap
    private static void min_sort(int[]heap){ // sorting algorithm.
        min_build(heap); // build heap
        int b = heap.length-1; // heapsize[heap]
        for(int i = b-1;i>0;i--)
        {
            degistir(heap,0,i); // swap the values
            b-=1; // heapsize
            min_heapify(heap,0,b); // heapify function.
        }
        for(int j=0;j<heap.length-1;j++)
            System.out.print(heap[j]+" ");
    }
    private static void min_build(int[]heap){
        int heapsize = heap.length-1;
        for(int i=((int)Math.floor(heap.length/2))-1;i>=0;i--)
            min_heapify(heap,i,heapsize);
    }
    private static void min_heapify(int[]heap,int i,int heapsize){
        int sol = sol(i); // sol cocuk // left child
        int sag = sag(i); // sag cocuk // right child
        int enk = i; // en kucuk deger yani parent  . // smallest value i mean the root or parent .
        if(sol<heapsize && heap[sol]<heap[enk]) // if left child index is smaller than heapsize and value at this index is smaller than our smallest value.
            enk=sol;
        if(sag<heapsize && heap[sag]<heap[enk])  // if right child index is smaller than heapsize and value at this index is smaller than our smallest value.
            enk=sag;
        if(enk != i) { // if our smallest index is changed then swap.
            degistir(heap, i, enk);
            min_heapify(heap, enk,heapsize); // and call recursively min_heapify function.
        }
    }
    // Belirli bir node'u nasıl silebilirim ? Silenecek indeksteki degerle en son degeri yer degistir. Sonra heap özelligin tekrar kontrol et.
    // Remove the node/element: swap between an element we want to remove and last element of array that i mean the farthest node.
    private static void sil(int []heap,int silinecekIndeks){
        int sonEleman=heap.length-1;
        heap[silinecekIndeks]=heap[sonEleman]; // silenecek indeksle en son elemanı yer degistir. // swapping
        min_heapify(heap,silinecekIndeks,sonEleman); // heap'in heap özeligini saglayıp saglamadıgını kontrol et. // check the structure as a heap rules.
        for(int i=0;i<sonEleman;i++)
            System.out.print(heap[i]+" ");
    }


    //////////////////////// *********------------SORU 2----QUESTION 2----------------*********//////////////////
    public static void soru2(){
        int[] min_heap={5,7,11,8,10,22,12,14,20,11};
        System.out.print("Min heap: ");
        Main.diziyiYazdir(min_heap);
        System.out.print("\nMax heap: ");
        donustur(min_heap);

    }
    // Maximum heap'e dönüştürmek için sadece build ve max heapify fonksiyonları yeterli oldugunu gördm.
    // for 2nd question, build and max_heapify functions are enough.So i applied below.
    private static void donustur(int[]heap){ // convert and print
        build(heap);
        Main.diziyiYazdir(heap);
    }
    private static void build(int []heap){ // build the heap as max_heapify.
        for(int i=(heap.length-2)/2;i>=0;i--)
            max_heapify(heap,i);
    }
    private static void max_heapify(int[]heap,int i){ // check the heap is maximum heap or not
        int heapsize= heap.length;
        int sol = sol(i); // sol cocuk // left child
        int sag = sag(i); // sag cocuk // right child
        int enb = i; // en buyuk deger yani parent/root .
        if(sol<heapsize && heap[sol]>heap[enb])
            enb=sol;
        if(sag<heapsize && heap[sag]>heap[enb])
            enb=sag;
        if(enb != i) {
            degistir(heap, i, enb);
            max_heapify(heap, enb);
        }
    }

    // Ortak fonksiyonlar
    private static void degistir(int []dizi,int atanacakdeger,int ilkdeger){ // Swapping
        int mandal = dizi[atanacakdeger];
        dizi[atanacakdeger]=dizi[ilkdeger];
        dizi[ilkdeger]=mandal;
    }
    // our index will start at 0 . So i defined like that because of that exception is case if i ==0
    private static int sol(int i){
        return 2*(i+1)-1;
    } //0 dan başladıgım için i ile degil i+1 ile çarpıyorum.ilk sol cocuk i=0 için i=1 bulunmalı.
    private static int sag(int i){
        return 2*(i+1);
    }

}
public class Main {

    public static void main(String[] args) {
        HeapSort heapSort = new HeapSort();
        System.out.println("Soru-1: Aşağıdaki min heap yapısından \"7\" elemanını siliniz ve yeniden heapsort ile sıralayan kodu yazınız.");
        heapSort.soru1(); // calling the function i defined over as question 1
        System.out.println("\n\nSoru-2: Aşağıdaki min heap yapısını -> max heap'e dönüştürünüz.");
        heapSort.soru2(); // calling the function defined over as question 2
    }
    public static void diziyiYazdir(int[]dizi) {
        for (int i:dizi)
            System.out.print(i+" ");
    }

}
