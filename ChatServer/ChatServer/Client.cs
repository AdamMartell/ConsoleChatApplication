using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Client
    {
        NetworkStream stream;
        TcpClient client;
        public Client(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
        }
        public void Send(string Message)
        {
            byte[] message = Encoding.ASCII.GetBytes(Message);
            stream.Write(message, 0, message.Count());
        }
        public void Recieve()
        {
            while (true)
            {
                try
                {
                    byte[] recievedMessage = new byte[256];
                    stream.Read(recievedMessage, 0, recievedMessage.Length);
                    string recievedMessageString = Encoding.ASCII.GetString(recievedMessage).Trim(new char[] { '\0' });
                    Message message = new Message(this, recievedMessageString);
                    Server.messageQueue.Enqueue(message);
                    Console.WriteLine(recievedMessageString);
                }
                catch (Exception e)
                {
                    Server.clients.Remove(this);
                    Console.WriteLine("Client Disconnected");
                    break;
                }
            }
        }
    }
}
