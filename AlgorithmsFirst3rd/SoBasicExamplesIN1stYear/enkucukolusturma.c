#include <stdio.h>

int main() {

	int num;
	
	printf("sayi gir:");
	scanf("%d",&num);
	int yuzler=num/100;
	  while(yuzler==0){
		printf("Sayi 0 ile baslayamaz,");
		printf("baska sayi giriniz:");
			scanf("%d",&num);
		int yuzler=num/100;
			}
		int onlar=(num/10)%10;
		int birler=num%10;
	
	
	printf("yuzler=%d,onlar=%d,birler=%d \n",yuzler,onlar,birler);
	
	int sayi[3]={yuzler,onlar,birler};
	int i,j,gecici;
	for(i=0;i<3;i++){
		for(j=0;j<3;j++){
			if(sayi[i]<=sayi[j]){
				gecici=sayi[i];
				sayi[i]=sayi[j];
				sayi[j]=gecici;
					}
				}
			}
	int min=sayi[0];
	int ort=sayi[1];
	int max=sayi[2];

	int enkucuk;
printf("max=%d,ort=%d,min=%d \n",max,ort,min);
	if(ort==0 && min==0)
		enkucuk = max*100;
	else if(min==0)
		enkucuk = ort*100+min*10+max;
	else
		enkucuk = min*100+ort*10+max;

	printf("sonuc= %d\n",enkucuk);
	
return 0;	
}

