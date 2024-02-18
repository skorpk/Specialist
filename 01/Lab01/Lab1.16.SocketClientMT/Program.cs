using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Lab1._16.SocketClientMT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CLIENTS = 100;
            ThreadPool.SetMinThreads(CLIENTS, CLIENTS);
            ThreadPool.SetMaxThreads(CLIENTS, CLIENTS);

            Task[] tasks = new Task[CLIENTS];
            for (int i = 0; i < CLIENTS; i++)
            {
                tasks[i] = new Task(() =>
                {
                    try
                    {
                        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socket.Connect("127.0.0.1", 1111);
                        using (var stream = new NetworkStream(socket))
                        {
                            using (var r = new StreamReader(stream, Encoding.UTF8))
                            {
                                using (var w = new StreamWriter(stream, Encoding.UTF8))
                                {
                                    w.WriteLine($"hello from {Thread.CurrentThread.ManagedThreadId}");
                                    w.Flush();
                                }
                                string result = r.ReadLine();
                                Console.WriteLine(result);

                            }
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                });
            }

            foreach (Task t in tasks) t.Start();

            Task.WaitAll(tasks);

        }
    }
}
