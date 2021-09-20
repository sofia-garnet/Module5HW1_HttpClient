using Newtonsoft.Json;
using System;

namespace Module5HW1.Models.Responses.List
{
    public class Support
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}