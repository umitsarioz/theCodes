#include <stdio.h>

int main() {

		int sayi,t,ozel;
		int bir,on,yuz,bin;
		for(sayi=1000;sayi<10000;sayi++)
		{
			bir=sayi%10;
			on=(sayi/10)%10;
			yuz=(sayi/100)%10;
			bin=sayi/1000;
			t=bir+on+yuz+bin;
			if(sayi==(t*t*t))
				{
				ozel=sayi;
				printf("4 basasamakli ozel sayi : %d \n",ozel);}
		}

	
return 0;
}
