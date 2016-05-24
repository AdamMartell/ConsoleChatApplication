using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public static class UI
    {
        public static ConsoleColor sentMessageColor = ConsoleColor.DarkGreen;
        public static ConsoleColor recievedMessageColor = ConsoleColor.DarkRed;
        public static void DisplayMessage(string message)
        {
            Console.ForegroundColor = recievedMessageColor;
            Console.WriteLine(message);
            Console.ForegroundColor = sentMessageColor;
        }
        public static string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
