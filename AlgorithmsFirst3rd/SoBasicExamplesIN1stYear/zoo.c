#include <stdio.h>

int main() {

	int giris_sayisi;
	int toplam=0;
	int toplam_E=0;
	char cinsiyet;
	int sayac=1;

	printf("Maymunun cinsiyetini giriniz(Erkek=E/e,Disi=D/d):");
	scanf("%c",&cinsiyet);
	printf("Maymun kac kez kafese girmistir:");
	scanf("%d",&giris_sayisi);

	
	while(sayac<=giris_sayisi) {
		
	if(cinsiyet=='E' || cinsiyet=='e')
		toplam_E=toplam*2;
	else if(cinsiyet=='D' || cinsiyet=='d')
	{
		if(sayac<=5)
			toplam+=sayac;
		else
		{	
			int formul=(toplam-sayac)/2;
			toplam+=(formul+1);
		}
	sayac++;
	}
	printf("%d. girisinde toplamda %d muz yemis oldu.\n",sayac-1,toplam);
	}
return 0;
}
