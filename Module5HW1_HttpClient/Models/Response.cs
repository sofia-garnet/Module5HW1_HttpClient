using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5HW1.Models
{
    public class Response<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string ReasonePhrase { get; set; }
        public T ResponseData { get; set; }

        public override string ToString()
        {
            string _ = JsonConvert.SerializeObject(this, Formatting.Indented);
            return _;
        }
    }
}
