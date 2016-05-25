﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public static class BackSlashCommand
    {
        public static void Register()
        {
            Console.WriteLine("Enter your Email Address");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter your Password");
            string Password = Console.ReadLine();
            Console.WriteLine("Confirm your Password");
            string ConfirmPassword = Console.ReadLine();
            WebRequest request = WebRequest.Create("http://localhost:6483/api/Account/Register");
            request.Method = "POST";
            request.ContentType = "application/json";
            byte[] byteArray = Encoding.UTF8.GetBytes("{\"Email\" : \"" + Email + "\",\"Password\" : \"" + Password + "\", \"ConfirmPassword\" : \"" + ConfirmPassword + "\"}" );
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
        }
    }
}
