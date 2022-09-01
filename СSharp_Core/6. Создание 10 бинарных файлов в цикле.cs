using System;
using System.Collections.Generic;
//System.IO;
//Reflection

namespace prog
{
    public class Program
    {

        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                // Генерируем путь файла, в данном случае просто имя файла
                // Магический метод (string.Format()), который работает под капотом Cw 
                // Записываем 1024*10 байт в файл с относительным путём
                // Выводим путь и имя сгенерированного файла

                
                string gen_file_name = string.Format($"bin{i}.dat"); 

                File.WriteAllBytes(gen_file_name, new byte[10240]); 
               
                Console.WriteLine(Path.Combine(Environment.CurrentDirectory, gen_file_name)); 

            }


            // Удаление созданных файлов :)
            foreach (var p in Enumerable.Range(0, 10))
            {
                var temp = string.Format("bin{0}.dat", p);
                File.Delete(temp);
            }


            // Вывести длину файла
            Console.WriteLine(File.ReadAllBytes("bin0.dat").Length);

            // Вывод имени сборки, культура и какой-то публичный токен
            Console.WriteLine(Assembly.GetExecutingAssembly().FullName);

            // Вывод размещения запущенной сборки (dll или exe файла)
            Console.WriteLine(Assembly.GetExecutingAssembly().Location); 

            // Вывод файлов в текущей директории
            Console.WriteLine("Файлы в текущей директории, начинающиеся с \"b\":");
            foreach (string str in Directory.GetFiles(".", "b*"))
                Console.WriteLine(str);

        }
    }

}