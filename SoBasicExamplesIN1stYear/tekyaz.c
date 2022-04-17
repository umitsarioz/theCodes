#include <stdio.h>

int main(){
	int duz[5];
	int i=0;
	int j=4;
	printf("5 adet sayı giriniz:");
	while(i<5)
	{
		scanf("%d",&duz[i]);
		i++;
		}
	printf("girilen sayıların tersten cıktısı:\n");
	while(i>0)
		{
			printf("%d\n",duz[i-1]);
			i--;
		}	
return 0;
}
