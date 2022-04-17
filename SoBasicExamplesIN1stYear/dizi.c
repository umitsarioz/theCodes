#include <stdio.h>

int main(){
	// dizininturu dizininadı [elemansayisi];
int a[6]; // 6 eelmeanlı her eleamnı int olan bir dizi
char d2[15]; //15 elemanlı d2 isminde ve her elemanı char olan bir dizi
float x[10]; // 10 elemanlı x imsinde ve her elemanı float olan bir dizi
double k[10]; // 10 elmanlı k isminde ve her elemanı double olan bir dizi

/* a dizisi olusturuldugu anda bellekte her int 2 byte olmak üzere toplamda 6 adet int alabileceği 12 bytelik yer ayrılır.Alanın başlangıç adresini dizi ismine aktarır.Sonraki degerlere ise bu adresten başlanarak indisleme metoduyla ulaşılır. yani n sayılı bir dizinin ilk elemanı 0. indisten baslarken son elemanı n-1. indisle bitmektedir. */

//tek boyutlu dizilere farklı şekilde ilk değer atama(initialize) yapılabilir.

//1.yöntem direk atama

a[0]=3; // a dizisinin ilk elemanına 3 değeri atanmıştır.
a[3]=2; // a dizisinin 3.indisteki alana yani 4. elemanına 2 atanmıştır.

/* ayrıca tüm elemanları da aynı anda tanımlayabilirsiniz.Eğer eleman sayısından eksik veya hiç eleman tanımlanmazsa dizi otomatik olarak 0 olarak doldurulur. */

int dizi2[5]={4,5,2,9,7}; //5 elemanlı bir dizidir ve elemanları yazıldığı gibidir.

int dizi3[]={3,4}; // 2 elemanlı bir dizidir.3 ve 4 vardır.

int dizi4[3]={2}; // ilk elemanı 2 olan ve diğer elemanları 0 olan bir dizidir.

int dizi5[5]; // 5 elemanlı ama içindeki değerlerin rastgele verildiği bir dizidir.


// HATALI KULLANIM ÖRNEĞİ
int dizi3[]; // BÖYLE BİR TANIMLAMA YAPILAMAZ.!! ELEMAN SAYISI VEYA İÇERİSİNDEKİ ELEMANLAR YAZILMALIDIR.
// HATALI KULLANIM ÖRNEĞİ


return 0;
}
