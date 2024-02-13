using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1_1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int n = 0;
            object syncObj = new object () ;  

            Thread tr1 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    lock (syncObj) 
                    {
                        n++;
                        Console.WriteLine($"Значение = {n.ToString()} в потоке - {Thread.CurrentThread.Name}");
                    }
                }
            })
            { Name = "A" };

                Thread tr2 = new Thread(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        lock (syncObj)
                        {
                            n++;
                            Console.WriteLine($"Значение = {n.ToString()} в потоке - {Thread.CurrentThread.Name}");
                        }
                    }
                })
                { Name = "B" };

            tr1.Start();
            tr2.Start();
            Console.WriteLine("-----------------");

        }
    }
}
