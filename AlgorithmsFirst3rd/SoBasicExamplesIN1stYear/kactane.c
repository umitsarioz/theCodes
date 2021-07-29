#include <stdio.h>

int say(int[],int,int);

int main(){
	int aranacak,adet;
	int dizi[10]={13,2,7,8,55,32,2,7,7,13};
	printf("Aranacak Elemani Yaziniz:");
	scanf("%d",&aranacak);
	adet=say(dizi,10,aranacak);
	printf("%d sayısından %d tane vardır. \n",aranacak,adet);
	return 0;

}

int say(int s[],int n,int aranan){
	int i,sayac=0;
	for(i=0;i<n;i++)
		if(s[i]==aranan)
			sayac++;
	return sayac;
}
