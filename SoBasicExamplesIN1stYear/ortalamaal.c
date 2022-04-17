#include <stdio.h>

int main(){
	
	int not=0,toplam=0,ogr_sayi=0;
	float ort;
	
	printf("Not giriniz,(sonlandırmak için -1 giriniz):");
	scanf("%d",&not);
	
	while(not !=-1)
	{	
		toplam+=not;
		ogr_sayi++;
		printf("Not giriniz,(sonlandırmak için -1 giriniz):");
		scanf("%d",&not);
		}
	if(ogr_sayi !=0){
		ort=toplam/ogr_sayi;
		printf("\n\n ortalama:%.2f \n",ort);	
		}
	

return 0;
}
