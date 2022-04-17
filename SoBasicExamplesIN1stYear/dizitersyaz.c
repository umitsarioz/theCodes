#include <stdio.h>

int main() {

	int sayi,i;
	int dizi[10]; // int bir deger max 10 haneli olabilir.
	printf("bir sayi giriniz:");
	scanf("%d",&sayi);
	for(i=0;sayi>0;i++)
	{
		dizi[i]=sayi%10;
		sayi/=10;
		printf("%d",dizi[i]);
		}
	return 0;
	
}
