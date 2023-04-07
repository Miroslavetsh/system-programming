using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tema1_1
{
    class Program
    {
        public static void MyTask()
        {
            int taskId = (int)Task.CurrentId;
            Console.WriteLine($"Task [{taskId}] is started");
            for (int count = 0; count < 5; count++)
            {
                int sleepTime = 200 * taskId;
                Thread.Sleep(sleepTime);
                Console.WriteLine($"Task [{taskId}] go sleep for {sleepTime} milliseconds");
                Console.WriteLine($"Task [{taskId}] work iteration counter = {count}");
            }
            Console.WriteLine($"Task [{taskId}] is done");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");
            //Сконструюввати об'єкти двох задач
            Task tsk1 = new Task(MyTask);
            Task tsk2 = new Task(MyTask);
            //Запустити задачi на виконання
            tsk1.Start();
            tsk2.Start();
            //Відправляємо головний потік в сон на 1.5 секунд
            //Для того щоб дати час попрацювати для створених задач
            Thread.Sleep(1500);

            Console.WriteLine("Main Thread is done.");
        }
    }
}
