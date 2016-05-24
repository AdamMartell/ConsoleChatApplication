using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Message
    {

        public Client sender;
        public string body;
        public Message(Client Sender, string Body)
        {
            sender = Sender;
            body = Body;
        }
    }
}
