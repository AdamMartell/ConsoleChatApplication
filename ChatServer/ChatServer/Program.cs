using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Server server = new Server();
            server.Run();
            
            //while (true)
            //{
            //    byte[] recievedMessage = new byte[256];
            //    stream.Read(recievedMessage, 0, recievedMessage.Length);
            //    Console.WriteLine(Encoding.ASCII.GetString(recievedMessage).Trim());
            //}
            Console.ReadLine();
        }
    }
}
