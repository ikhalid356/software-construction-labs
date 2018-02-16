#include "stdafx.h"  
#include "MatrixLib.h"  
#include <algorithm>
#include <time.h>
#include <iostream>
using namespace std;
namespace MatrixLib
{
	void Functions::multiply1(int a[3][3], int b[3][3]){
		int c[3][3];


		//Multiplying the two matrices
		for (int x = 0; x < 3; x++)
		{
			for (int y = 0; y < 3; y++)
			{
				c[x][y] = 0;
				for (int z = 0; z < 3; z++){
					c[x][y] = c[x][y] + a[x][z] * b[z][y];
				}
			}
		}

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				cout << c[i][j] << "\t";
			}
			cout << endl;
		}

	}
}
