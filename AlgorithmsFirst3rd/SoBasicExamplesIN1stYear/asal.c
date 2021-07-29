#include <stdio.h>

int main(){

	int sayi,i;
	int test=1; /*sayi asal ise 1 degilse 0 olacak*/
	
	printf("sayi giriniz:");
	scanf("%d",&sayi);

	if(sayi==1 || sayi==0)
		printf("sayi asal degildir.\n");
	else if(sayi<0)
		printf("pozitif bir sayi giriniz\n");
	else if(sayi>1)
 {
		for(i=sayi-1;i>1 && test==1;i--) /*sayi-1 ile 2 arasındaki bütün sayılar*/
			if(sayi%i ==0)
				test=0;

	if(test)
		printf("sayi asaldir.\n");
	else
		printf("sayi asal degildir.\n");
}
return 0;
		

}
