#include <stdio.h>
int topla(int a,int b)
{
	int sum=a+b;
	return sum;
}

int main(){
	int s1,s2;
	printf("sayi gir:");
	scanf("%d",&s1);
	printf("sayi gir:");
	scanf("%d",&s2);

	printf("iki sayinin toplamı=%d",topla(s1,s2));
return 0;
}
