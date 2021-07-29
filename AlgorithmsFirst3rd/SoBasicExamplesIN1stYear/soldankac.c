#include <stdio.h>

int main() {

int sayi;
printf("sayi giriniz:");
scanf("%d",&sayi);

int onluk=sayi%100;
int yuzluksa=sayi/100;
int onluksa=onluk/10;
int birlik=sayi%10;

int min;

if(onluksa!=yuzluksa && yuzluksa !=birlik)
	{	if(onluksa < birlik)
			{min=onluksa;
			onluksa=birlik;
birlik=min;
printf("en kucuk rakam soldan 2.dir");}
		else if(yuzluksa<)
			{min=yuzluksa;
printf("en kucuk rakam soldan 1.dir");}
		else 
		printf("en kucuk rakam soldan 3.dur");
		
}
return 0;

}
