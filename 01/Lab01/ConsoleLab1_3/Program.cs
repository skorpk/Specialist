using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleLab1_3
{
    class Sync 
    {
        //public double x = 1;
        public double X { get; set; } = 1;

        public bool Phase { get; set; } = true;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Sync sync = new Sync();
            

            Thread tr1 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    lock (sync)
                    {
                        while (!sync.Phase)
                            Monitor.Wait(sync);

                        sync.X = Math.Cos(sync.X);

                        Console.Write($"Значение COS = {sync.X.ToString()}");

                        sync.Phase = !sync.Phase;
                        Monitor.Pulse(sync);
                    }
                }
            })
            { Name = "A" };

            Thread tr2 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    lock (sync)
                    {
                        while (sync.Phase)
                            Monitor.Wait(sync);

                        sync.X = Math.Acos(sync.X);

                        Console.WriteLine($" Значение ArCOS = {sync.X.ToString()}");
                        sync.Phase = !sync.Phase;
                        Monitor.Pulse(sync);
                    }
                }
            })
            { Name = "B" };

            tr1.Start();
            tr2.Start();
        }
    }
}
