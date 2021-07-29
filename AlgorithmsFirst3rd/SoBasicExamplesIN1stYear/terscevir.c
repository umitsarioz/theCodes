#include <stdio.h>

void tersduz(int);
	int main(){
	int sayi;
	printf("sayi gir:");
	scanf("%d",&sayi);
	tersduz(sayi);
	return 0;	
}

void tersduz(int a)
{
	while(a>0)
	{
		printf("%d",a%10);
		a=a/10;
	}
}
