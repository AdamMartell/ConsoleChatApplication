using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    class Server
    {
        public static ConcurrentQueue<Message> messageQueue = new ConcurrentQueue<Message>();
        public static List<Client> clients;
        IPAddress localAddress;
        TcpListener server;
        public Server()
        {
            clients = new List<Client>();
            localAddress = IPAddress.Parse("10.2.20.76");
            server = new TcpListener(localAddress, 9999);
            server.Start();
        }
        public void Run()
        {
            Parallel.Invoke(AcceptClients, SendToAll);
        }
        private void AcceptClients()
        {
            while (true)
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = clientSocket.GetStream();
                Client client = new Client(stream, clientSocket);
                clients.Add(client);
                Thread clientThread = new Thread(new ThreadStart(client.Recieve));
                clientThread.Start();
            }
        }
        private void SendToAll()
        {
            while (true)
            {
                Message message = new Message(null, "");
                if(messageQueue.TryDequeue(out message))
                {
                    foreach(Client client in clients)
                    {
                        if(client != message.sender)
                        {
                            client.Send(message.body);
                        }
                    }
                }

            }
        }
    }
}
