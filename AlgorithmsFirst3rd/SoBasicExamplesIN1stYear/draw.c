#include <stdio.h>
#include <stdlib.h>
#include <time.h>
void dikdortgen(int a,int b){
	int i,j;
			for(i=0;i<a;i++)
			{
				for(j=0;j<b;j++)
				printf("*");
			printf("\n");
			}	
		}
int main(){
	int row,col;
	srand(time(NULL));
	row=1+rand() %5;
	col=1+rand()%10;
	dikdortgen(row,col);
		
	return 0;
	}
