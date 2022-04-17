#include <stdio.h>

int main()
{
int saat;
printf("Bir saat giriniz:");
scanf("%d",&saat);

if (saat<6)
	printf("İyi uykular\n");
else if (saat <11)
	printf("Günaydın\n");
else if (saat<17)
	printf("İyi günler\n");
else if (saat<22)
	printf("İyi akşamlar\n");
else if (saat<24)
	printf("İyi geceler\n");
else 
	printf("İyi uykular\n");

return 0;

}
