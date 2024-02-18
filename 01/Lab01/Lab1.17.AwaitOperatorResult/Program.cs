using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Lab1._17.AwaitOperatorResult
{
    internal class Program
    {
        int LongTimeOperation()
        {
            Console.WriteLine("Long time operation started");
            int summa = 0;
            for (int i = 0; i <= 1000; i++)
            {
                summa += i;
                Thread.Sleep(1);
            }
            Console.WriteLine("Long time operation finished");
            return summa;
        }

        async Task<int> LongTimeOperationAsync()
        {
            Console.WriteLine("Long time operation async started");
            int result = await Task<int>.Run(LongTimeOperation);
            Console.WriteLine("Long time operation finished started");
            return result;
        }

        Task<int> Adder(int a, int b)
        {            
            int summa = 0;
            for (int i = a; i <= b; i++) summa += i;

            return Task.FromResult(summa);
        }

        //Не используется в .NET Framworke 4.8
        //ValueTask<int> Adder2(int a, int b)
        //{
        //    int summa = 0;
        //    for (int i = a; i <= b; i++) summa += i;
        //    return new ValueTask<int>(summa);
        //}

        static async Task Main(string[] args)
        {
            Program prg = new Program();

            Console.WriteLine("Main started");
            int result = await prg.LongTimeOperationAsync();
            Console.WriteLine($"Main finished. result  = {result}");

            int result2 = await prg.Adder(0, 1000);
            Console.WriteLine($"Main finished. result2  = {result2}");


            //int result3 = await Adder2(0, 1000);
            //Console.WriteLine($"Main finished. result3  = {result3}");
        }
    }
}
