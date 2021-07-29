#include <stdio.h>

int hesapla(int,int);
int main(){

	/* bu kod normal olarak çalışmaktadır.

	int maas=3;
	int gun,son=0;
	printf("gun giriniz:");
	scanf("%d",&gun);
	
	while(gun!=0)
	{
		son+=maas;
		maas*=2;
		gun--;
		}
	printf("%dtl maas\n",son);
	return 0;

*/

	int maas=3;
	int gun,son=0;
	printf("gun giriniz:");
	scanf("%d",&gun);
	printf("%d",hesapla(maas,gun));
	return 0;
}
//bu kod ise recursive çözümü

int hesapla(int maas,int gun){
	int yeni=maas*2;
	if(gun ==0)
		return 0; 
	else
		return maas+hesapla(yeni,gun-1);
	}
