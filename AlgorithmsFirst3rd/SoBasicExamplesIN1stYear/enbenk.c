#include <stdio.h>

int main(){


	int sayi,enb,enk;
	printf("sayi giriniz:");
	scanf("%d",&sayi);
	enb=enk=sayi;
	while(sayi>0){
		if(sayi>enb)
			enb=sayi;
		else if(sayi<enk)
			enk=sayi;
	printf("en buyuk sayi=%d\nen kucuk sayi=%d\n",enb,enk);
		printf("baska sayi giriniz:");
		scanf("%d",&sayi);
		}

	printf("Program bitmistir...\n");
return 0;
}
