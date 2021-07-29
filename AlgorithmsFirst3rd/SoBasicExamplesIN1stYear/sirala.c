#include <stdio.h>

int main() {

float s1,s2,s3;
float max,min,ort;

printf("Bir sayi giriniz:");
scanf("%f",&s1);
printf("Bir sayi giriniz:");
scanf("%f",&s2);
printf("Bir sayi giriniz:");
scanf("%f",&s3);

if(s1>s2 && s1>s3)
{
	max=s1;
	if(s2>s3)
	{ort=s2;
	min=s3;}
	else
	{ort =s3;
	min=s2;}
}


if(s2>s1 && s2>s3)
{
	max=s2;
	if(s1>s3)
	{ort=s1;
	min=s3;}
	else
	{ort =s3;
	min=s1;}
}


if(s3>s2 && s3>s1)
{
	max=s3;
	if(s1>s3)
	{ort=s1;
	min=s3;}
	else
	{ort =s3;
	min=s1;}
}

printf("Buyukten kucuge siralanisi: %.1f > %.1f > %.1f.\n",max,ort,min);

return 0;


}
