#include <stdio.h>

int main(){

	int yildiz;
	int i=0;
	
	printf("5 sayi gir:");
	
	while(i<5){
	 scanf("%d",&yildiz);
		for(int j=0;j<yildiz;j++)
			printf("*");
	printf("\n");
	i++; 
	}
	return 0;

}
