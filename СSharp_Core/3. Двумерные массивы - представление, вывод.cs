using System;

namespace prog
{
    public class Program
    {

        static void Main()
        {
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("y = ");
            int y = int.Parse(Console.ReadLine());

            //Initialization 
            int[,] array = new int[x, y];

            //Заполнение числами от 0 до длины
            for(int accum = 1,  i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++, accum++)
                {
                    array[i, j] = accum;
                }
            }

            Console.WriteLine();
            // Output to screen
            for (int accum = 1, i = 0; i < array.GetLength(0); i++)
            {
                Console.Write($"Строка [{i}]: ");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"\t[{j}] = {array[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }

}