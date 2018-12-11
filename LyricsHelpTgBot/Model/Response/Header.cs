using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsHelpTgBot.Model.Response
{
    public partial class Header
    {
        [JsonProperty("status_code")]
        public long StatusCode { get; set; }

        [JsonProperty("execute_time")]
        public double ExecuteTime { get; set; }
    }
}
