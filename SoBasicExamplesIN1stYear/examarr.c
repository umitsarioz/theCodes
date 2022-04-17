#include <stdio.h>

int main() {
	int not[5],index;
	int sum=0;
	float ort;
	printf("5 adet sınav notu giriniz:");
	
	for(index=0;index<5;index++)
	{
		scanf("%d",&not[index]);
		sum+=not[index];
		}
	ort=sum/5;
	printf("Notların ortalaması:%.1f\n\n",ort);
	printf("Ortalamadan yuksek notlar:\n");
	int i=0;
	
	while(i<5)
		{
			if(not[i]>ort)
				printf("%d\n",not[i]);
			i++;
		}

	return 0;
}
