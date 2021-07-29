#include <stdio.h>

int main(){

	int s1,s2;
	printf("1-20 arasındaki asallar:\n");

		for(int sayi=1; sayi<=20;sayi++)
		{
			int kontrol =0;
		
			for(int i=2;i<sayi;i++)
			{
				if(sayi % i ==0)
				{
	 			kontrol=1;
				break;
					}
			}
			if(kontrol != 1)
			{
				printf("%d,",sayi);
			}

		}


		
return 0;
		
}
