using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._17.AwaitMultiple
{
    internal class Program
    {
        Random rnd = new Random();
        async Task<int> PrintAsync(string message)
        {
            int delay = rnd.Next(1000);
            await Task.Delay(delay);
            Console.WriteLine(message);
            return delay;
        }

        static async Task Main(string[] args)
        {
            Program prg = new Program();
            Task<int> t1 = prg.PrintAsync("Hello");
            Task<int> t2 = prg.PrintAsync("C#");
            Task<int> t3 = prg.PrintAsync("!");

            await Task.WhenAll(t1, t2, t3);
            //await Task.WhenAny(t1, t2, t3);
            Console.WriteLine("Main finished");
            Console.WriteLine($"t1: {t1.Result} t2: {t2.Result} t3: {t3.Result}");
        }
    }
}
