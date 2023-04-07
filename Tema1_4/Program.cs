using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tema1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");
            //Масив для збереження лямбда-виразів
            Action[] actions = new Action[2];
            //Створення першого лямбда-виразу та присвоєння його в комірку actions[0]
            actions[0] = () =>
            {
                Console.WriteLine($"First task start");
                int result = 0;
                for (int i = 0; i < 5; i++)
                {
                    result = result + i;
                    Console.WriteLine($"First task do something");
                    Thread.Sleep(200);
                }
                Console.WriteLine($"First task result is {result}");
            };
            //Створення другого лямбда-виразу та присвоєння його в комірку actions[1]
            actions[1] = () =>
            {
                Console.WriteLine($"Second task start");
                int result = 0;
                for (int i = 0; i < 5; i++)
                {
                    result = result + i * 5;
                    Console.WriteLine($"Second task do something");
                    Thread.Sleep(300);
                }
                Console.WriteLine($"Second task result is {result}");
            };

            //Запуск на виконання створених виразів
            Parallel.Invoke(actions);
            Console.WriteLine("Main Thread is done.");
        }
    }
}
