#include <stdio.h>

int us(int,int);

int main(){
	int taban,kuvvet;
	printf("taban giriniz:");
	scanf("%d",&taban);
	printf("us giriniz:");
	scanf("%d",&kuvvet);
	printf("Sonuc=%d",us(taban,kuvvet));
	return 0;
}	

int us(int tb,int kv){

	if(kv==0)
		return 1;
	else
		return tb*us(tb,kv-1);
}
