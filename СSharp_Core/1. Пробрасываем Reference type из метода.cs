using System;

namespace prog
{
    public class Program
    {
        // Создаём массив (данные в куче) здесь и пробрасываем ссылку в Main
        static int[] Foo(int len)
        {
            int[] arr = new int[len];
            return arr;
        }

        // Модифицируем массив по ссылке
        static void modify(int[] some_ref)
        {
            some_ref[0] = 200;
        }

        static void Main()
        {
            int[] some_ref = null;
            if (some_ref == null) Console.WriteLine("null");

            some_ref = Foo(1);

            Console.WriteLine(some_ref[0]);

            modify(some_ref);

            Console.WriteLine(some_ref[0]);

            Console.ReadKey();
        }
    }

}