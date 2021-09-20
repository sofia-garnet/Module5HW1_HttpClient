using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1.Models.Responses.Error
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Reason { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }

        public override string ToString()
        {
            string _ = JsonConvert.SerializeObject(this, Formatting.Indented);
            return _;
        }
    }
}
