#include <stdio.h>

void asalbul(int,int);

int main(){
	int alt,ust;
	printf("alt sınırı giriniz:");
	scanf("%d",&alt);
	printf("ust sınırı giriniz:");
	scanf("%d",&ust);
	asalbul(alt,ust);
	return 0;
}

void asalbul(int a,int u){

	int i,bolen,test;
	
	for(i=a;i<u;i++)
		{
		test=1;
		for(bolen=2;bolen<i;bolen++)
			 if(i%bolen==0)
				{
				test=0;
				break;}
		if(test)
			printf("%d,",i);
}
}
