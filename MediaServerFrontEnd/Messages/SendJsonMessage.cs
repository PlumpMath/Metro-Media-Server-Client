using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaServerFrontEnd.Messages
{
    public class SendJsonMessage
    {
        public string Json { get; set; }

        public SendJsonMessage(string json)
        {
            this.Json = json;
        }
    }
}
