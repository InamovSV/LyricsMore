using LyricsHelpTgBot.DAL;
using LyricsHelpTgBot.Model;
using LyricsHelpTgBot.Model.JsonParser;
using LyricsHelpTgBot.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace LyricsHelpTgBot.Server
{
    class API
    {
        TelegramBotClient tgClient;
        UserRep userRep;

        public API(TelegramBotClient client, UserRep userRep)
        {
            tgClient = client;
            this.userRep = userRep;
        }

        public async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;
            var rowMessage = message.Text.Split(' ');
            var param = rowMessage.Skip(1).ToArray();
            switch (rowMessage.First())
            {
                case "/start":
                    User user = userRep.GetByLogin(message.From.Username);
                    if (user == null)
                    {
                        userRep.Create(new User(message.From.Username));
                        await tgClient.SendTextMessageAsync(
                        message.Chat.Id,
                        "Hello, our new user " + message.From.Username + "!");
                    }
                    else
                    {
                        await tgClient.SendTextMessageAsync(
                        message.Chat.Id,
                        "Hello, our old friend " + message.From.Username + "!");
                    }
                    break;
                case "/hello":
                    await tgClient.SendTextMessageAsync(
                        message.Chat.Id,
                        "Hello, " + message.From.Username + "!");
                    break;

                case "/getsong":
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            long songId = long.Parse(param.First());
                            var response = await client.GetAsync("https://api.musixmatch.com/ws/1.1/track.lyrics.get?apikey=927ce814f4aae40952cce46b39478fd2&track_id=" + songId);
                            if (response != null)
                            {
                                var jsonString = await response.Content.ReadAsStringAsync();
                                Response resp = JsonParser.Deserialize(jsonString);
                                await tgClient.SendTextMessageAsync(
                                message.Chat.Id,
                                string.Format("Song #{0}\n{1}", songId, resp.Message.Body.Lyrics.LyricsBody));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:

                    break;
            }
        }
    }
}
