#include <stdio.h>

char harfnotu(int vize,int final)
	{
		float ort=(vize*0.4)+(final*0.6);
		char harf;
		if(ort<50)
			harf='F';
		else if(ort<60)
			harf='D';
		else if(ort<70)
			harf='C';
		else if(ort<80)
			harf='B';
		else
			harf='A';
		return harf;	
	}

int main(){
		int vz,fnl;
		printf("vize notunu giriniz:");
		scanf("%d",&vz);
		printf("final notunu giriniz:");
		scanf("%d",&fnl);
		printf("Harf notunuz %c'dir.",harfnotu(vz,fnl));
return 0;
}
