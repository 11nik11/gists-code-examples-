using System;

namespace ConsoleApp3
{
    //Мой интерфейс
    public interface MyInterface
    {
        // Метод, который должен быть в классе (иметь реализацию), который будет наследовать (реализовывать этот интерфейс)
        void Show();
        
        // Свойство, аналогично методу выше
        int Some_property { get; set; }

    }

    //Просто класс, чтобы сделать наследника
    class Beep
    {
        public int BEEPclass = -100;

    }


    // Класс Phone наследует класс Beep и два интерфейса: IComparable и MyInterface
    class Phone : Beep, IComparable<Phone>, MyInterface
    {
        public string Name = "Default";

        public int CPU;

        //Реализация свойства интерфейса!
        public int Some_property { get; set; }

        //Конструктор
        public Phone()
        {
            Console.WriteLine("COSTRUCTOR! " + Name);
        }

        // Моё сравнение для класса Phone
        public int CompareTo(Phone argument)
        {

            if (this.CPU > argument.CPU) return 1;
            else if (CPU < argument.CPU) return -1;
            else return 0;

            // Метод CompareTo по сути является частным случаем сортировки. По сути это сортировка двух элементов.
            // a.CompareTo(B) возращает позицию a относительно B, если a > B, то вернётся 1, если a < B, то -1, если равны, то 0. 
        }

        //Реализация метода интерфейса!
        public void Show() => Console.WriteLine("Name: " + Name + " CPU: " + CPU + " Beep: " + BEEPclass);
    }



    // Какой-то класс, который реализует мой интерфейс
    public class SomeClassWithMyInterface : MyInterface
    {
        //Динамическое поле класса (для галочки)
        public string name;
        //Статическое поле класса (для галочки)
        public static int parent = 1;

        public int Some_property { get; set; }

        public void Show() => Console.WriteLine("Show");
    }
}


namespace ConsoleApp3
{

    public class Program
    {

        public static void Main()
        {
            // Создаём объекты

            var Huawei = new Phone { Name = "Huawei ", CPU = 8, BEEPclass = 0 };
            var Iphone = new Phone { Name = "Iphone", CPU = 6 };
            var Samsung = new Phone { Name = "Samsung", CPU = 10 };
            var Default = new Phone();



            // Сравниваем объекты

            var test = 0.CompareTo(1);
            Console.WriteLine("0 Comp 1 --> " + test);
            var ans = Default.CompareTo(Samsung);

            Console.WriteLine(ans);
        }

    }

}