#include <stdio.h>
#include <math.h>
int main(){

	int k1,k2,k3;
	int temp;
	printf("kenar uzunlugu giriniz: ");
	scanf("%d,%d,%d",&k1,&k2,&k3);
	if (k2<k3)
	{
		temp=k3;
		k3=k2;
		k2=temp;
	}
	if((k1>(k2-k3)) &&(k1<(k2+k3))){
		
	printf("Bu bir ucgendir.Tipi ise sudur:\n");

	if(k1 == k2 && k2 == k3 )
		printf("Esitkenar ucgendir.\n");
	else if (k1 ==k2 || k1==k3 || k2==k3)
		printf("Ikizkenar ucgendir.\n");
	else
		printf("Cesitkenar ucgendir.\n");
	}

	else
	printf("Bu bir ucgen degildir.");	
return 0;	
				
}
