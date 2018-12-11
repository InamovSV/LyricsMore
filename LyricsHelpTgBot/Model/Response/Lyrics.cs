using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsHelpTgBot.Model.Response
{
    public partial class Lyrics
    {
        [JsonProperty("lyrics_id")]
        public long LyricsId { get; set; }

        [JsonProperty("restricted")]
        public long Restricted { get; set; }

        [JsonProperty("instrumental")]
        public long Instrumental { get; set; }

        [JsonProperty("lyrics_body")]
        public string LyricsBody { get; set; }

        [JsonProperty("lyrics_language")]
        public string LyricsLanguage { get; set; }

        [JsonProperty("script_tracking_url")]
        public Uri ScriptTrackingUrl { get; set; }

        [JsonProperty("pixel_tracking_url")]
        public Uri PixelTrackingUrl { get; set; }

        [JsonProperty("lyrics_copyright")]
        public string LyricsCopyright { get; set; }

        [JsonProperty("backlink_url")]
        public Uri BacklinkUrl { get; set; }

        [JsonProperty("updated_time")]
        public DateTimeOffset UpdatedTime { get; set; }
    }
}
