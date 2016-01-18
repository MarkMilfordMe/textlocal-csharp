using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLocal.Models
{
    public class TextLocal_Authentication
    {

        public TextLocal_Authentication(string username, string hash)
        {
            this.username = username;
            this.hash = hash;
        }
        public TextLocal_Authentication(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public string username { get; set; }
        public string hash { get; set; }

        public string apiKey { get; set; }

        public string format = "json";
    }
}
