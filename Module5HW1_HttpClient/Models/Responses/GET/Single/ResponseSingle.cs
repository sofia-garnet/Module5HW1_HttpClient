using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1.Models.Responses.Single
{
    public class ResponseSingle<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("support")]
        public SupportSingle Support { get; set; }
    }
}
