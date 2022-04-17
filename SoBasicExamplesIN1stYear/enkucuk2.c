#include <stdio.h>

int main(){
	int sayi,k1,k2,i;
	
	printf("sayi giriniz:");
	scanf("%d",&sayi);
	k1=sayi;
	for(i=0;i<4;i++){
		printf("bir sayi daha giriniz:");
		scanf("%d",&sayi);
		if(sayi<k1){
			k2=k1;
			k1=sayi;
			}	
	}
		
printf("k1=%d,k2=%d",k1,k2);
return 0;		
}
