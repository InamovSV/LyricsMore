using LyricsHelpTgBot.Model.JsonParser;
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
            JsonParser.Deserialize(json);
            Bot.StartReceiving(new UpdateType[0]);
            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
            Bot.StopReceiving();
        }
        static string json = "{\"message\": {\"header\": {\"status_code\": 200,\"execute_time\": 0.04367995262146},\"body\": {\"lyrics\": {\"lyrics_id\": 7260188,\"restricted\": 0,\"instrumental\": 0,\"lyrics_body\": \"Now and then I think of when we were together\r\n...\",\"lyrics_language\": \"en\",\"script_tracking_url\": \"http:\\/\\/tracking.musixmatch.com\\/t1.0\\/m42By\\/J7rv9z\",\"pixel_tracking_url\": \"http:\\/\\/tracking.musixmatch.com\\/t1.0\\/m42By\\/J7rv9z6q9he7AA\",\"lyrics_copyright\": \"Lyrics powered by www.musiXmatch.com\",\"backlink_url\": \"https://www.musixmatch.com/lyrics/Gotye-feat-Kimbra/Somebody-That-I-Used-to-Know\",\"updated_time\": \"2012-04-26T02:09:39Z\"}}}}";
        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;

            switch (message.Text.Split(' ').First())
            {
                case "/hello":
                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Hello, " + message.From.Username+"!");
                    break;
                default:

                    break;
            }
        }
        }
}
