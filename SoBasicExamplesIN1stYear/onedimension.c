#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int menu();
//menuyu goster ve secimi dondur;
void diziyiYaz(int [],int);
//diziyi ekrana yazdırır.
void bubbleSort(int [],int);
// diziyi bubblesort'a göre sırala
void selectionSort(int [],int );
// diziyi selection sort algoritmasına göre sırala
int linearSearch(int [],int,int);
// diziyi linear olarak ara 
int binarySearch(int [],int,int);
// diziyi ikili olarak ara
void doldur(int [],int);
//diziyi 0-100 arasındaki rastgele sayılarla doldur.
float ortalama(int [],int);
// Ortalama al
float medyan(int [],int);
//medyan yani ortanca elemanı bul.
int mod(int [],int);
//mod'unu yanı sıklıgını bul.

int main() {

	int dizi[10]={0};
	int secim;
	int aranan;
	srand(time(NULL));
	while(secim!=0)
	{
		secim =menu();
		switch(secim){
			case 0:
				printf("Program sona erdi.\n");
				break;
			case 1:
				diziyiYaz(dizi,10);
				break;
			case 2:
				doldur(dizi,10);
				break;	
			case 3:
				bubbleSort(dizi,10);
				break;
			case 4:
				selectionSort(dizi,10);
				break;
			case 5:case 6:
				printf("Aranacak:");
				scanf("%d",&aranan);
				int indis;
				if(secim==5)
					indis=linearSearch(dizi,10,aranan);
				else 
					indis=binarySearch(dizi,10,aranan);
				if(indis==-1)
					printf("\nAranan eleman yok.\n");
				else
					printf("\n%d.indiste aranan eleman bulundu\n",indis);
				break;
			case 7:
				printf("\nDizinin ortalaması=%.2f\n",ortalama(dizi,10));
				break;
			case 8:
				printf("\nDizinin medyani=%.2f\n",medyan(dizi,10));
				break;
			case 9:
				printf("\nDizinin modu=%d\n",mod(dizi,10));
			default:
				printf("\nHATALI GİRİS YAPTINIZ.\n");		}

	}


return 0;
}


int menu(){
	int secim;
	printf("________MENU_________\n");
	printf("0-Programı kapat.\n");
	printf("1-Diziyi yazdır.\n");
	printf("2-Diziyi rastgele doldur.\n");
	printf("3-Diziyi sırala(BuubleSort).\n");
	printf("4-Diziyi sırala(SelectionSort).\n");
	printf("5-Dizide ara(Linear Search).\n");
	printf("6-Dizide ara(Binary Search).\n");
	printf("7-Dizinin ortalamasını al.\n");
	printf("8-Dizinin ortancasını bul.\n");
	printf("9-Dizinin modunu bul.\n");
	printf("_____________________\n");
	printf("Seciminiz:");
	scanf("%d",&secim);
	return secim;
}
void diziyiYaz(int dizi[],int n){

	int i;
	printf("Dizi=");
	for(i=0;i<n;i++)
		printf("%d\t",dizi[i]);
	printf("\n");
}

void doldur(int dizi[],int n){
	int i;
	for(i=0;i<n;i++)
		dizi[i]=rand()%100;
}

void bubbleSort(int dizi[],int n){
	int i,j,temp;
		for(i=1;i<n;i++)
			for(j=0;j<n-1;j++)
				if(dizi[j]>dizi[j+1])
					{
					temp=dizi[j];
					dizi[j]=dizi[j+1];
					dizi[j+1]=temp;
			}
		printf("Dizinin siralanisi:\n");
		for(i=0;i<n;i++)
		printf("%d \t",dizi[i]);
		printf("\n");
}
void selectionSort(int dizi[],int n){

	int k,m,enkucuk,yedek;
	
	for(k=0;k<n-1;k++){
			enkucuk=k;
			for(m=k+1;m<n;m++)
				{
				if(dizi[m]<dizi[enkucuk])
					enkucuk=m;
				}
		
			yedek=dizi[k];
			dizi[k]=dizi[enkucuk];
			dizi[enkucuk]=yedek;
}
	printf("Dizinin siralanisi:\n");
	for(k=0;k<n;k++)
	printf("%d\t",dizi[k]);
	printf("\n");

}
int linearSearch(int dizi[],int n,int aranan){
	int i,yer=-1;
	for(i=0;i<n;i++)
		if(dizi[i]==aranan)
			yer=i;
	return yer;
}
int binarySearch(int dizi[],int n,int aranan){

	// BURASI İNCELENECEK //
	int bas=0;
	int son= n-1;
	int orta;
	
	bubbleSort(dizi,n);
		while(bas<=son){			
	 		orta=(bas+son)/2;
			if(dizi[orta]==aranan)
				return orta;
			else if(dizi[orta]>aranan)
				son=orta-1;
			else
				bas=orta+1;	
			}
	return -1;


}

float ortalama(int dizi[],int n)
{
	int i,sum=0;
	float ort;
		for(i=0;i<n;i++)
			sum+=dizi[i];
	ort=sum/n;
	return ort;
}

float medyan(int dizi[],int n){
	bubbleSort(dizi,n);
	if(n%2==0)
		return (dizi[(n/2)-1]+dizi[((n+2)/2)-1])/2;
	else
		return dizi[((n+1)/2)-1];

}

int mod(int dizi[],int n){
	int frekans[101]={0}; //adetleri tutar
	int m;
	int enbuyuk;
	
	for(m=0;m<n;m++)
	 frekans[dizi[m]]++;

	enbuyuk=0;
	for(m=0;m<101;m++)
		if(frekans[m]>frekans[enbuyuk])
			enbuyuk=m;
	return enbuyuk;
		
}





