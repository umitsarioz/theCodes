#include <stdio.h>
int main()
{
		int say, t = 0 ,temp;
		printf("sayi giriniz: " );
		scanf("%d",&say);
		temp=say;

while(temp !=0)
{
t=t*10;
t=t+temp%10;
temp=temp/10;
}

if (say ==t)
	printf("%d Palindromdur",say);
else
	printf("%d Palindrom degildir.",say);
return 0;
						
}



