using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace TestFileReceive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TcpListener listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();

            while (true)
            {
                try
                {
                    TcpClient socket = listener.AcceptTcpClient();

                    NetworkStream ns = socket.GetStream();
                    StreamReader reader = new StreamReader(ns);

                    String jsonString = reader.ReadToEnd();
                    TransferClass transfered = JsonSerializer.Deserialize<TransferClass>(jsonString);

                    File.WriteAllBytes($"c:/temp/{transfered.Name}.png", transfered.Data);

                    Console.Write("saved file: " + transfered.Name);

                    socket.Close();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
    class TransferClass
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
    }
}
