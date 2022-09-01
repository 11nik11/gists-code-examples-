using System;

namespace prog
{
    public class Program
    {

        static void Main()
        {
            // Вводим переменную длины
            int size = 0;
            size = int.Parse(Console.ReadLine());

            // Создаём и инициализируем двумерный массив
            // квадратный, рамером size*size
            int[,] arr = new int[size, size];

            // row = 0, [1][2][3]
            // row = 1, [4][5][6]
            // row - строка, column - столбец;
            // на схеме выше row = 3, column = 2,
            int row = 3,  column = 2;
            int[,] explain = new int[row, column];

            // Заполняем массив от 1 до длины (arr.Length)
            // arr.GetLength(0) -- кол-во строк, arr.GetLength(0) -- кол-во столбцов
            for (int i = 0, accum = 1; i < arr.GetLength(0); i++) // До конца 1 измерения
                for (int j = 0; j < arr.GetLength(1); j++, accum++) // До конца 2 измерения
                    arr[i, j] = accum;

            // Выводим все элемены массива первая строка с начала -> вторая строка с начала 
            // e - “read-only variable type”, изменить не можем, только читать
            foreach (int e in arr)
                Console.WriteLine(e);

            // Общая длина массива (в одну линию), без разбиения по координатам
            Console.WriteLine(arr.Length);

            // Размерность (мерность массива/матрицы), у нас двумерный, Rank == 2
            Console.WriteLine(arr.Rank);
        }
    }

}