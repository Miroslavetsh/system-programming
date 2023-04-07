using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2
{
    internal class Program
    {
        static double[] dataDouble;
        static int[] dataInt;
        const double number = 1000;
        const double offset = 100;
        static void Function1(int i, ParallelLoopState pls)
        {
            if (Math.Abs(dataDouble[i] - number) <= offset) pls.Break();
            dataDouble[i] = dataDouble[i] / 10;
        }
        static void Function2(int i, ParallelLoopState pls)
        {
            if (Math.Abs(dataDouble[i] - number) <= offset) pls.Break();
            dataDouble[i] = dataDouble[i] / Math.PI;
        }
        static void Function3(int i, ParallelLoopState pls)
        {
            if (Math.Abs(dataDouble[i] - number) <= offset) pls.Break();
            dataDouble[i] = Math.Pow(Math.E, dataDouble[i]) / Math.Pow(dataDouble[i], Math.PI);
        }
        static void Function4(int i, ParallelLoopState pls)
        {
            if (Math.Abs(dataDouble[i] - number) <= offset) pls.Break();
            dataDouble[i] = Math.Pow(Math.E, Math.PI * dataDouble[i]) / Math.Pow(dataDouble[i], Math.PI);
        }

        static void Function1Int(int i, ParallelLoopState pls)
        {
            if (Math.Abs(dataInt[i] - number) <= offset) pls.Break();
            dataInt[i] = dataInt[i] / 10;
        }
        static void Function2Int(int i, ParallelLoopState pls)
        {
            if (Math.Abs(dataInt[i] - number) <= offset) pls.Break();
            dataInt[i] = (int)(dataInt[i] / Math.PI);
        }
        static void Function3Int(int i, ParallelLoopState pls)
        {
            if (Math.Abs(dataInt[i] - number) <= offset) pls.Break();
            dataInt[i] = (int)(Math.Pow(Math.E, dataInt[i]) / Math.Pow(dataInt[i], Math.PI));
        }
        static void Function4Int(int i, ParallelLoopState pls)
        {
            if (Math.Abs(dataInt[i] - number) <= offset) pls.Break();
            dataInt[i] = (int)(Math.Pow(Math.E, Math.PI * dataInt[i]) / Math.Pow(dataInt[i], Math.PI));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Input array length");
            int n = int.Parse(Console.ReadLine());
            dataDouble = new double[n];
            dataInt = new int[n];
            sw.Start();
            for (int i = 0; i < dataDouble.Length; i++)
            {
                dataDouble[i] = i;
                dataInt[i] = i;
            }
            sw.Stop();
            Console.WriteLine("Serial initialization of cycle=" + sw.Elapsed.TotalSeconds + " seconds.");
            Console.WriteLine("Function 1");
            Calculate(Function1);
            Console.WriteLine("Function 2");
            Calculate(Function2);
            Console.WriteLine("Function 3");
            Calculate(Function3);
            Console.WriteLine("Function 4");
            Calculate(Function4);

            Console.WriteLine("Function 1 int");
            Calculate(Function1Int);
            Console.WriteLine("Function 2 int");
            Calculate(Function2Int);
            Console.WriteLine("Function 3 int");
            Calculate(Function3Int);
            Console.WriteLine("Function 4 int");
            Calculate(Function4Int);
            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
        static void Calculate(Action<int, ParallelLoopState> function)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ParallelLoopResult loopResult = Parallel.For(0, dataDouble.Length, function);
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");
            if(loopResult.IsCompleted == false)
                Console.WriteLine("ParallelFor was aborted on iteration" + loopResult.LowestBreakIteration);
        }
    }
}
