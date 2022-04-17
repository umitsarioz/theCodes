#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main(){
	int mayin[4][4]={{0}};
	srand(time(NULL));

	int satir,sutun;
	int sayac=0;
	int mayinsayisi=6;

	for(sayac=0;sayac<mayinsayisi;sayac++){
		satir=rand()%4;
		sutun=rand()%4;
			if(mayin[satir][sutun]==0)
				mayin[satir][sutun]=1;
			else
				sayac--;
	}
	for(satir=0;satir<4;satir++){
		for(sutun=0;sutun<4;sutun++)
			printf("%d",mayin[satir][sutun]);
		printf("\n"); }
	return 0;
				
}
