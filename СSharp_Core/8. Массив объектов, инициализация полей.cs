using System;

namespace ConsoleApp3
{
    class City
    {
        public string Name;
        public GeoLocation Location;

        public City()
        {
            Name = "Default";
        }

    }
    class GeoLocation
    {
        public double Latitude = 0;
        public double Longitude = 0;
    }

    public class Class1
    {

        static void Main(string[] args)
        {
            // Создаём ссылку, помечаем что она будет указывать на массив классов (типов) City
            // присваиваем ссылке указатель на массив City длиной 1,
            // стандартно каждый элемент массива City равен null, ссылки никуда не указывают
            // -
            // Создаём объект City и ссылку на него кладём в элемент Array[0], который изначально был null
            // У экземпляра объекта (в данном случае нулевому), полю Name присваиваем значение my_city_1

            City[] Array;                                                             // Array -> (null)
            Array = new City[1];                                                      // Array -> (null), (null), (null)... [count]

            //Array[0].Name = "Try_call_me"   -- Не будет работать! тк там null пока что 
            Array[0] = new City();                                                    // Array -> (obj: City), (null), (null)
            Array[0].Name = "my_city_1";
            Console.WriteLine(Array[0].Name);


            //Сокращённый синстаксис
            City[] don_oblast = new City[3];

            don_oblast[0] = new City();
            don_oblast[0].Name = "Rostov";

            // Присваивание значения в одну строку
            don_oblast[1] = new City() { Name = "Taganrog" };

            //даже ещё короче, но можно запутаться, т.к. нет скобок конструктора
            don_oblast[2] = new City { Name = "Remontnoe" };


            //В одну строку всё и даже без скобочек!!!
            //тип[] имя_переменной_массива = new тип[_длина_] { инициализатор длиной _длина_ };
            City[] don_oblast_copy = new City[3] {
                                                    new City{ Name = "Rostov" },
                                                    new City{ Name = "Taganrog" },
                                                    new City{ Name = "Remontnoe" }
                                                 };

            foreach (City cit in don_oblast_copy)
                Console.WriteLine(cit.Name);

            //Ещё примеры
            Phone[] Arr = new Phone[2] { new Phone() {Name = "Huawei"}, new Phone {Name = "Iphone"} };

            var array_one = new[] { new Phone{ Name = "Huawei" }, new Phone{ Name = "Iphone" } };  //Самый короткий вариант вообще

        }
    }
}