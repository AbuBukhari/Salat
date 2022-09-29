using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Salat.Information
{
    class Internet_protocol
    {
        public static string Country { get; set; }
        public static string City { get; set; }
        public static void ip()
        {
            WebClient client = new WebClient();
            string downloadString = client.DownloadString("http://ip-api.com/json/");

            JObject rss = JObject.Parse(downloadString);
            Country = (string)rss["country"];
            City = (string)rss["city"];
        }
    }
}
