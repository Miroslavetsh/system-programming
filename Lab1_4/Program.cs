using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4
{
    internal class Program
    {
        static double[] dataDouble;
        static int[] dataInt;
        static double number = 1000;
        static double offset = 100;

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
            sw.Reset();
            sw.Start();
            Parallel.ForEach(dataDouble, (double i) =>
            {
                i = i / 10;
            });
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");

            Console.WriteLine("Function 2");
            sw.Reset();
            sw.Start();
            Parallel.ForEach(dataDouble, (double i) =>
            {
                i = i / Math.PI;
            });
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");

            Console.WriteLine("Function 3");
            sw.Reset();
            sw.Start();
            Parallel.ForEach(dataDouble, (double i) =>
            {
                i = Math.Pow(Math.E, i) / Math.Pow(i, Math.PI);
            });
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");

            Console.WriteLine("Function 4");
            sw.Reset();
            sw.Start();
            Parallel.ForEach(dataDouble, (double i) =>
            {
                i = Math.Pow(Math.E, Math.PI * i) / Math.Pow(i, Math.PI);
            });
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");
            
            Console.WriteLine();

            Console.WriteLine("Function 1 int");
            sw.Reset();
            sw.Start();
            Parallel.ForEach(dataInt, (int i) =>
            {
                i = i / 10;
            });
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");

            Console.WriteLine("Function 2 int");
            sw.Reset();
            sw.Start();
            Parallel.ForEach(dataInt, (int i) =>
            {
                i = (int)(i / Math.PI);
            });
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");

            Console.WriteLine("Function 3 int");
            sw.Reset();
            sw.Start();
            Parallel.ForEach(dataInt, (int i) =>
            {
                i = (int)(Math.Pow(Math.E, i) / Math.Pow(i, Math.PI));
            });
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");

            Console.WriteLine("Function 4 int");
            sw.Reset();
            sw.Start();
            Parallel.ForEach(dataInt, (int i) =>
            {
                i = (int)(Math.Pow(Math.E, Math.PI * i) / Math.Pow(i, Math.PI));
            });
            sw.Stop();
            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}
