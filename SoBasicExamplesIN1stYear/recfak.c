#include <stdio.h>

int fak(int);
int main(){
	int sayi;
	printf("bir sayi giriniz:");	
	scanf("%d",&sayi);
	printf("girdiginiz sayinin faktoriyeli=%d \n",fak(sayi));
	return 0;
}

int fak(int num){

	if(num==0)
		return 1;
	else
		return num*fak(num-1);
}
