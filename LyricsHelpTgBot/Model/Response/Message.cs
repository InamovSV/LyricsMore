using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsHelpTgBot.Model.Response
{
    public partial class Message
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }
}
