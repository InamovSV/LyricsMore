using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsHelpTgBot.Model.Response
{
    public partial class Body
    {
        [JsonProperty("lyrics")]
        public Lyrics Lyrics { get; set; }
    }
}
