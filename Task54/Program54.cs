/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2  */

// -------------------МЕТОДЫ----------------------------------------------------------------------------
// -------------------РАНЕЕ ИСПОЛЬЗОВАВШИЕСЯ МЕТОДЫ----------------------------------------------------------------------------
int InputNumber(string qwerStr)//проверяет "численность"."Не выпускает" без ввода ЧИСЛА
{
    int num;
    string? text;
    while (true)
    {
        Console.WriteLine(qwerStr);
        text = Console.ReadLine();
        if (int.TryParse(text, out num)) break;
        Console.WriteLine("Введено некорректное значение.Попробуйте еще раз");
    }
    return num;
}
//------------------------------------------------------------------------------------------------------
int InputNumberWithFilter(string qwerStr, bool zeroEnable, bool negativEnable)//Пропускает положительные. 0 и отрицательные пропускает в соответствии со булевыми значениями zeroEnable,negativEnable
{
    int num;
    while (true)
    {
        num = InputNumber(qwerStr);//проверяет "численность"."Не выпускает" без ввода ЧИСЛА
        if (num > 0 || num == 0 && zeroEnable || num < 0 && negativEnable) break;
        Console.WriteLine("Введено не разрешенное значение.Попробуйте еще раз");
    }
    return num;
}
//------------------------------------------------------------------------------------------------------
//ЗАПОЛНЕНИЕ ДВУМЕРНОГО МАССИВА ЦЕЛЫМИ ЧИСЛАМИ 
int[,] FillMatrix(int rows, int cols)
{
    Random rand = new Random();
    int[,] matr = new int[rows, cols];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matr[i, j] = rand.Next(0, 100);
        }
    }

    return matr;
}
//-----------------------------------------------------------------------------------------------------------

void PrintMatrix(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            System.Console.Write(matr[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}
//-------------------ДЛЯ ДАННОГО ДЗ-----------------------------------------------------------------------------------

void BubbleSortIntMatrixInRowsDecr(int[,] matrix)//Сортировка пузырьком по убыванию внутри строк  Int-матрицы
//Напрашивающееся Вынесение в отдельный метод сортировки одной строки в ДАННОМ случае не очень осмысленно.
{
    for (int k = 0; k < matrix.GetLength(0); k++)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[k, j + 1] > matrix[k, j])// Если знак < -то сортировка по возрастанию
                {
                    int temp = matrix[k, j + 1];
                    matrix[k, j + 1] = matrix[k, j];
                    matrix[k, j] = temp;
                }
            }
        }
    }
}

//------------------------------------------------------------------------------------------------------
// -------------------ОСНОВНАЯ ПРОГРАММА----------------------------------------------------------------------------
int m = InputNumberWithFilter("Введите m - количество СТРОК массива (матрицы):", false, false);
int n = InputNumberWithFilter("Введите n - количество СТОЛБЦОВ(КОЛОНОК) массива (матрицы):", false, false);
int[,] matrix = FillMatrix(m, n);
System.Console.WriteLine("Исходная матрица:");
PrintMatrix(matrix);
System.Console.WriteLine("Итоговая матрица");
BubbleSortIntMatrixInRowsDecr(matrix);
PrintMatrix(matrix);

