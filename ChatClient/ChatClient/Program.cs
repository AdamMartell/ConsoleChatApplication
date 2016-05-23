using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chat Pro");
            Console.WriteLine("All Hail Console");
            Client client = new Client("10.2.20.76", 9999);
            Parallel.Invoke(client.Send, client.Recieve);
        }
    }
}

