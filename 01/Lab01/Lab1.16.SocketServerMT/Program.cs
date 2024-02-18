using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.IO;
using System.Threading;

namespace Lab1._16.SocketServerMT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_CONNECTION_IN_QUEUE = 10; // 10

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 1111);
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(ipPoint);
                socket.Listen(MAX_CONNECTION_IN_QUEUE);
                int req = 0;
                while (req < 100)
                {
                    using (Socket client = socket.Accept())
                    {
                        Console.Write($"Remote client: {client.RemoteEndPoint} ");
                        var stream = new NetworkStream(client);
                        var r = new StreamReader(stream, Encoding.UTF8);
                        var w = new StreamWriter(stream, Encoding.UTF8);
                        string result = r.ReadLine();
                        Console.WriteLine($"Received: {result}, Requests: {++req}");
                        Thread.Sleep(100); //

                        w.WriteLine(result.ToUpper());
                        w.Flush();
                    }

                }
            }
        }
    }
}
