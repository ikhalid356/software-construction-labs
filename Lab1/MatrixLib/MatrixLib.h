// MathLibrary.h - Contains declaration of Function class  
#pragma once  

#ifdef MATRIXLIB_EXPORTS  
#define MATRIXLIB_API __declspec(dllexport)   
#else  
#define MATRIXLIB_API __declspec(dllimport)   
#endif  

namespace MatrixLib
{
	// This class is exported from the MathLibrary.dll  
	class Functions
	{
	public:
		static MATRIXLIB_API void MatTrns(int matA[3][3]);
		static MATRIXLIB_API void add(int matA[3][3], int matB[3][3]);
		static MATRIXLIB_API void sub(int matA[3][3], int matB[3][3]);
		static MATRIXLIB_API void multiply1(int a[3][3], int b[3][3]);
	};
}
