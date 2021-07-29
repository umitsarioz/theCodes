#include <stdio.h>

int main(){

	int num,final_num;
	printf("5 basamaklı bir sayi giriniz:");
	scanf("%d",&num);
	int num_mod=num%1000;
	int add_num=1000-num_mod;
	if(num_mod>500)
		final_num=num+add_num;
	else
		final_num=num-num_mod;
	printf("-----------------------\n");
	printf("%d sayisinin yuvarlatılmıs hali:%d'dir.\n",num,final_num);

return 0;


}
