using LyricsHelpTgBot.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsHelpTgBot.Model.JsonParser
{
    public class JsonParser
    {
        public static Response.Response Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Response.Response>(json);
        }
    }
}
