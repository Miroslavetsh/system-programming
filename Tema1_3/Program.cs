using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tema1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");
            //Створення завдання за допомги лямбда виразу
            Task tsk1 = Task.Factory.StartNew(() =>
            {
                int taskId = (int)Task.CurrentId;
                Console.WriteLine($"LambdaTask [{taskId}] is started");
                for (int count = 0; count < 5; count++)
                {
                    int sleepTime = 200 * taskId;
                    Thread.Sleep(sleepTime);
                    Console.WriteLine($"LambdaTask [{taskId}] go sleep for {sleepTime} milliseconds");
                    Console.WriteLine($"LambdaTask [{taskId}] work iteration counter = {count}");
                }
                Console.WriteLine($"Task [{taskId}] is done");
            });

            tsk1.Wait();
            tsk1.Dispose();

            Console.WriteLine("Main Thread is done.");
        }
    }
}
