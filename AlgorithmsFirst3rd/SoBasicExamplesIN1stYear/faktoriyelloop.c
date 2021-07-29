#include <stdio.h>

int main(){


	int sayi,fak,sayac;
	printf("bir sayi giriniz:");
	scanf("%d",&sayi);
	if(sayi<0)
		printf("lutfen pozitif bir sayi giriniz\n");
	else if(sayi>0){
		fak=1;
		for(sayac=1;sayac<=sayi;sayac++)
		fak*=sayac;
		printf("%d sayisinin faktoriyeli= %d\n",sayi,fak);
		}
	else
		{
		fak=1;
		printf("%d sayisinin faktoriyeli= %d\n",sayi,fak);}
	
	

return 0;
}
