using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text.Json;

namespace TestFileTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wee");
            byte[] bytes = File.ReadAllBytes("C:/temp/Git-2.34.1-64-bit.exe");

            TransferClass myTrans = new() { Id = 1, Name = "test", Data = bytes };

            SendToTcp(myTrans);
        }

        public static void SendToRest(TransferClass myTrans)
        {
            using (HttpClient client = new HttpClient())
            {
                JsonContent content = JsonContent.Create(myTrans);
                HttpResponseMessage result = client.PostAsync("http://localhost:42600/api/Files", content).Result;
                Console.WriteLine(result.StatusCode);
            }
        }

        public static void SendToTcp(TransferClass myTrans)
        {
            string jsonString = JsonSerializer.Serialize(myTrans);

            TcpClient socket = new TcpClient("127.0.0.1", 12345);
            NetworkStream ns = socket.GetStream();

            StreamWriter writer = new StreamWriter(ns);
            writer.Write(jsonString);
            writer.Flush();
            socket.Close();
        }
    }

    class TransferClass
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
    }
}
