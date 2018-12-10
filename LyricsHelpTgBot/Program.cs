using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace LyricsHelpTgBot
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("567120649:AAGwSDFPCWxD5BHKy-SpZmOxykFLSxmDZwA");

        static void Main(string[] args)
        {
            var me = Bot.GetMeAsync().Result;
            Console.Title = me.Username;

            Bot.OnMessage += BotOnMessageReceived;

            Bot.StartReceiving(new UpdateType[0]);
            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;

            switch (message.Text.Split(' ').First())
            {
                case "/hello":
                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Hello, " + message.From.Username);
                    break;
                default:

                    break;
            }
        }
        }
}
