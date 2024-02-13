using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleLab01
{
    public class ThreadClas
    { 
        public string ThreadName { get; set; }
        public int ThreadNumberFrom { get; set; }
        public int ThreadNumberTo { get; set; }

        public void ThreadExecute()
        { 
            Thread.CurrentThread.Name = ThreadName;
            for (int i = ThreadNumberFrom; i <= ThreadNumberTo; i++)
            {
                  Console.WriteLine($"Поток {Thread.CurrentThread.Name} = {i}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadClas { ThreadName = "AA", ThreadNumberFrom = 1, ThreadNumberTo = 15 }.ThreadExecute);
            Thread th2 = new Thread(new ThreadClas { ThreadName = "BB", ThreadNumberFrom = 1, ThreadNumberTo = 20 }.ThreadExecute);

            th1.Start();
            th2.Start();    
        }
    }
}
