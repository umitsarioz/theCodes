#include <stdio.h>

int main() { 

	int asal,bolenler,sonuc,ikiz,enb;

	for(asal=9;asal<100;asal++) //iki basamaklı tum sayilari dondur
		{
		sonuc=1; //asalsa 1 olsun
	for(bolenler=2;bolenler<asal;bolenler++)
		{
		if(asal%bolenler==0)
		{
		sonuc=0; //sayi asal degildir.
		break; //döngüden cik
		}
		}
	if(sonuc==1) //eğer asal sayıysa aşağıdakileri gerçekleştirir.		
		{ ikiz=asal-2; //ikiz olması için asal aralarndaki fark 2dir.
			{
				for(bolenler=2;bolenler<ikiz;bolenler++)
				{
					if(ikiz%bolenler==0)
					{
					sonuc=0;
					break;
					}
				}
				if(sonuc ==1)
				{
					enb=ikiz;
				}
			}
		}
		}
	printf("enbüyük ikiz asallar %d ve %d'dir.\n",enb,enb+2);
	
return 0;
}

