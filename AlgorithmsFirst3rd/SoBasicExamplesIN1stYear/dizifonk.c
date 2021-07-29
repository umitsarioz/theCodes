#include <stdio.h>

void yaz(int[],int);

int main() {
	
	int dizi[5]={1,2,3,4,9};
	yaz(dizi,5);
	return 0;		
}

void yaz(int dz[],int n){

	for(int i=0;i<5;i++)	
		printf("%d",dz[i]);
}
