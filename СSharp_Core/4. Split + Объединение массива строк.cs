using System;
using System.Collections.Generic;

namespace prog
{
    public class Program
    {

        static void Main(string[] args)
        {
            //Запихиваем массив строк args (аргументы из командной строки) в одну строку через пробел 
            string connect = string.Join(" ", args);
            Console.WriteLine(connect);

            //return;

            Console.WriteLine();
            Console.WriteLine("Второй, ручной вариант:");
            Console.WriteLine("[отделяем слова, начинающиеся с большой буквы]");
            Console.WriteLine();

            //Это строка принимается как аргумет в изначальной задаче
            string[] lines = args;
            List<string> dyno_container = new List<string>();

            for (int i = 0; i < lines.Length-1; i++)
            {
                foreach (string el in lines[i].Split(' '))
                // lines[i] - строка, а split создаёт множество строк,
                // в изначальной строке, выбрасывается симовол ' '
                // при этом он означает границу n строки и следующей
                // (строка1)' '(строка2)' '(строка3)
                // или условно иллюстрация:
                // (объект1)|(объект2)|(объект3)
                {
                    if (el.Length != 0 && char.IsUpper(el[0]))
                    {
                        dyno_container.Add(el + " ");
                    }
                }
            }
            //dyno_container.Reverse();
            string answer = String.Join("", dyno_container);
            // answer - строка, а dyno_container - массив
            // Join - записывает массив строк в одну строку с разделителем ""

            //Что делает Join по сути
            /*
                foreach (string e in dyno_container)
                answer += e + " ";
            */

            Console.WriteLine(answer);

        }
    }

}