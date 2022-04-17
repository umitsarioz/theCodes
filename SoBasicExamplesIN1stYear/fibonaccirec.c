#include <stdio.h>

int fib(int);
int main()
{
	int eleman;
	printf("kacinci eleman:");
	scanf("%d",&eleman);	
	printf("%d. eleman %d'dir.",eleman,fib(eleman));
	return 0;
}

int fib(int n){
	if(n==1 || n==0)
		return(n);
	else
		return fib(n-1)+fib(n-2);

}
