#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void zaman(char t)
	{	
		srand(time(NULL));
		int saat,min,sec;
		min=rand() % 59;
		sec=rand() % 59;
		if(t=='s')
			saat=8 + rand() % 2; //0'dan % 2 yani 2 ye kadar sayı uretır rastgele.Sonra 							bunlara,yani urettigi sayilara, 8 ekler
		else if(t=='o')
			saat=11 + rand() % 4;
		else if(t=='a')
			saat=16 + rand() % 6;
	
		printf("%d:%d:%d",saat,min,sec);		
	}

//bir zaman dilimi yollanacak 's','o','a' bunlara göre rastgele saat gosterıcek.

int main() {
	char tslice;
	printf("zaman dilimi yaz('s','o','a'):");
	scanf("%c",&tslice);
	zaman(tslice);
	return 0;
}

