using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleLab1_2
{
    public class ThreadClass
    {

        public void ThreadPrint01()
        {
            Thread.CurrentThread.Name = "Поток 1";
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.Name} = {i}");
            }
        }

        public void ThreadPrint02(object tr)
        {

            if ((tr is Thread t) && tr != null)
            {
                if (t.ThreadState == ThreadState.Unstarted)
                {
                    Console.WriteLine("Ошибка");
                    return;
                }
             
                t.Join();
            }

            Thread.CurrentThread.Name = "Поток 2";

            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.Name} = {i}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadClass ().ThreadPrint01);
            Thread th2 = new Thread(new ThreadClass ().ThreadPrint02);

            th1.Start();            
            Thread.Sleep(1000);
            th2.Start(th1);

        }
    }
}
