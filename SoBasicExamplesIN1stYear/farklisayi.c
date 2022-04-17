#include <stdio.h>
#include <math.h>

int main(){
	int sayi;
	printf("4 rakamlı bir tam sayı giriniz:");
	scanf("%d",&sayi);

	int birler=sayi %10;
	int onlar=(sayi/10)%10;
	int yuzler=(sayi/100)%10;
	int binler=(sayi/1000);

	int sayac=4;
	
if(birler==onlar && onlar==yuzler && yuzler==binler)
	sayac=sayac-4;
else if (birler==onlar && birler==yuzler || birler==onlar && birler==binler || birler==yuzler && onlar==binler )
	sayac=sayac-2;
else if (onlar==yuzler && yuzler==binler)
	sayac=sayac-2;
else if (birler==onlar || birler==yuzler || birler==binler)
	sayac=sayac-1;
	
	
	printf("\n\n %d tane farklı rakam vardir.\n",sayac);
	

return 0;
}
