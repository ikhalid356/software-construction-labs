#include "stdafx.h"  
#include "MatrixLib.h"  
#include <algorithm>
#include <iostream>
using namespace std;
namespace MatrixLib
{
	void Functions::add(int matA[3][3], int matB[3][3]){
		int matC[3][3];
		for (int i = 0; i < 3; i++){
			for (int j = 0; j < 3; j++)
			{
				matC[i][j] = matA[i][j] + matB[i][j];
				cout << matC[i][j] << "\t";


			}
			cout << endl;
		}
		cout << endl;
	}

	void Functions::sub(int matA[3][3], int matB[3][3]){
		int matC[3][3];
		for (int i = 0; i < 3; i++){
			for (int j = 0; j < 3; j++)
			{
				matC[i][j] = matA[i][j] - matB[i][j];
				cout << matC[i][j] << "\t";


			}
			cout << endl;
		}
		cout << endl;
	}
}
