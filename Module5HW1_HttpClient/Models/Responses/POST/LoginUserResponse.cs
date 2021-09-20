using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1.Models.Responses.POST
{
    public class LoginUserResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
