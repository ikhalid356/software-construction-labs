// MatrixClient.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"  
#include <iostream>  
#include "MatrixLib.h"
#include<cstdlib>
#include<time.h.>
#include<stdlib.h>

using namespace std;

int main()
{
	srand(time(NULL));
	int m1[3][3];
	int m2[3][3];

	cout << "Matrix A:" << endl;
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			m1[i][j] = rand() % 100;
			cout << m1[i][j] << "\t";
		}
		cout << endl;
	}
	cout << endl;

	cout << "Matrix B:" << endl;
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			m2[i][j] = rand() % 100;
			cout << m2[i][j] << "\t";
		}
		cout << endl;
	}
	cout << endl;

	cout << "Transpose:" << endl;
	MatrixLib::Functions::MatTrns(m1);

	cout << "Addition:" << endl;
	MatrixLib::Functions::add(m1, m2);
	cout << "Subtraction:" << endl;
	MatrixLib::Functions::sub(m1, m2);
	

	cout << "Multiplication:" << endl;
	MatrixLib::Functions::multiply1(m1, m2);

	return 0;
}
