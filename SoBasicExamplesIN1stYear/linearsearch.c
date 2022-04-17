#include <stdio.h>

int main() {

	int aranan,i,dizi[5]={3,14,5,7,8};
	int found=-1;


	printf("Aradiginiz sayiyi giriniz:");
	scanf("%d",&aranan);

	for(i=0;i<5;i++)
		if(dizi[i] == aranan)
			found=i;	
	if(found != -1)
		printf("Aradiginiz sayi %d. indiste bulunmustur.",found);
	else
		printf("Aradiginiz sayi bu dizide yoktur");
	return 0;

}
