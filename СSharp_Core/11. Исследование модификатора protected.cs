using System;

namespace ConsoleApp3
{

    // Класс-прародитель
    class ClassA
    {
        // приватное динамическое поле, доступно только ВНУТРИ ЭТОГО класса в методах
        // НЕ НАСЛЕДУЕТСЯ в классы-наследники
        private string name = "Default";

        // динамическое поле с доступом protected
        // ДОСТУПНО только в этом классе, как и private, только НАСЛЕДУЕТСЯ
        protected int x = -1, y = -1, z = -1;


        // переопределение метода ToString для данного класса (т.е. для всех экземпляров)
        public override string ToString()
        {
            return String.Format($"{this.GetType()}\t  x = {x}, y = {y}, z = {z}, \t{ClassA.text}");
        }

        // статическое поле c доступом protected
        // ВЕДЁТ СЕБЯ КАК ОБЩАЯ ПЕРЕМЕННАЯ классов ClassA и ClassB, и каждая доступна в любом из низ
        // при изменении ClassA.text в любом месте (классе), где доступна, автоматом меняется и ClassB.text
        protected static string text = "ClassA - Default static string";

        public void Test()
        {
            ClassB.text = "Из ClassA есть доступ к статическому полю класса-наследника ClassB";
        }
    }




    // Класс-наследник класса ClassA
    class ClassB : ClassA
    {
        //поля x, y, z здесь тоже есть, унаследованы от класса-прародителя

        // Конструктор, который устанавливает приватные поля, поскольку
        // прямого доступа из класса Program нет к этим полям
        public ClassB(int x, int y, int z)
        {
            // До того, как сработал конструктор, значения x, y и z берутся из класса-прародителя
            // и будут все равны -1
            Console.WriteLine("CONSTRUCTOR " + this.ToString());

            this.x = x;
            this.y = y;
            this.z = z;

            // Меняем статическое поле текущего класса, т.к. значение наследуется от ClassB
            ClassB.text = "set text of ClassB in CONSTRUCTOR ClassB";
        }

        // Производим какие-то действия над protected переменными
        public void DoSomething()
        {

            //name = "Man"; ОШИБКА, name не наследуется

            x = 777; y = 888; z = 999;
            ClassA.text = "ClassA - RENEWED string in ClassB";
        }

        // У этого класса также есть метод ToString, он был унаследован

    }




    public class Program
    {

        public static void Main()
        {
            // Экземляр ClassA
            var First = new ClassA();

            // Выводим значение полей ClassA
            Console.WriteLine("!new " + First.ToString());
            Console.WriteLine();


            // Экземляр ClassB
            var Second = new ClassB(100, 100, 100);

            // Выводим значение полей ClassB
            Console.WriteLine("!new " + Second.ToString());

            // Выводим ещё раз значение полей ClassA
            // в конструкторе ClassB мы поменяли ClassB.text, но поменялясь и ClassA.text!!!
            Console.WriteLine(First.ToString());
            Console.WriteLine();

            //First.x = 0;  Ошибка, поля недоступны из какого-либо внешнего класса
            //Second.x = 0;


            // Производим Действие в ClassA
            // Доступа к x,y,z из ClassB в ClassA нет 
            Second.DoSomething();
            Console.WriteLine("DoSomething()");

            // Опять статическое поле text меняестся у обоих классов
            Console.WriteLine(First.ToString());
            Console.WriteLine(Second.ToString());


            return;

        }

    }
}