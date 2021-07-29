#include <stdio.h>

float kuvvet(int m1,int m2,int r){
	float g=6.7;
	float oran,cekim_kuvvet;
	
	oran=(m1*m2)/(r*r);		
	cekim_kuvvet=g*oran;
	
	return cekim_kuvvet;
	}

int main(){
	int kutle1,kutle2,uzaklik;
	float f;
	printf("birinci cismin agirligi=");
	scanf("%d",&kutle1);
	printf("ikinci cismin agirligi=");
	scanf("%d",&kutle2);
	printf("iki cisim arasindaki uzaklik=");
	scanf("%d",&uzaklik);
	f=kuvvet(kutle1,kutle2,uzaklik);
	printf("Cekim kuvveti=%.2f Newton'dur.\n",f);
	return 0;
}
