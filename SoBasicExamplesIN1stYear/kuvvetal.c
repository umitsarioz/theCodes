#include <stdio.h>

int us(int,int);

int main() {
	
	int taban,kuvvet;	
	printf("taban giriniz:");
		scanf("%d",&taban);
	printf("kuvvet giriniz:");
		scanf("%d",&kuvvet);
	printf("sonuc=%d",us(taban,kuvvet));
	return 0;
}

int us(int taban,int us){
	int son=1;
	while(us>0)
		{	
			son*=taban;
			us=us-1;
	}
	return son;
}
