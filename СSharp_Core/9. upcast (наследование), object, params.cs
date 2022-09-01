using System;
using System.Collections.Generic;

namespace ConsoleApp3
{

    public static class ArrayExtension
    {
        // Метод-расширение для класса Array, наследниками которого являются любые массивы (int), (string)
        // далее к любому массиву мы обращаемся как к классу Array, делам upcast, методы для конкретных
        // классов становятся недоступны с такой точки зрения. У класса Array есть методы GetValue,
        // SetValue и многие другие, которые позволяют нам абстрагроваться от конкретного типа данных
        // меняем местами значения элементов с индексами i и j
        public static void SwapItoJ(this Array data, int i, int j)
        {
            object temporal = data.GetValue(i);
            data.SetValue(data.GetValue(j), i);
            data.SetValue(temporal, j);
        }


        // Это не метод-расширение.
        // это обычный статический метод
        // Метод используется для вывода элементов любого типа
        public static void Print(params object[] data) //Переменное кол-во входных аргуметов!
        {
            Console.WriteLine("-------START-------");
            for (var i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data.GetValue(i) + "\t тип " + data.GetValue(i).GetType());
            }
            Console.WriteLine("-------END-------"); ;
        }


        //Метод-расширение для вывода массива любого типа на экран
        //! Array содержит элементы Оbject 
        public static void PrintArr(this Array data)
        {

            foreach (object e in data)
            {
                Console.Write(e + " ");
            }

            // C помощью is можно проверить тип данных
            if (data is int[]) Console.WriteLine("\n->" + "type of arry: INT!");
            if (data is char[]) Console.WriteLine("\n->" + "typeof array: Char!");

            Console.WriteLine();
        }


        //Метод-расширение, который появляется у ВСЕХ БАЗОВЫХ ТИПОВ!
        public static void WTF(this object peremennaya)
        {
            Console.WriteLine(peremennaya + " \t" + peremennaya.GetType() + ", вывод для всех типов!");
        }
    }

    public class Program
    {

        public static void Main()
        {
            int[] number = new int[] { 0, 1, 2, 4 };

            object zero = 123;

            object first = "abcdeeeX"; // Универсальный тип (класс), прародитель базовых типов
            string myStr = first.ToString();

            Console.WriteLine("Тест вывода object с переменным кол-вом входных аргументов:");
            ArrayExtension.Print(1, 2, "s", 'q', "qwery", 100, true, 999, false);

            //Вывод строки до Swap
            Console.WriteLine("\n" + "myStr до Swap:");
            Console.WriteLine(myStr);

            //Т.к. строка не Array, string - не трактуется как массив, т.е. нет [] в типе. Поэтому Кастуем к массиву char
            char[] me = myStr.ToCharArray();
            me.SwapItoJ(0, me.Length - 1); //Меняем первый и последний элемент местами

            // Вывод строки после Swap
            myStr = new string(me); //Преобразуем массив обратно в строку
            Console.WriteLine("\n" + "myStr после Swap:");
            Console.WriteLine(myStr);
            //Либо
            me.PrintArr();

            //Swap массивом инт
            Console.WriteLine();
            Console.WriteLine("До:");
            number.PrintArr();


            number.SwapItoJ(0, number.Length - 1); // Метод Swap

            Console.WriteLine("после:");
            number.PrintArr();


            //Тип object, прародитель базовых типов данных
            Console.WriteLine("\n" + "солянка типов с помощью типа object");

            object[] arr = new object[2] { 12345999, "some str" };
            /*arr[0] = new object();
            arr[0] = -1;
            arr[1] = new object();
            arr[1] = "some_str";*/

            foreach (var e in arr)
                Console.WriteLine(e + "\t" + e.GetType());


            //метод-расширение для всех базовых типов данных
            Console.WriteLine("\n" + "чёткий вывод!");
            99.WTF();
            'q'.WTF();
            "ыы".WTF();
            ArrayExtension.WTF(-1.99);

            Console.WriteLine();
            return;

            // Основные идеи
            // -- апкаст (upcast) - создание ссылки (с точки зрения класса-прародителя) на класс-наследник,
            //    при этом можно обощить классы-наследники; остаются только методы класса-прародителя, 
            //    методы самих классов (наследников) становятся недоступны, с такой точки зрения.

            // -- Класс Array содержит и возвращает объекты object - класс-прародитель всех объектов (int, char, ...)
            //    переменной типа object можно присваивать данные любого типа, например число или строковый литерал,
            //    при этом у такой переменной можно будет узнать реальный тип данных методом GetType(). System.Int32

            // -- У класса Array есть методы для доступа к элементам "абстрактного массива", фишка в том, что элементы
            //    представляют собой object, а это может быть любой базовый тип данных, и строки, и символы, и числа
            //    таким образом можно сделать апкастнутую ссылку (дерево классов растёт вниз) и без разницы, какой тип
            //    у массива на более высоком уровне абстракции. Это всё позволяет не писать код для каждого типа по отдельности
            //    обеспечивается принцип DRY

            // -- this в сигнатуре метода означает, что это метор-расширение для этого типа. То есть этот метод появится у
            //    любой переменной этого типа (динамический метод), хотя всё статическое и по логике должна быть статика у метода.
            //    и при этом этот МЕТОД УНИВЕРСАЛЕН, к нему можно обращаться как к статическому, так и как к динамическому. 

            // -- связка: апкаст + метод-расширение позволяет сделать динамический метод (можно использовать как статический)
            //    который ПОЯВИТСЯ У МАССИВОВ ВСЕХ базовых ТИПОВ! Такой же трюк можно провернуть с обычными типами, а не массивами
            // 
            // object --> int, char, string 
            // Array --> int[], char[], string[]

            // -- params - означает, что допустимо переменное кол-во аргументов

        }
    }
}