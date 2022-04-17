#include <stdio.h>

int main(){

	int sayi;
	int tekbas=0;
	int ciftbas=0;
	int sayac=0;
	
	printf("bir sayi giriniz:");
	scanf("%d",&sayi);
	
	while(sayi>0){
		if((sayi/10)<=0)
			tekbas++;
		else if((sayi/10)<10)
			ciftbas++;
		sayac++;
		printf("bir sayi giriniz:");
		scanf("%d",&sayi);
		}	
printf("%d sayinin %d tek basamakli,%d cift basamaklidir.\n",sayac,tekbas,ciftbas);
return 0;

}
