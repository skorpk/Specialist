using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1._17.AwaitOperator
{
    internal class Program
    {
        static void LongTimeOperation()
        {
            Console.WriteLine("Long time operation started");
            Stopwatch sw = Stopwatch.StartNew();
            Thread.Sleep(3000);
            sw.Stop();
            Console.WriteLine($"Long time operation finished.Time is {sw.ElapsedMilliseconds}");
        }

        static async Task LongTimeOperationAsync()
        {
            Console.WriteLine("Long time operation async started");
            Stopwatch sw = Stopwatch.StartNew();
            await Task.Run(LongTimeOperation);
            sw.Stop();
            //_ = Task.Run(LongTimeOperation);
            Console.WriteLine($"Long time operation async finished. Time is {sw.ElapsedMilliseconds}");
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Main started");
            await LongTimeOperationAsync();
            Console.WriteLine("Main finished");
        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main started");
        //    LongTimeOperationAsync();
        //    Console.WriteLine("Main finished");
        //}
    }
}
