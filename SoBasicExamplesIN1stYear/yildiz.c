#include <stdio.h>

int main(){


int kenar;
	printf("kenar uzunlugu giriniz:");
	scanf("%d",&kenar);
int i=0;
	while(i<kenar) {
	for(int j=0;j<kenar;j++)
		printf("*");
	printf("\n");
	i++;
		}
return 0;
	}
