#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <ctime>
#include <omp.h>
#include "MMM.h"
using namespace std;

int* InitializeMatrix(int m, int n)
{
	int* q = new int[m * n];
	for (int i = 0; i < m; i++) 
	{
		for (int j = 0; j < n; j++)
		{
			q[i*n + j] = rand() % 201 - 100;
		}
	}		
	return q;
}

int* InitializeZeroMatrix(int m, int n)
{
	int* q = new int[m * n];
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++) 
		{
			q[i*n + j] = 0;
		}
	}
	return q;
}

void BlockMultiply(int* A, int* B, int* C, int n1, int n3, int n2, int block_size, int threads)
{
	int nn1 = n1 / block_size;
	int nn2 = n2 / block_size;
	int nn3 = n3 / block_size;

	omp_set_num_threads(threads);
	#pragma omp parallel for
	for (int i1 = 0; i1 < nn1; i1++) 
	{
		for (int j1 = 0; j1 < nn2; j1++) 
		{
			for (int k1 = 0; k1 < nn3; k1++) 
			{
				for (int i2 = 0; i2 < block_size; i2++) 
				{
					for (int j2 = 0; j2 < block_size; j2++) 
					{
						for (int k2 = 0; k2 < block_size; k2++) 
						{
							int i = i1 * block_size + i2;
							int j = j1 * block_size + j2;
							int k = k1 * block_size + k2;
							C[i * n3 + j] += A[i * n2 + k] * B[k * n3 + j];
						}
					}
				}
			}
		}
	}
}

void main(int argc, char ** argv)
{
	int n, m, k, block_size, threads;
	for (int i = 1; i < argc; i += 2) 
	{
		cout << argv[i] << " = " << argv[i+1] << endl;
	}
	for (int i = 1; i < argc; i += 2)
	{
		if (string(argv[i]) == "-n") n = atoi(argv[i + 1]);
		else if (string(argv[i]) == "-m") m = atoi(argv[i + 1]);
		else if (string(argv[i]) == "-k") k = atoi(argv[i + 1]);
		else if (string(argv[i]) == "-r") block_size = atoi(argv[i + 1]);
		else if (string(argv[i]) == "-t") threads = atoi(argv[i + 1]);
		else 
		{
			cout << "Error. Incorrect format." << endl;
			return;
		}
	}
	int* A = InitializeMatrix(m, n);
	int* B = InitializeMatrix(n, k);
	int* C = InitializeZeroMatrix(m, k);
	
	clock_t start = clock();
	BlockMultiply(A, B, C, m, n, k, block_size, threads);
	double duration = (clock() - start) / (double)CLOCKS_PER_SEC;

	ofstream fout;
	fout.open("output.txt", ios_base::app);
	fout << "m=" << m << " n=" << n << " k=" << k << " blockSize=" << block_size << " threads=" << threads << " duration=" << duration << endl;
	fout.close();
	cout << duration << endl;
}

