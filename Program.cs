using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;
using System.Threading;
using Telegram.Bot.Args;
using System.IO;
using Telegram.Bot.Types;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;


namespace TelegramBot
{
    class Program
    {
        public static TelegramBotClient Client;



        static void Main(string[] args)
        {
            Client = new TelegramBotClient("1640386539:AAFG4fPTXIAc8AxoLyRW8qv3Vm - 9uutXnTM");
            Client.OnMessage += Client_OnMessage;
            Client.StartReceiving();
            Thread.Sleep(-1);
        }

        private static void Client_OnMessage(object sender, MessageEventArgs e)
        {
            var id = e.Message.Chat.Id;
            var text = e.Message.Text;
            var message = e.Message;

            Console.WriteLine(message.From.FirstName);

            switch (message.Text)
            {
                case "/time":
                    var response = DateTime.Now.ToString();
                    Client.SendTextMessageAsync(id, response);
                    break;

                case "/me":
                    var me = Client.GetMeAsync().Result;
                    Client.SendTextMessageAsync(id, $"Username: {me.ToString()}");
                    break;

                case "/hello":
                    var greeting = "Assalomu Aleykum! Bot xizmatingizda -_-";
                    Client.SendTextMessageAsync(id, greeting);
                    break;



            }
        }
    }
}

