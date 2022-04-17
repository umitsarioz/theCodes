#include <stdio.h>

int main() {
	int kod;
	int k=0;
	int y=0;
	int s=0;
	int b=0;
	printf("Kod giriniz (1,2,3,4 ya da cikmak icin 111):");
	scanf("%d",&kod);
		while(kod!=111)
		{
			if(kod<5 && kod>0){
				if(kod==1)
					k++;
				else if(kod==2)
					y++;
				else if(kod==3)
					s++;
				else if(kod==4)
					b++;
				}
			else
				printf("Hata gecerli bir kod giriniz!!\n");
			printf("Kod giriniz (1,2,3,4 ya da cikmak icin 111):");
			scanf("%d",&kod);
		}
	printf("Gun sonu satış Raporu:\n %d kırmızı,%d yesil,%d Sari, %d siyah oje satilmistir.",k,y,s,b);
	
return 0;
}
