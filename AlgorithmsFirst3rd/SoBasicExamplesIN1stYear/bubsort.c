#include <stdio.h>

int main() {

	int dizi[5];
	int i,j,temp;
	printf("5 Eleman giriniz:");
	for(i=0;i<5;i++)
		scanf("%d",&dizi[i]);
	for(i=1;i<5;i++)		//eleman sayısının bir eksigi kadar döndür.Böylece algoritmaya göre geçişler tamamlanacaktır.
		for(j=0;j<4;j++)		//elemandan sonraki elemanın büyük/kücük kontrolü
			if(dizi[j]>dizi[j+1])
				{
					temp=dizi[j];
					dizi[j]=dizi[j+1];
					dizi[j+1]=temp;
					}
	printf("Dizinin sıralı hali:\n");
	for(i=0;i<5;i++)
		printf("%d \t",dizi[i]);
	return 0;
}
