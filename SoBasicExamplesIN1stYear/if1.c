#include <stdio.h>

int main()
{
	int vize,final,devam;
	float ort;
	printf("Vize notunuzu giriniz: ");
	scanf("%d",&vize);
	printf("Final notunuzu giriniz: ");
	scanf("%d",&final);
	printf("Devam notunuzu giriniz: ");
	scanf("%d",&devam);
	printf("-----------------\n");

	ort = (vize*40/100)+(final*50/100)+(devam*10/100);
	printf("Ortalama puanınız = %.2f \n",ort);
	if(ort>=60)
		printf("Tebrikler,gectiniz..\n");
	else
		printf("Maalesef,kaldiniz..\n");
	
	return 0;
}
