#include <stdio.h>

int main(){
	int dizi[3][4];
	int satir,sutun;
	for(satir=0;satir<3;satir++){
		printf("%d.satirdaki elemanları giriniz:",satir+1); //satırdaki elemanlar
		for(sutun=0;sutun<4;sutun++)
		scanf("%d",&dizi[satir][sutun]);} //tek seferde girmelisin.
	printf("\n");
	printf("------TABLO------\n");
	for(satir=0;satir<3;satir++)
		{
		for(sutun=0;sutun<4;sutun++)
			printf("%d",dizi[satir][sutun]);
		printf("\n"); 
			}
		
return 0;
}
