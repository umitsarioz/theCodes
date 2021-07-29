#include <stdio.h>
int parcala(int);
int main(){
int sayi;
printf("sayi gir:");
scanf("%d",&sayi);
printf("en buyuk rakam=%d",parcala(sayi));

return 0;
}

int parcala(int a){
	int enb=0;
	int rakam;
	while(a>0)
	{	
		rakam=a%10;		
		if(rakam>enb)
			enb=rakam;
		a=a/10;
	}
	return enb;	
}
