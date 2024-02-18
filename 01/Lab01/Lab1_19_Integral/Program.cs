using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab1_19_Integral
{
    internal class Program
    {
        const int STEPS = 100000000;
        const int TASK = 10;
        double Single(Func<double, double> f, double a, double b, int steps = STEPS)
        {
            double w = (b - a) / steps;
            double summa = 0d;
            for (int i = 0; i < steps; i++)
            {
                double x = a + i * w + w / 2;
                double h = f(x);
                summa += h * w;
            }
            return summa;
        }

        double Multy(Func<double, double> f, double a, double b)
        {
            double w = (b - a) / TASK;
            double summa = 0d;
            //for (int i = 0; i < TASK; i++)
            //{
            //    summa += Single(f, a + i * w, a + (i + 1) * w, STEPS / TASK);
            //}
            var l = new Object();
            Parallel.For(0, TASK, x =>
            {
                double res = Single(f, a + x * w, a + (x + 1) * w, STEPS / TASK);
                lock (l) summa += res;
            });
            return summa;
        }

        static void Main(string[] args)
        {
            Program prg = new Program();
            Stopwatch t1 = new Stopwatch();
            t1.Start();
            double r1 = prg.Single(Math.Sin, 0, Math.PI / 2);
            t1.Stop();

            Console.WriteLine($"Single result : {r1} Time: {t1.ElapsedMilliseconds}");

            Stopwatch t2 = new Stopwatch();
            t2.Start();
            double r2 = prg.Multy(Math.Sin, 0, Math.PI / 2);
            t2.Stop();

            Console.WriteLine($"Single result : {r2} Time: {t2.ElapsedMilliseconds}");
        }
    }
}
