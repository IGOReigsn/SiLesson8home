/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/


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
void FindRowWithMinSumOfValuesInIntMatrix(int[,] matrix)//Поиск строки с минимальной суммой
//Можно было-бы сделать не void a int -и возвращать индекс(или номер строки)
// решаем задачу за 1 проход без промежуточного запоминания сумм
{
    int min = -1;//произвольное значение
    int minIndex = -1;//произвольное (и не реальное)
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum = sum + matrix[i, j];
        }
        if (i == 0 || sum < min)// запоминаем на 0-й строке и при нахождении нового минимума
        {
            min = sum;
            minIndex = i;
        }
    }
    System.Console.WriteLine($"{minIndex + 1} строка");
}

//------------------------------------------------------------------------------------------------------
// -------------------ОСНОВНАЯ ПРОГРАММА----------------------------------------------------------------------------
int m = InputNumberWithFilter("Введите m - количество СТРОК массива (матрицы):", false, false);//только положительные
int n = InputNumberWithFilter("Введите n - количество СТОЛБЦОВ(КОЛОНОК) массива (матрицы):", false, false);//только положительные
int[,] matrix = FillMatrix(m, n);
System.Console.WriteLine("Исходная матрица:");
PrintMatrix(matrix);
System.Console.WriteLine("Итог:");
FindRowWithMinSumOfValuesInIntMatrix(matrix);

