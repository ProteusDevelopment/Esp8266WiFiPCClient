using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
 
namespace WiFiClient
{
    class Program
    {
        private static readonly IPAddress address = IPAddress.Parse("10.10.10.137");
        private const int port = 7777;
 
        private static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
 
            EndPoint endPoint = new IPEndPoint(address, port);
 
            byte[] buffer = new byte[50];
 
            byte[] toSend = Encoding.ASCII.GetBytes("Hello, guys!");
 
            socket.SendTo(toSend, endPoint);
 
            int bytes = socket.ReceiveFrom(buffer, ref endPoint);
 
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
 
            Thread.Sleep(3000);
 
            socket.SendTo(toSend, endPoint);
 
            socket.Close();
        }
    }
}
