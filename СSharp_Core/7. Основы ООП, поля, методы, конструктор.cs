using System;
using System.Collections.Generic;

namespace ConsoleApp3
{

    public class Class1
    {

        static void Main(string[] args)
        { 
            Myobj entity_obg = new Myobj();
            Myobj entity_obg2 = new Myobj();

            entity_obg.print();
            entity_obg2.print();
            Console.WriteLine("----- default -----");
            
            entity_obg.line1 = 133;
            Myobj.c = 1000;

            entity_obg.print();
            entity_obg2.print();

        }
    }

    public class Myobj
    {
        static public int c;

        public int line1;
        public int line2;

        public const float gravity = 9.8f;
        
        // Приватный метод, доступный только внутри класса
        private void Print()
        {
            Console.WriteLine("line1 == {0}, line2 == {1}, c == {2}", line1, line2, c);
        }

        public void print()
        {
            Print();
        }

        // Конструктор класса 
        public Myobj()
        {
            start();
        }

        private void start()
        {
            Console.WriteLine("Hi from constructor!   New object of class \"MyObj\" is created.");
        }
    }
}
