#include <stdio.h>

int main(){
	
	float nufus_a=10000;
	float nufus_a_hiz=0.25;
	float nufus_b=40000;
	float nufus_b_hiz=0.12;
	int sayac=0;
	while(nufus_b>nufus_a)
	{
		nufus_a=nufus_a+(nufus_a*nufus_a_hiz);
		nufus_b=nufus_b+(nufus_b*nufus_b_hiz);
		sayac++;
	}
	printf("%d yil sonra \n A sehrinin nufusu=%.1f\n B sehrinin nufusu=%.1f\n ",sayac,nufus_a,nufus_b);		
	


return 0;
}
