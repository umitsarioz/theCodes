#include <stdio.h>
#include <string.h>
int main(){

float vki,kg,boy;
char cins;



printf("Kilonuzu kg cinsinden giriniz:");
scanf("%f",&kg);
printf("Boyunuzu m cinsinden giriniz:");
scanf("%f",&boy);
printf("Cinsiyetinizi E,e veya K,k olarak giriniz:");
scanf("%s",&cins);

float boy_kare=boy*boy;
vki = kg / boy_kare;

if(cins=='e'||cins=='E')
	{
	if(vki<20.7)
		printf("------------\nVucut kitle indeksi=%f \nZayıfsınız.Sağlık riski!",vki);
	else if(vki<26.4)
		printf("------------\nVucut kitle indeksi=%f \nNormalsiniz.Risk yoktur.",vki);
	else if(vki<31.1)
		printf("------------\nVucut kitle indeksi=%f \nŞişmanlık sınırında ya da şişmansınız.Riskli.",vki);
	else
		printf("------------\nVucut kitle indeksi=%f \nObezite.Ciddi derecede riskli.",vki);
	}

else if(cins='k' || cins=='K')
	{
	if(vki<19.1)
		printf("------------\nVucut kitle indeksi=%f \nZayıfsınız.Sağlık riski!",vki);
	else if(vki<25.8)
		printf("------------\nVucut kitle indeksi=%f \nNormalsiniz.Risk yoktur.",vki);
	else if(vki<32.2)
 		printf("------------\nVucut kitle indeksi=%f \nŞişmanlık sınırında ya da şişmansınız.Riskli.",vki);
	else
		printf("------------\nVucut kitle indeksi=%f \nObezite.Ciddi derecede riskli.",vki);
	}

else
	printf("Lutfen dogru bir sekilde bilgilerinizi giriniz..!");

return 0;
}
