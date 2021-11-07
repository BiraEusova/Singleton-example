using System;
using System.Threading;

namespace Singleton
{

    class Program
    {

        static void Main(string[] args)
        {
            // Клиентский код.         
            Console.WriteLine(
                "{0}\n{1}\n\n{2}\n",
                "Если все строки одинаковы значит существует всего один экземляр объекта и все здорово :)",
                "Если выводы разные, то что-то пошло не так :(",
                "Посмтрим, что вышло:"
            );
            
            // Создадим несколько потоков, чтобы проверить работу Одиночки
            // По-хорошему, самый быстрый поток должен создать объект одиночку,
            // а остальные потоки, должны вернуть этот объект, а не создавать новый.
            Thread process1 = new Thread(() =>
            {
                TestSingleton("Йоу, пис, камон)0)");
            });

            Thread process2 = new Thread(() =>
            {
                TestSingleton("Люблю бабушкин морсик :)");
            });

            Thread process3 = new Thread(() =>
            {
                TestSingleton("Рисовая кашка от фрутоняни топ!");
            });

            process1.Start();
            process2.Start();
            process3.Start();

            process1.Join();
            process2.Join();
            process3.Join();
        }
        
        public static void TestSingleton(string value)
        {
            Singleton singleton = Singleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        } 
    }
}