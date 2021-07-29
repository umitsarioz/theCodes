#include <stdio.h>

int main(){
		int sayi,bolen;
		

	for(sayi=1;sayi<1000;sayi++)
		{
			int toplam=0;
		for(bolen=1;bolen<sayi;bolen++)
			if(sayi%bolen==0)
				toplam+=bolen;
		if(toplam==sayi)
			printf("%d,",sayi);
		}

	return 0 ;
}	
