using System;
using System.Collections.Generic;

namespace prog
{
    public class Program
    {

        static void Main(string[] args)
        {
            // Создаём список(лист) строк, инициализируем значениями
            List<string> alphabet_arr = new List<string>() {"AF","A","A","B","C","C"};

            // Вывод листа(массива) строк
            for (int i = 0; i < alphabet_arr.Count; i++)
                Console.WriteLine(alphabet_arr[i]);

            Console.WriteLine("\n" + alphabet_arr.Count + "\n");

            // Создаём пустой словарь, где ключ -- строка, а значение -- число
            Dictionary<string, int> dic = new Dictionary<string, int>();

            // Пробегаемся по массиву строк,
            // если i строка содержится в словаре, то у такого ключа значение++
            // если такой строки нет, то добавляем её в словарь со значением 1.
            for(int i = 0; i < alphabet_arr.Count; i++)
            {
                if (dic.ContainsKey(alphabet_arr[i]))
                {
                    dic[alphabet_arr[i]]++;       // Инкремент ключа, равного строке alphabet_arr[i]
                }
                else
                {
                    dic.Add(alphabet_arr[i], 1);
                    // или возможен такой вариант, добавляем ключ в словарь со значением 0
                    //dic[alphabet_arr[i]] = 0;
                } 
            }

            // Вывод словаря в консоль
            foreach(var e in dic)
                Console.WriteLine(e);

        }
    }

}