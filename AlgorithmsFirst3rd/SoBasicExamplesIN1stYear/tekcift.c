#include <stdio.h>

void tek_cift(int sayi){

	if(sayi >= 0 && sayi%2==0)
		printf("girdiginiz sayi cifttir.");
	else if(sayi >=0 && sayi%2 != 0)
		printf("girdiginiz sayi tektir.");
	else 
		printf("pozitif bir sayi giriniz.");
	
}

int main(){
	int a;	
	printf("bir sayi giriniz:");
	scanf("%d",&a);
	tek_cift(a);
return 0;
}
