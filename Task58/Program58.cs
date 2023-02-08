/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

//-----------ПЕЧАТЬ ДВУМЕРНОГО ДУБЛЕ-МАССИВА-------------------------------------------------------------------------------------------
void PrintMatrixDouble(double[,] matrix)//ПЕЧАТЬ ДВУМЕРНОГО ДУБЛЕ-МАССИВА
{
for (int i = 0; i < matrix.GetLength(0); i++)
{
for (int j = 0; j < matrix.GetLength(1); j++)
{
System.Console.Write(matrix[i, j] + "\t");
}
System.Console.WriteLine();
}
}


double[,] matrA = new double[2, 2];
double[,] matrB = new double[2, 2];
matrA[0, 0] = 2; matrA[0, 1] = 4;
matrA[1, 0] = 3; matrA[1, 1] = 2;
matrB[0, 0] = 3; matrB[0, 1] = 4;
matrB[1, 0] = 3; matrB[1, 1] = 3;
double[,] matrC = new double[matrA.GetLength(0), matrB.GetLength(1)];
for (int i = 0; i < matrA.GetLength(0); i++)
{
    for (int j = 0; j < matrB.GetLength(1); j++)
    {
        matrC[i, j] = 0;
        for (int k = 0; k < matrA.GetLength(1); k++)
        {
            matrC[i, j] = matrC[i, j] + matrA[i, k] * matrB[k, j];
        }
    }

}
PrintMatrixDouble(matrC);