using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_3
{
    internal class Program
    {
        static double[] dataDouble;
        static int[] dataInt;
        static void Function1(double i)
        {
            i = i / 10;
        }
        static void Function2(double i)
        {
            i = i / Math.PI;
        }
        static void Function3(double i)
        {
            i = Math.Pow(Math.E, i) / Math.Pow(i, Math.PI);
        }
        static void Function4(double i)
        {
            i = Math.Pow(Math.E, Math.PI * i) / Math.Pow(i, Math.PI);
        }

        static void Function1Int(int i)
        {
            i = i / 10;
        }
        static void Function2Int(int i)
        {
            i = (int)(i / Math.PI);
        }
        static void Function3Int(int i)
        {
            i = (int)(Math.Pow(Math.E, i) / Math.Pow(i, Math.PI));
        }
        static void Function4Int(int i)
        {
            i = (int)(Math.Pow(Math.E, Math.PI * i) / Math.Pow(i, Math.PI));
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
            CalculateDouble(Function1);
            Console.WriteLine("Function 2");
            CalculateDouble(Function2);
            Console.WriteLine("Function 3");
            CalculateDouble(Function3);
            Console.WriteLine("Function 4");
            CalculateDouble(Function4);

            Console.WriteLine("Function 1 int");
            CalculateInt(Function1Int);
            Console.WriteLine("Function 2 int");
            CalculateInt(Function2Int);
            Console.WriteLine("Function 3 int");
            CalculateInt(Function3Int);
            Console.WriteLine("Function 4 int");
            CalculateInt(Function4Int);
            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
        static void CalculateDouble(Action<double> function)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(dataDouble, function);
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < dataDouble.Length; i++)
            {
                function(i);
            }
            sw.Stop();
            Console.WriteLine("Serial Transformation = " + sw.Elapsed.TotalSeconds + " seconds.");
        }
        static void CalculateInt(Action<int> function)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(dataInt, function);
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < dataDouble.Length; i++)
            {
                function(i);
            }
            sw.Stop();
            Console.WriteLine("Serial Transformation = " + sw.Elapsed.TotalSeconds + " seconds.");

        }
    }
}
