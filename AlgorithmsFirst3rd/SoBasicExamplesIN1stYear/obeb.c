#include <stdio.h>

void bolenbul(int);
void yaz(int);
void ekok(int);

int main(){
int sayi;
printf("Sayi gir:");
scanf("%d",&sayi);
bolenbul(sayi);
ekok(sayi);
	return 0;
}
void bolenbul(int num){
	int i,bolen;
	 //bolen varsa 1
	for(i=2;i<num;i++)
		if(num%i==0)
			bolen=i;
	yaz(bolen);
}

void ekok(int num)
{
int i,bolen;
	for(i=num-1;i>=2;i--)
		if(num%i==0)
			bolen=i;
	printf("Ekok:%d\n",bolen);
}

void yaz(int obeb){
	printf("Obeb:%d \n",obeb);
}

