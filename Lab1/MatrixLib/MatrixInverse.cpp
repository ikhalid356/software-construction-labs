#include "stdafx.h"  
#include "MatrixLib.h"  
#include <algorithm>
#include <iostream>

namespace MatrixLib
{
	void Functions::MatTrns(int mat[3][3])
	{
		int result[3][3];

		for (int i = 0; i < 3; i++){
			for (int j = 0; j < 3; j++){
				result[j][i] = mat[i][j];
			}
		}

		for (int i = 0; i < 3; i++){
			for (int j = 0; j < 3; j++){
				std::cout << result[i][j] << "\t";
			}
			std::cout << std::endl;
		}
	}
}
