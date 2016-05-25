using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public static class MessageParser
    {
        public static void CheckForBackslashCommand(string message)
        {
            if (message.StartsWith("\\"))
            {
                message = message.Replace("\\", "");
                string[] messageArray = message.Split(' ');
                RunCommand(messageArray);
            }
        }
        public static void RunCommand(string[] messageArray)
        {
            if(messageArray[0] == "Register")
            {
                BackSlashCommand.Register();
            }
        }
        
    }
}
